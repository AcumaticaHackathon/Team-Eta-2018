using System;
using PX.Data;
using LicencingClient.LicencingAPI;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace LicencingClient
{
    public class LicencingSetupGraph : PXGraph<LicencingSetupGraph>
    {
        public PXSave<ClientLicencingSetup> Save;
        public PXCancel<ClientLicencingSetup> Cancel;

        public PXSelect<ClientLicencingSetup> Licencing;

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

            var endpoint = new EndpointAddress(Licencing.Current.Url);
            using (DefaultSoapClient client = new DefaultSoapClient(binding, endpoint))
            {
                client.Login(Licencing.Current.Username, Licencing.Current.Password, null, null, null);
                try
                {
                    var licence = new AMLicenseSetup();
                    licence.LicenseKey = new GuidSearch() { Value = Licencing.Current.LicenceKey };
                    var returnedLicence = (AMLicenseSetup)client.Get(licence);

                    if (returnedLicence.LicenseKey.Value == Licencing.Current.LicenceKey)
                    {
                        Licencing.Current.LastValidationDate = DateTime.Now;
                        Licencing.Current.IsValid = true;
                        Licencing.Update(Licencing.Current);
                        Actions.PressSave();
                    }
                }

                catch (Exception e)
                {
                    throw new PXException("Key not found", e);
                }
                finally
                {
                    client.Logout();
                }
            }
        }
    }
}