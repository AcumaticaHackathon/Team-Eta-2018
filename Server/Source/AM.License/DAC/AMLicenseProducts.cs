
using PX.Data;
using System;

namespace AM.License.DAC
{
    [Serializable]
    public class AMLicenseProducts : IBqlTable
    {
        #region License ID
        public abstract class licenseID : IBqlField { }
        [PXDBInt]
        [PXDBLiteDefault(typeof(AMLicenseSetup.licenseID))]
        public virtual int? LicenseID { get; set; }

        #endregion

        #region Product ID
        public abstract class productID : IBqlField { }
        [PXDBIdentity]
        public virtual int? ProductID { get; set; }

        #endregion

        #region License Key
        public abstract class licenseKey : IBqlField { }
        [PXDBGuid]
        [PXUIField(DisplayName = "License Key")]
        [PXDBLiteDefault(typeof(AMLicenseSetup.licenseKey))]
        public virtual Guid? LicenseKey { get; set; }

        #endregion

        #region Product Name
        public abstract class productName : IBqlField { }
        [PXDBString(150, IsUnicode = true)]
        [PXUIField(DisplayName = "Product Name", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string ProductName { get; set; }

        #endregion

        #region Product Version
        public abstract class productVersion : IBqlField { }
        [PXDBString(150, IsUnicode = true)]
        [PXUIField(DisplayName = "Product Version", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string ProductVersion { get; set; }

        #endregion

        #region License Begin Date
        public abstract class licenseBeginDate : IBqlField { }
        [PXDBDate(PreserveTime = false)]
        [PXUIField(DisplayName = "License Begin Date")]
        public virtual DateTime? LicenseBeginDate { get; set; }

        #endregion

        #region License End Date
        public abstract class licenseEndDate : IBqlField { }
        [PXDBDate(PreserveTime = false)]
        [PXUIField(DisplayName = "License End Date")]
        public virtual DateTime? LicenseEndDate { get; set; }

        #endregion

        #region Window Begin Date
        public abstract class windowBeginDate : IBqlField { }
        [PXDBDate(PreserveTime = false)]
        [PXUIField(DisplayName = "Window Begin Date")]
        public virtual DateTime? WindowBeginDate { get; set; }

        #endregion

        #region Window End Date
        public abstract class windowEndDate : IBqlField { }
        [PXDBDate(PreserveTime = false)]
        [PXUIField(DisplayName = "Window End Date")]
        public virtual DateTime? WindowEndDate { get; set; }

        #endregion

        #region Window Size
        public abstract class windowSize : IBqlField { }
        [PXDBInt]
        [PXUIField(DisplayName = "Window Size")]
        public virtual int? WindowSize { get; set; }

        #endregion

        #region Is Trial
        public abstract class isTrial : IBqlField { }
        [PXDBBool]
        [PXUIField(DisplayName = "Is Trial License", IsReadOnly = true)]
        public virtual bool? IsTrial { get; set; }

        #endregion

        #region Product Key
        public abstract class productKey : IBqlField { }
        [PXDBGuid]
        [PXUIField(DisplayName = "Product Key")]
        public virtual Guid? ProductKey { get; set; }

        #endregion

        #region Is Valid
        public abstract class isValid : IBqlField { }
        [PXDBBool]
        [PXUIField(DisplayName = "License Valid")]
        public virtual bool? IsValid { get; set; }

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
