<%@ Page Title="Accessories - "
    Language="C#"
    MasterPageFile="~/ecommerce.master"
    AutoEventWireup="true"
    CodeBehind="ecommerce-accessories.aspx.cs"
    Inherits="YourProject.ecommerce_accessories" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Accessories</h2>

    <asp:Label ID="lblMsg" runat="server" />

    <br /><br />

    <!-- GRID OF ITEMS (NO CSS) -->
    <asp:DataList ID="dlAccessories"
        runat="server"
        RepeatColumns="4"
        RepeatDirection="Horizontal"
        CellPadding="10"
        OnItemCommand="dlAccessories_ItemCommand">

        <ItemTemplate>
            <fieldset>
                <legend>Item</legend>

                <!-- Product Image -->
                <asp:Image ID="imgProduct"
                    runat="server"
                    ImageUrl='<%# Eval("ImagePath") %>'
                    Width="150"
                    Height="150" />

                <br /><br />

                <!-- Product Name -->
                <b><%# Eval("Name") %></b>
                <br />

                <!-- Product Price -->
                $<%# Eval("Price", "{0:0.00}") %><br /><br /><!-- Add to Cart --><asp:LinkButton ID="btnAdd"
                    runat="server"
                    Text="Add"
                    CommandName="AddToCart"
                    CommandArgument='<%# Eval("ProductId") %>' />
            </fieldset>
        </ItemTemplate>

    </asp:DataList>

</asp:Content>
