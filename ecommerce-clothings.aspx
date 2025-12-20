<%@ Page Title="Clothings - "
    Language="C#"
    MasterPageFile="~/ecommerce.master"
    AutoEventWireup="true"
    CodeBehind="ecommerce-clothings.aspx.cs"
    Inherits="YourProject.ecommerce_clothings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Clothings</h2>
    <asp:Label ID="lblMsg" runat="server" />
    <br /><br />

    <asp:DataList ID="dlClothings"
        runat="server"
        RepeatColumns="4"
        RepeatDirection="Horizontal"
        CellPadding="10"
        OnItemCommand="dlClothings_ItemCommand">

        <ItemTemplate>
            <fieldset>
                <legend>Item</legend>

                <asp:Image ID="imgProduct"
                    runat="server"
                    ImageUrl='<%# Eval("ImagePath") %>'
                    Width="150"
                    Height="150" />

                <br /><br />

                <b><%# Eval("Name") %></b>
                <br />
                $<%# Eval("Price", "{0:0.00}") %>

                <br /><br />

                <asp:LinkButton ID="btnAdd"
                    runat="server"
                    Text="Add"
                    CommandName="AddToCart"
                    CommandArgument='<%# Eval("ProductId") %>' />
            </fieldset>
        </ItemTemplate>

    </asp:DataList>

</asp:Content>
