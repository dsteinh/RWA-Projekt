<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="EditReservation.aspx.cs" Inherits="RWA_Projekt_WebForms.EditReservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container p-2">
        <fieldset class="p-4">
            <legend>Edit Reservation</legend>
            <div class="mb-3">
                <asp:Label ID="lblDetails" for="txtDetails" class="form-label" runat="server" Text="Details"></asp:Label>
                <asp:TextBox ID="txtDetails" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDetails" Display="Dynamic" ForeColor="Red">* This field is required and cannot be empty</asp:RequiredFieldValidator>
            </div>
            <asp:Panel ID="RegPanel" runat="server">
                <div class="mb-3">
                    <asp:Label ID="lblRegisterUsers" for="ddlRegisterUsers" class="form-label" runat="server" Text="User"></asp:Label>
                    <asp:DropDownList ID="ddlRegisterUsers" class="form-control" runat="server"></asp:DropDownList>

                </div>
            </asp:Panel>
            <asp:Panel ID="UnregPanel" runat="server">
                <fieldset class="p-4 mb-2">
                    <legend>Unregistered user</legend>
                    <div class="mb-3">
                        <asp:Label ID="lblUnregUser" for="txtUnregUser" class="form-label" runat="server" Text="Username"></asp:Label>
                        <asp:TextBox ID="txtUnregUser" class="form-control" runat="server"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUnregUser" Display="Dynamic" ForeColor="Red">* Niste upisali naziv</asp:RequiredFieldValidator>--%>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblEmail" for="txtEmail" class="form-label" runat="server" Text="Email"></asp:Label>
                        <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red">* Niste upisali naziv</asp:RequiredFieldValidator>--%>
                    </div>
                </fieldset>
            </asp:Panel>
            <asp:Button ID="updateReservation" class="btn btn-primary" runat="server" Text="Update" OnClick="updateReservation_Click" />
        </fieldset>
    </div>
</asp:Content>
