using PX.Data;

namespace LicencingClient
{
    public class PXLicensedGraph<TGraph, TPrimary, TProjectLicense> : PXGraph<TGraph, TPrimary>
        where TGraph : PXGraph
        where TPrimary : class, IBqlTable, new()
        where TProjectLicense : class, IProjectLicense

    {
        public PXSetup<ClientLicencingSetup, 
            Where<ClientLicencingSetup.customizationID, Equal<Required<ClientLicencingSetup.customizationID>>>> LicenceSetup;

        public PXLicensedGraph()
        {
            var licence = (ClientLicencingSetup)LicenceSetup.SelectWindowed(0, 1, this.GetType().Name);
            if (licence == null)
            {
                throw new PXException("Customization '{0}' requires a licence.", this.GetType().Name);
            }
            else if(licence.IsValid != true)
            {
                throw new PXException("Customization '{0}' key is invalid.", this.GetType().Name);
            }
        }
    }
}
