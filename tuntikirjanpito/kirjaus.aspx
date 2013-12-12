<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kirjaus.aspx.cs" Inherits="tuntikirjanpito_kirjaus" MasterPageFile="~/T3_Master.master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">


    <p>
    Nimi: <asp:TextBox ID="tbName" runat="server"></asp:TextBox> <br />
    Päivämäärä: <asp:TextBox ID="tbDate" runat="server"></asp:TextBox>
        </p>
    <p>
    Koodasin <asp:TextBox ID="tbHours" runat="server" Width="40"></asp:TextBox> tuntia ja 
    <asp:TextBox ID="tbMinutes" runat="server" Width="40"></asp:TextBox> minuuttia
</p>

    <asp:Button ID="btnSave" runat="server" Text="Tallenna kirjaus" OnClick="btnSave_Click" />

    <p><asp:Label ID="LabelInfo" runat="server" Text=""></asp:Label></p>

</asp:Content>
