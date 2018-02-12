using System;
using PX.Data;

namespace LicencingClient
{
    [Serializable]
    public class ClientLicencingSetup : IBqlTable
    {
        #region CustomizationID
        [PXDBString(255, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Customization ID", Enabled = false)]
        public virtual string CustomizationID { get; set; }
        public abstract class customizationID : IBqlField { }
        #endregion

        #region LicenceKey
        [PXDBGuid()]
        [PXUIField(DisplayName = "Licence Key")]
        public virtual Guid? LicenceKey { get; set; }
        public abstract class licenceKey : IBqlField { }
        #endregion

        #region IsValid
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Valid", Enabled = false)]
        public virtual bool? IsValid { get; set; }
        public abstract class isValid : IBqlField { }
        #endregion

        #region Url
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Url", Enabled = false)]
        public virtual string Url { get; set; }
        public abstract class url : IBqlField { }
        #endregion

        #region Username
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Username", Enabled = false)]
        public virtual string Username { get; set; }
        public abstract class username : IBqlField { }
        #endregion

        #region Password
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Password", Enabled = false)]
        public virtual string Password { get; set; }
        public abstract class password : IBqlField { }
        #endregion

        #region LastValidationDate
        [PXDBDate()]
        [PXUIField(DisplayName = "Last Validation Date", Enabled = false)]
        public virtual DateTime? LastValidationDate { get; set; }
        public abstract class lastValidationDate : IBqlField { }
        #endregion

        #region Description
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Description", Enabled = false)]
        public virtual string Description { get; set; }
        public abstract class description : IBqlField { }
        #endregion

        #region WindowDays
        [PXDBInt()]
        [PXUIField(DisplayName = "Window Days", Enabled = false)]
        public virtual int? WindowDays { get; set; }
        public abstract class windowDays : IBqlField { }
        #endregion

        #region CreatedByID

        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : IBqlField { }
        #endregion

        #region CreatedByScreenID

        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : IBqlField { }
        #endregion

        #region CreatedDateTime

        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : IBqlField { }
        #endregion

        #region LastModifiedByID

        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : IBqlField { }
        #endregion

        #region LastModifiedByScreenID

        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : IBqlField { }
        #endregion

        #region LastModifiedDateTime

        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : IBqlField { }
        #endregion
    }
}