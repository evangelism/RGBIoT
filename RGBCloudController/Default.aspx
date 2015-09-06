<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RGBCloudController._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Управляйте светодиодом!</h1>
        <p class="lead">Это замечательное приложение позволяет вам управлять светодиодом. Нажимайте клавиши, чтобы голосовать за тот или иной цвет!</p>
    </div>

    <asp:Button ID="red" runat="server" Text="Red" BackColor="Red" Width="200" OnClick="BtnClick" />
    <asp:Button ID="green" runat="server" Text="Green" BackColor="Green" OnClick="BtnClick" Width="200" />
    <asp:Button ID="blue" runat="server" Text="Blue" BackColor="Blue" Width="200" OnClick="BtnClick"/>

    <p><asp:Label ID="status" runat="server" /></p>

</asp:Content>
