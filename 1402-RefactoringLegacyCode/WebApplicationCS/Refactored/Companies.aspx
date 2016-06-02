<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Companies.aspx.cs" Inherits="WebApplicationCS.Refactored.Companies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <h2>Companies</h2>  

    <h3>Company List</h3>
    
    <asp:ListView ID="CompanyListView" runat="server" DataKeyNames="Id" OnItemCommand="CompanyListView_ItemCommand" OnSelectedIndexChanging="CompanyListView_SelectedIndexChanging" OnItemDeleting="CompanyListView_ItemDeleting">
        <LayoutTemplate>
            <table style="width: 100%;" class="border-black lines-vertical lines-horizontal header-bg-dark-grey cells-even-down-grey">
                <tr runat="server">
                    <th></th>
                    <th>Name</th>
                    <th>Phone</th>
                </tr>
                <tr runat="server" id="itemPlaceholder">
                </tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr runat="server">
                <td>
                    <asp:LinkButton ID="EditLinkButton" runat="server" Text="Edit" 
                        CommandName="Select" CommandArgument='<%# Eval("Id") %>' />
                    <asp:LinkButton ID="DeleteLinkButton1" runat="server" Text="Delete" 
                        CommandName="Delete" CommandArgument='<%# Eval("Id") %>'
                        OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                </td>
                <td>
                    <asp:Literal ID="NameLiteral" runat="server" Text='<%# Eval("Name") %>' />
                </td>
                <td>
                    <asp:Literal ID="DateLiteral" runat="server" Text='<%# Eval("PhoneNumber") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <table style="width: 100%;" class="border-black lines-vertical lines-horizontal header-bg-dark-grey cells-even-down-grey">
                <tr>
                    <th></th>
                    <th>Name</th>
                    <th>Phone</th>
                </tr>
                <tr>
                    <td colspan="3">
                        No companies Found.
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
    
    <h3>
        <asp:Literal runat="server" ID="AddUpdateHeaderLiteral" Text="Add" /> Company
    </h3>
    
    <table>
        <tr>
            <td class="bold">Name</td>
            <td>
                <asp:TextBox ID="NameTextBox" runat="server" MaxLength="100" />
            </td>
            <td class="bold">Phone Number</td>
            <td>
                <asp:TextBox ID="PhoneNumberTextBox" runat="server" MaxLength="20" />
            </td>
        </tr>
        <tr>
            <td class="bold">Street Line 1</td>
            <td>
                <asp:TextBox ID="StreetLine01TextBox" runat="server" MaxLength="100" />
            </td>
            <td class="bold">Street Line 2</td>
            <td>
                <asp:TextBox ID="StreetLine02TextBox" runat="server" MaxLength="100" />
            </td>
        </tr>
        <tr>
            <td class="bold">City</td>
            <td>
                <asp:TextBox ID="CityTextBox" runat="server" MaxLength="100" />
            </td>
            <td class="bold">State</td>
            <td>
                <asp:TextBox ID="StateTextBox" runat="server" MaxLength="2" />
            </td>
        </tr>
        <tr>
            <td class="bold">Zip Code</td>
            <td colspan="3">
                <asp:TextBox ID="ZipCodeTextBox" runat="server" MaxLength="10" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddButton_Click" />
                <asp:Button ID="UpdateButton" runat="server" Text="Update" OnClick="UpdateButton_Click" Visible="False" />
                <asp:Button ID="ClearButton" runat="server" Text="Clear" OnClick="ClearButton_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
