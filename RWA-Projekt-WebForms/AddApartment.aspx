<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="AddApartment.aspx.cs" Inherits="RWA_Projekt_WebForms.AddApartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container">
        <fieldset class="p-4">
            <legend>Create apartment</legend>
            <div class="mb-3">
                <asp:Label ID="lblName" for="txtName" class="form-label" runat="server" Text="Name"></asp:Label>
                <asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red">* Niste upisali naziv</asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblCity" for="ddlCity" class="form-label" runat="server" Text="City"></asp:Label>
                <asp:DropDownList ID="ddlCity" class="form-control" runat="server"></asp:DropDownList>

            </div>
            <div class="mb-3">
                <asp:Label ID="lblOwners" for="ddlOwners" class="form-label" runat="server" Text="Owner"></asp:Label>
                <asp:DropDownList ID="ddlOwners" class="form-control" runat="server"></asp:DropDownList>

            </div>
            <div class="mb-3">
                <asp:Label ID="lblAddress" for="txtAddress" class="form-label" runat="server" Text="Address"></asp:Label>
                <asp:TextBox ID="txtAddress" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAddress" Display="Dynamic" ForeColor="Red">* Niste upisali adresu</asp:RequiredFieldValidator>
            </div>

            <div class="mb-3">
                <asp:Label ID="lblMaxAdults" for="txtMaxAdults" class="form-label" runat="server" Text="Max Adults"></asp:Label>
                <asp:TextBox ID="txtMaxAdults" type="number" class="form-control" min="0" max="10000" step="1" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMaxAdults" Display="Dynamic" ForeColor="Red">* This field is required and cannot be empty</asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblMaxChild" for="txtMaxChild" class="form-label" runat="server" Text="Max Children"></asp:Label>
                <asp:TextBox ID="txtMaxChild" type="number" class="form-control" min="0" max="10000" step="1" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMaxChild" Display="Dynamic" ForeColor="Red">* This field is required and cannot be empty</asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblTotalRooms" for="txtTotalRooms" class="form-label" runat="server" Text="Total Rooms"></asp:Label>
                <asp:TextBox ID="txtTotalRooms" type="number" class="form-control" min="1" max="10000" step="1" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTotalRooms" Display="Dynamic" ForeColor="Red">* This field is required and cannot be empty</asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblPrice" for="txtPrice" class="form-label" runat="server" Text="Price (kn)"></asp:Label>
                <asp:TextBox ID="txtPrice" type="number" min="1" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPrice" Display="Dynamic" ForeColor="Red">* This field is required and cannot be empty</asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblStatus" for="ddlStatus" class="form-label" runat="server" Text="Status"></asp:Label>
                <asp:DropDownList ID="ddlStatus" class="form-control" runat="server"></asp:DropDownList>

            </div>
            <div class="mb-3">
                <asp:Label ID="lblBeachDistance" for="txtBeachDistance" class="form-label" runat="server" Text="Beach Distance (m)"></asp:Label>
                <asp:TextBox ID="txtBeachDistance" type="number" min="1" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtBeachDistance" Display="Dynamic" ForeColor="Red">* This field is required and cannot be empty</asp:RequiredFieldValidator>
            </div>
            <asp:Button ID="createApartment" class="btn btn-primary" runat="server" Text="Create" OnClick="createApartment_Click" />
        </fieldset>
    </div>
</asp:Content>
