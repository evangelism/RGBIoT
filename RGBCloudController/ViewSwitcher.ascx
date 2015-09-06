<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewSwitcher.ascx.cs" Inherits="RGBCloudController.ViewSwitcher" %>
<div id="viewSwitcher">
    <%: CurrentView %> view | <a href="<%: SwitchUrl %>" data-ajax="false">Switch to <%: AlternateView %></a>
</div>