<%@ Page Language="C#" AutoEventWireup="true" CodeFile="selaa.aspx.cs" Inherits="tuntikirjanpito_selaa" MasterPageFile="~/T3_Master.master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <h2>Kirjaukset</h2>
    <p>Käyttäjä: <asp:DropDownList ID="ddUser" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddUser_SelectedIndexChanged"></asp:DropDownList></p>
    <asp:GridView ID="gridKirjaukset" runat="server"></asp:GridView>
    <p><asp:Label id="labelTunnit" runat="server" Text="Tunnit yhteensä: " > </asp:Label></p>
</asp:Content>