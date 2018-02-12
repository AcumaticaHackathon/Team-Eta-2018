<%@ Page Language="C#" MasterPageFile="~/MasterPages/ListView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="AC101001.aspx.cs" Inherits="Page_AC101001" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/ListView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="LicencingClient.CustomizationLicenceGraph"
        PrimaryView="Licences">
        <CallbackCommands>
        </CallbackCommands>
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phL" runat="Server">
    <px:PXGrid ID="grid" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="Inquire" AllowAutoHide="false">
        <Levels>
            <px:PXGridLevel DataMember="Licences">
                <Columns>
                    <px:PXGridColumn DataField="CustomizationID" Width="150px" />
                    <px:PXGridColumn DataField="Description"  Width="400px"/>
                    <px:PXGridColumn DataField="IsValid" Type="CheckBox" />
                    <px:PXGridColumn DataField="LastValidationDate"  Width="100px"/>
                    <px:PXGridColumn DataField="WindowDays"  Width="75px"/>
                    <px:PXGridColumn DataField="LicenceKey" Width="200px" CommitChanges="true" />
                    <px:PXGridColumn DataField="Url" Width="200px" />
                </Columns>
            </px:PXGridLevel>
        </Levels>
        <AutoSize Container="Window" Enabled="True" MinHeight="150" />
        <ActionBar>
        </ActionBar>
    </px:PXGrid>
</asp:Content>
