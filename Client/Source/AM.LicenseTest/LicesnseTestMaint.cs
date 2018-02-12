using AM.LicenseTest.DAC;
using LicencingClient;
using PX.Data;

namespace AM.LicenseTest
{
    /// <summary>
    /// This is just a sample customization to show how to apply licencing to it.
    /// </summary>
    public class LicenseTestMaint : PXLicensedGraph<LicenseTestMaint, AMLicenseTest, LicenseTestMaintLicence>
    {
        public PXSelect<AMLicenseTest> PagePrimaryView;
    }

    public class LicenseTestMaintLicence : IProjectLicense
    {
        public string ProjectID => "LicenseTestMaint";

        public string ProjectDescription => "This is my customization for demo.";

        public string LicenseServerUrl => "http://localhost/LicencingServer/(W(1))/entity/LicencingAPI/1?wsdl";

        public string LicenseServerUsername => "admin";

        public string LicenseServerPassword => "admin";

        public int LicenseWindowDays => 7;
    }
}
