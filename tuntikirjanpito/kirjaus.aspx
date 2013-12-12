<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kirjaus.aspx.cs" Inherits="tuntikirjanpito_kirjaus" MasterPageFile="~/T3_Master.master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <p>
        Nimi: <asp:TextBox ID="tbName" TextMode="SingleLine" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="nameValidator" runat="server" ControlToValidate="tbName" ErrorMessage="Pakollinen tieto!"></asp:RequiredFieldValidator>
         <br />
        Päivämäärä: <asp:TextBox ID="tbDate" TextMode="Date" runat="server"></asp:TextBox>

         <asp:RegularExpressionValidator ID="dateValidator" runat="server" ErrorMessage="Anna päivämäärä oikeassa muodossa!" ControlToValidate="tbDate"  ValidationExpression="(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[012])\.(19|20)\d\d"></asp:RegularExpressionValidator>

    </p>

    <p>
        Koodasin <asp:TextBox ID="tbHours" TextMode="Number" runat="server" Width="40"></asp:TextBox> tuntia ja 
        <asp:TextBox ID="tbMinutes" TextMode="Number" runat="server" Width="40"></asp:TextBox> minuuttia

        <asp:RangeValidator ControlToValidate="tbHours" ID="hoursValdidator" runat="server" ErrorMessage="Anna tunnit väliltä 0-24" MaximumValue="24" MinimumValue="0"></asp:RangeValidator>
        <asp:RangeValidator ControlToValidate="tbMinutes" ID="minutesValidator" runat="server" ErrorMessage="Anna minuutit väliltä 0-59" MaximumValue="59" MinimumValue="0"></asp:RangeValidator>
    </p>

    <asp:Button ID="btnSave" runat="server" Text="Tallenna kirjaus" OnClick="btnSave_Click" />
    <p><asp:Label ID="LabelInfo" runat="server" Text=""></asp:Label></p>
</asp:Content>
