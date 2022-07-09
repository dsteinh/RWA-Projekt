<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="NewTag.aspx.cs" Inherits="RWA_Projekt_WebForms.NewTag" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <fieldset class="container p-4">
        <legend>Create Tag</legend>
        <div class="mb-3">
            <asp:Label ID="lblTagName" for="txtTagName" class="form-label" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="txtTagName" type="text" class="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTagName" Display="Dynamic" ForeColor="Red">* This field is required and cannot be empty</asp:RequiredFieldValidator>

        </div>
        <div class="mb-3">
            <asp:Label ID="lblTagType" for="ddlTagType" class="form-label" runat="server" Text="Tag Type"></asp:Label>
            <asp:DropDownList ID="ddlTagType" AutoPostBack="True" class="form-control" runat="server"></asp:DropDownList>
        </div>
        <asp:Button ID="updateApartment" class="btn btn-primary" runat="server" Text="Create" OnClick="createTag_Click" />
    </fieldset>
</asp:Content>
