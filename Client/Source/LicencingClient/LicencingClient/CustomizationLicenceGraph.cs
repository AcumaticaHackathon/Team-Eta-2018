using LicencingClient.LicencingAPI;
using PX.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace LicencingClient
{
    public class CustomizationLicenceGraph : PXGraph<CustomizationLicenceGraph>
    {
        public PXSelect<ClientLicencingSetup> Licences;
        public PXSelect<ClientLicencingSetup, Where<ClientLicencingSetup.customizationID,
            Equal<Required<ClientLicencingSetup.customizationID>>>> ExistingLicences;

        protected virtual IEnumerable licences()
        {
            foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (PXSubstManager.IsSuitableTypeExportAssembly(ass, false))
                {
                    Type[] types = null;
                    try
                    {
                        if (!ass.IsDynamic)
                            types = ass.GetExportedTypes();
                    }
                    catch (ReflectionTypeLoadException te)
                    {
                        types = te.Types;
                    }
                    catch
                    {
                        continue;
                    }
                    if (types != null)
                    {
                        foreach (Type t in types)
                        {
                            if (t != null && typeof(IProjectLicense).IsAssignableFrom(t) && t != typeof(IProjectLicense))
                            {
                                var projectLicense = (IProjectLicense)Activator.CreateInstance(t);
                                var existingLicence = (ClientLicencingSetup)ExistingLicences.SelectWindowed(0, 1, projectLicense.ProjectID);
                                if (existingLicence != null)
                                {
                                    yield return existingLicence;
                                }
                                else
                                {

                                    var licence = new ClientLicencingSetup()
                                    {
                                        CustomizationID = projectLicense.ProjectID,
                                        Description = projectLicense.ProjectDescription,
                                        Url = projectLicense.LicenseServerUrl,
                                        Username = projectLicense.LicenseServerUsername,
                                        Password = projectLicense.LicenseServerPassword,
                                        WindowDays = projectLicense.LicenseWindowDays,
                                    };
                                    Licences.Insert(licence);
                                    yield return licence;
                                }
                            }
                        }
                    }
                }
            }
        }

        public PXAction<ClientLicencingSetup> Validate;
        [PXButton]
        public void validate()
        {
            var binding = new BasicHttpBinding()
            {
                Name = "DefaultSoap",
                AllowCookies = true,
                MaxReceivedMessageSize = 6553600
            };

            foreach (ClientLicencingSetup project in Licences.Cache.Inserted)
            {
                var endpoint = new EndpointAddress(project.Url);
                using (DefaultSoapClient client = new DefaultSoapClient(binding, endpoint))
                {
                    client.Login(project.Username, project.Password, null, null, null);
                    try
                    {
                        var licence = new AMLicenseSetup();
                        licence.LicenseKey = new GuidSearch() { Value = project.LicenceKey };
                        var returnedLicence = (AMLicenseSetup)client.Get(licence);

                        if (returnedLicence.LicenseKey.Value == project.LicenceKey)
                        {
                            project.LastValidationDate = DateTime.Now;
                            project.IsValid = true;
                        }
                        else
                        {
                            project.IsValid = false;
                        }

                        Licences.Update(project);
                    }

                    catch (Exception e)
                    {
                        continue;
                    }
                    finally
                    {
                        client.Logout();
                    }
                }
            }

            Actions.PressSave();
        }
    }
}