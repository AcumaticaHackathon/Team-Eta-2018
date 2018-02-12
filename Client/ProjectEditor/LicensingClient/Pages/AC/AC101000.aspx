<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="AC101000.aspx.cs" Inherits="Page_AC101000" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/FormView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="LicencingClient.LicencingSetupGraph"
        PrimaryView="Licencing">
        <CallbackCommands>
        </CallbackCommands>
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="Licencing" Width="100%" AllowAutoHide="false">
        <Template>
            <px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartRow="True" />
            <px:PXTextEdit runat="server" DataField="CustomizationID" ID="edCustomizationID"></px:PXTextEdit>
            <px:PXTextEdit runat="server" DataField="LicenceKey" ID="edLicenceKey" ></px:PXTextEdit>
            <px:PXTextEdit runat="server" DataField="Url" ID="PXTextEdit1" ></px:PXTextEdit>
            <px:PXTextEdit runat="server" DataField="Username" ID="PXTextEdit2" ></px:PXTextEdit>
            <px:PXTextEdit runat="server" DataField="Password" ID="PXTextEdit3" ></px:PXTextEdit>
            <px:PXDateTimeEdit runat="server" DataField="LastValidationDate" ID="edLastValidationDate"></px:PXDateTimeEdit>
            <px:PXCheckBox runat="server" DataField="IsValid" ID="edIsValid"></px:PXCheckBox>
        </Template>
        <AutoSize Container="Window" Enabled="True" MinHeight="200" />
    </px:PXFormView>
</asp:Content>

