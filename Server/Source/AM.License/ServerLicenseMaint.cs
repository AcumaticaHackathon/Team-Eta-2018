
using AM.License.DAC;
using PX.Objects.CR;
using PX.Data;
using System;

namespace AM.License
{
    public class ServerLicenseMaint : PXGraph<ServerLicenseMaint, AMLicenseSetup>
    {
        #region Selects

        public PXSelect<AMLicenseSetup> PagePrimaryView;

        public PXSelect<BAccount,
        Where<BAccount.bAccountID, Equal<Required<BAccount.bAccountID>>>> SingleBaccountView;

        public PXSelectReadonly2<Contact,
        InnerJoin<BAccount, On<Contact.bAccountID, Equal<BAccount.bAccountID>,
        And<Contact.contactID, Equal<BAccount.defContactID>>>>,
        Where<BAccount.bAccountID, Equal<Current<AMLicenseSetup.baccountId>>>> ContactView;

        public PXSelectReadonly2<Address,
        InnerJoin<BAccount, On<Address.bAccountID, Equal<BAccount.bAccountID>,
        And<Address.addressID, Equal<BAccount.defAddressID>>>>,
        Where<BAccount.bAccountID, Equal<Current<AMLicenseSetup.baccountId>>>> AddressView;

        public PXSelect<AMLicenseProducts,
        Where<AMLicenseProducts.licenseID, Equal<Current<AMLicenseSetup.licenseID>>>> ProductsView;

        #endregion

        #region Actions

        public PXAction<AMLicenseSetup> CreateKey;
        public PXAction<AMLicenseSetup> ResetWidow;

        #endregion

        #region Events

        #region AMLicenseProducts WindowSize FieldDefaulting
        public void AMLicenseProducts_WindowSize_FieldDefaulting(PXCache sender, PXFieldDefaultingEventArgs e)
        {
            e.NewValue = PagePrimaryView.Current.AccountDefWindowSize;}


        #endregion

        #region AMLicenseProducts WindowBeginDate FieldDefaulting
        public void AMLicenseProducts_WindowBeginDate_FieldDefaulting(PXCache sender, PXFieldDefaultingEventArgs e)
        {
            e.NewValue = Accessinfo.BusinessDate;
        }

        #endregion

        #region AMLicenseProducts WindowEndDate FieldDefaulting
        public void AMLicenseProducts_WindowEndDate_FieldDefaulting(PXCache sender, PXFieldDefaultingEventArgs e)
        {
            if (!(e.Row is AMLicenseProducts row)) return;
            var winSize = Convert.ToDouble(PagePrimaryView.Current.AccountDefWindowSize);
            var currDate = Convert.ToDateTime(Accessinfo.BusinessDate);
            e.NewValue = currDate.AddDays(winSize);
        }

        #endregion

        #region AMLicenseProducts ProductKey FieldDefaulting
        public void AMLicenseProducts_ProductKey_FieldDefaulting(PXCache sender, PXFieldDefaultingEventArgs e)
        {
            e.NewValue = Guid.NewGuid().ToString();
        }

        #endregion

        #region AMLicenseSetup RowUpdated
        public void AMLicenseSetup_RowUpdated(PXCache sender, PXRowUpdatedEventArgs e)
        {
            if (!(e.Row is AMLicenseSetup row)) return;
            if (!(e.OldRow is AMLicenseSetup oldRow)) return;

            if (!row.BaccountID.HasValue) return;
            if (row.BaccountID == oldRow.BaccountID) return;

            var baccoutRec = (BAccount)SingleBaccountView.Select(row.BaccountID);
            row.CompanyName = baccoutRec?.AcctName;
        }

        #endregion

        #region AMLicenseSetup RowSelected
        public void AMLicenseSetup_RowSelected(PXCache sender, PXRowSelectedEventArgs e)
        {
            if (!(e.Row is AMLicenseSetup row)) return;
            CreateKey.SetEnabled(!row.LicenseKey.HasValue);
            ProductsView.AllowInsert = PagePrimaryView.Current.LicenseKey.HasValue;
        }

        #endregion

        #endregion

        #region Methods

        #region Button Create Key

        [PXButton]
        [PXUIField(DisplayName = "Create Key")]
        public void createKey()
        {
            var record = PagePrimaryView.Current;

            if (record.LicenseKey.HasValue) return;

            record.LicenseKey = Guid.NewGuid();
        }

        #endregion

        #region Button Reset Window

        [PXButton]
        [PXUIField(DisplayName = "Reset Key Window")]
        public void resetWidow()
        {
            var record = ProductsView.Current;
            record.IsValid = false;

            var curDate = Accessinfo.BusinessDate;
            var licBegin = record.LicenseBeginDate;
            var licEnd = record.LicenseEndDate;
            var winBegin = record.WindowBeginDate;
            var winEnd = record.WindowEndDate;
            var winSize = Convert.ToDouble(record.WindowSize);

            if (curDate < licBegin) return;
            if (curDate > licEnd) return;
            if (curDate < winBegin) return;
            if (curDate > winEnd) return;

            record.WindowBeginDate = Accessinfo.BusinessDate;
            record.WindowEndDate = Convert.ToDateTime(Accessinfo.BusinessDate).AddDays(winSize);
            record.ProductKey = Guid.NewGuid();
            ProductsView.Cache.Update(record);
            Save.Press();
        }

        #endregion

        #endregion
    }
}