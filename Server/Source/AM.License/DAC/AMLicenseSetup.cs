
using PX.Data;
using PX.Objects.CR;
using System;

namespace AM.License.DAC
{
    [Serializable]
    public class AMLicenseSetup : IBqlTable
    {
        #region License ID
        public abstract class licenseID : IBqlField { }
        [PXDBIdentity]
        public virtual int? LicenseID { get; set; }

        #endregion

        #region License CD
        public abstract class licenseCD : IBqlField { }
        [PXDBString(15, IsUnicode = true, IsKey = true)]
        [PXDimensionSelector("CUSTOMLICENSE", typeof(licenseCD), typeof(licenseCD))]
        [PXUIField(DisplayName = "License ID")]
        public virtual string LicenseCD { get; set; }

        #endregion

        #region Baccount ID
        public abstract class baccountId : IBqlField { }
        [CustomerProspectVendor(DisplayName = "Account ID")]
        public virtual int? BaccountID { get; set; }

        #endregion

        #region Company Name
        public abstract class companyName : IBqlField { }
        [PXDBString(70, IsUnicode = true)]
        [PXUIField(DisplayName = "Company Name", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string CompanyName { get; set; }

        #endregion

        #region Instance URL
        public abstract class instanceUrl : IBqlField { }
        [PXDBString(70, IsUnicode = true)]
        [PXUIField(DisplayName = "Company URL")]
        public virtual string InstanceUrl { get; set; }

        #endregion

        #region License Installation ID
        public abstract class licenseInstallationID : IBqlField { }
        [PXDBGuid]
        [PXUIField(DisplayName = "ACM Install ID")]
        public virtual Guid? LicenseInstallationID { get; set; }

        #endregion

        #region License Key
        public abstract class licenseKey : IBqlField { }
        [PXDBGuid]
        [PXUIField(DisplayName = "License Key", IsReadOnly = true)]
        public virtual Guid? LicenseKey { get; set; }

        #endregion

        #region Allow Trial License
        public abstract class allowTrialLicense : IBqlField { }
        [PXDBBool]
        [PXUIField(DisplayName = "Allow Trial License")]
        public virtual bool? AllowTrialLicense { get; set; }

        #endregion

        #region Account Default Trial Size
        public abstract class accountDefTrialSize : IBqlField { }
        [PXDBInt]
        [PXUIEnabled(typeof(Where<allowTrialLicense, Equal<True>>))]
        [PXUIField(DisplayName = "Default Trial")]
        public virtual int? AccountDefTrialSize { get; set; }

        #endregion

        #region Account Default Window Size
        public abstract class accountDefWindowSize : IBqlField { }
        [PXDBInt]
        [PXUIField(DisplayName = "Default Window Size")]
        public virtual int? AccountDefWindowSize { get; set; }

        #endregion

        #region System Fields

        #region CreatedByID
        public abstract class createdByID : IBqlField { }
        [PXDBCreatedByID]
        public virtual Guid? CreatedByID { get; set; }

        #endregion

        #region CreatedByScreenID
        public abstract class createdByScreenID : IBqlField { }
        [PXDBCreatedByScreenID]
        public virtual string CreatedByScreenID { get; set; }

        #endregion

        #region CreatedDateTime
        public abstract class createdDateTime : IBqlField { }
        [PXDBCreatedDateTime]
        public virtual DateTime? CreatedDateTime { get; set; }

        #endregion

        #region LastModifiedByID
        public abstract class lastModifiedByID : IBqlField { }
        [PXDBLastModifiedByID]
        public virtual Guid? LastModifiedByID { get; set; }

        #endregion

        #region LastModifiedByScreenID
        public abstract class lastModifiedByScreenID : IBqlField { }
        [PXDBLastModifiedByScreenID]
        public virtual string LastModifiedByScreenID { get; set; }

        #endregion

        #region LastModifiedDateTime
        public abstract class lastModifiedDateTime : IBqlField { }
        [PXDBLastModifiedDateTime]
        public virtual DateTime? LastModifiedDateTime { get; set; }

        #endregion

        #region tstamp
        public abstract class Tstamp : IBqlField { }
        [PXDBTimestamp]
        public virtual byte[] tstamp { get; set; }

        #endregion

        #endregion
    }
}
