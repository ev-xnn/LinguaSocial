<%@ Page Title="Admin - Manage Accessory - "
    Language="C#"
    MasterPageFile="~/ecommerce.master"
    AutoEventWireup="true"
    CodeBehind="admin-accessories-manage.aspx.cs"
    Inherits="YourProject.admin_accessories_manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Admin - Manage Accessory</h2>

    <asp:Label ID="lblMsg" runat="server" />
    <br /><br />

    <table>
        <tr>
            <td>Name:</td>
            <td><asp:TextBox ID="txtName" runat="server" /></td>
        </tr>
        <tr>
            <td>Price:</td>
            <td><asp:TextBox ID="txtPrice" runat="server" /></td>
        </tr>
        <tr>
            <td>Image Upload:</td>
            <td>
                <asp:FileUpload ID="fuImage" runat="server" />
                <br />
                (Optional) Existing ImagePath:
                <asp:TextBox ID="txtImagePath" runat="server" />
            </td>
        </tr>
    </table>

    <br />

    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    <asp:Button ID="btnBack" runat="server" Text="Back" PostBackUrl="~/admin-accessories.aspx" />

</asp:Content>

