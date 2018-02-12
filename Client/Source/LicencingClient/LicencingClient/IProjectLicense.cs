namespace LicencingClient
{
    public interface IProjectLicense
    {
        string ProjectID { get; }
        string ProjectDescription { get; }
        string LicenseServerUrl { get; }
        string LicenseServerUsername { get; }
        string LicenseServerPassword { get; }

        int LicenseWindowDays { get; }
    }
}
