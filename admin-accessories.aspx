<%@ Page Title="Admin - Accessories - "
    Language="C#"
    MasterPageFile="~/Admin.master"
    AutoEventWireup="true"
    CodeBehind="admin-accessories.aspx.cs"
    Inherits="YourProject.admin_accessories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">

    <h2>Admin - Accessories</h2>

    <asp:Label ID="lblMsg" runat="server" />
    <br /><br />

    <a href="admin-accessories-manage.aspx">Add New Accessory</a>

    <br /><br />

    <asp:GridView ID="gvAccessories"
        runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="ProductId"
        OnRowEditing="gvAccessories_RowEditing"
        OnRowCancelingEdit="gvAccessories_RowCancelingEdit"
        OnRowUpdating="gvAccessories_RowUpdating"
        OnRowDeleting="gvAccessories_RowDeleting">

        <Columns>
            <asp:BoundField DataField="ProductId" HeaderText="ID" ReadOnly="true" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:0.00}" />

            <asp:TemplateField HeaderText="ImagePath">
                <ItemTemplate>
                    <%# Eval("ImagePath") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtImagePath" runat="server" Text='<%# Bind("ImagePath") %>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
            <asp:TemplateField HeaderText="More">
                <ItemTemplate>
                    <a href='admin-accessories-manage.aspx?id=<%# Eval("ProductId") %>'>Upload/Change Image</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

</asp:Content>
