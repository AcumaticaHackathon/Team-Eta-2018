
using PX.Data;
using System;

namespace AM.LicenseTest.DAC
{
    [Serializable]
    public class AMLicenseTest : IBqlTable
    {
        public abstract class tableID : IBqlField { }
        [PXDBIdentity(IsKey = true)]
        public virtual int? TableID { get; set; }

        public abstract class textField : IBqlField { }
        [PXDBString(150, IsUnicode = true)]
        [PXUIField(DisplayName = "Text Field")]
        public virtual string TextField { get; set; }

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
