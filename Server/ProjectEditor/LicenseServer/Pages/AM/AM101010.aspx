<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true"
    ValidateRequest="false" CodeFile="AM101010.aspx.cs" Inherits="Page_AM101010" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%" TypeName="AM.License.ServerLicenseMaint" PrimaryView="PagePrimaryView">
		<CallbackCommands>
		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" Style="z-index: 100" Width="100%" DataMember="PagePrimaryView" SkinID="Transparent">
		<Template>
			<px:PXLayoutRule runat="server" StartRow="True" ControlSize="L"/>
		    <px:PXSegmentMask ID="edLicenseCD" runat="server" DataField="LicenseCD"/>
		    <px:PXSegmentMask ID="edBaccountID" runat="server" DataField="BaccountID"/>
		    <px:PXTextEdit ID="edCompanyName" runat="server" DataField="CompanyName"/>
		    <px:PXLayoutRule runat="server" StartColumn="True" ControlSize="L"/>
		    <px:PXTextEdit ID="edInstanceUrl" runat="server" DataField="InstanceUrl"/>
		    <px:PXTextEdit ID="edLicenseInstallationID" runat="server" DataField="LicenseInstallationID"/>
		    <px:PXTextEdit ID="edLicenseKey" runat="server" DataField="LicenseKey"/>
		    <px:PXLayoutRule runat="server" StartColumn="True" ControlSize="L"/>
		    <px:PXDateTimeEdit ID="edLicenseBegin" runat="server" DataField="LicenseBegin"/>
		    <px:PXDateTimeEdit ID="edLicenseEnd" runat="server" DataField="LicenseEnd"/>
		</Template>
	    <ContentLayout OuterSpacing="None" />
	    <ContentStyle BackColor="Transparent" BorderStyle="None">
	    </ContentStyle>
	</px:PXFormView>
</asp:Content>

<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server">
	<px:PXTab ID="tab" runat="server" Width="100%" Height="150px" DataSourceID="ds">
		<Items>
			<px:PXTabItem Text="Account Details">
                <Template>
			    <px:PXFormView ID="PXFormView1" runat="server" DataSourceID="ds" Style="z-index: 100" Width="100%" DataMember="ContactView" SkinID="Transparent">
			        <Template>
			            <px:PXLayoutRule runat="server" StartRow="True" ControlSize="L" StartGroup="True" GroupCaption="License Contact"/>
			            <px:PXTextEdit ID="edDisplayName" runat="server" DataField="DisplayName"/>
			            <px:PXMailEdit ID="edEMail" runat="server" DataField="EMail"/>
			            <px:PXMaskEdit ID="Phone1" runat="server" DataField="Phone1" />
			            <px:PXMaskEdit ID="Phone2" runat="server" DataField="Phone2" />
			        </Template>
			        <ContentLayout OuterSpacing="None" />
			        <ContentStyle BackColor="Transparent" BorderStyle="None">
			        </ContentStyle>
			    </px:PXFormView>
                    <px:PXFormView ID="PXFormView2" runat="server" DataSourceID="ds" Style="z-index: 100" Width="100%" DataMember="AddressView" SkinID="Transparent">
                        <Template>
                            <px:PXLayoutRule runat="server" StartRow="True" ControlSize="L" StartGroup="True" GroupCaption="License Address"/>
                            <px:PXTextEdit ID="edAddressLine1" runat="server" DataField="AddressLine1" />
                            <px:PXTextEdit ID="edAddressLine2" runat="server" DataField="AddressLine2" />
                            <px:PXTextEdit ID="edCity" runat="server" DataField="City" />
                            <px:PXSelector ID="edState" runat="server" AutoRefresh="True" DataField="State" CommitChanges="true"
                                           FilterByAllFields="True" TextMode="Search" DisplayMode="Hint" />
                            <px:PXLayoutRule ID="PXLayoutRule15" runat="server" Merge="True" />
                            <px:PXMaskEdit ID="edPostalCode" runat="server" DataField="PostalCode" Size="S" CommitChanges="True" />
                            <px:PXLayoutRule ID="PXLayoutRule9" runat="server" />
                            <px:PXSelector ID="edCountryID" runat="server" AllowEdit="True" DataField="CountryID"
                                           FilterByAllFields="True" TextMode="Search" DisplayMode="Hint" CommitChanges="True" />
                        </Template>
                        <ContentLayout OuterSpacing="None" />
                        <ContentStyle BackColor="Transparent" BorderStyle="None">
                        </ContentStyle>
                    </px:PXFormView>
                </Template>
			</px:PXTabItem>
            
		    <px:PXTabItem Text="Account Products">
                <Template>
		        <px:PXGrid ID="PXGrid" runat="server" DataSourceID="ds" SkinID="Inquire" Width="100%" Height="200px" MatrixMode="True">
		            <Levels>
		                <px:PXGridLevel DataMember="ProductsView">
		                    <Columns>
		                        <px:PXGridColumn DataField="ProductName" Width="300px"/>
		                        <px:PXGridColumn DataField="ProductVersion" Width="300px" />
		                        <px:PXGridColumn DataField="LicenseBeginDate" Width="100" />
		                        <px:PXGridColumn DataField="LicenseEndDate" Width="100" />
		                        <px:PXGridColumn DataField="IsTrial" Type="CheckBox" TextAlign="Center" Width="80" />
		                    </Columns>
		                    <Layout FormViewHeight="" />
		                </px:PXGridLevel>
		            </Levels>
		            <AutoSize Enabled="True" MinHeight="200" />
		        </px:PXGrid>
                </Template>
            </px:PXTabItem>
		</Items>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" />
	</px:PXTab>
</asp:Content>
