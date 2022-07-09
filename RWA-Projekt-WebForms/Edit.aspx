<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="RWA_Projekt_WebForms.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <style>
        .tag {
            width: 110px;
            display: inline-block;
            margin: 2px;
            border-radius: 5px;
            padding: 1px;
            background-color: dimgray;
            font-size: small;
            text-align: center;
            color: white;
            font-weight: bold;
            font-family: Calibri;
            display: flex;
            justify-content: right;
            align-items: center
        }

            .tag:hover {
                width: 110px;
                display: inline-block;
                margin: 2px;
                border-radius: 5px;
                padding: 1px;
                background-color: lightgray;
                font-size: small;
                text-align: center;
                color: white;
                font-weight: bold;
                font-family: Calibri;
                display: flex;
                justify-content: right;
                align-items: center
            }

        .flex {
            display: flex;
        }
    </style>
    <div class="container p-4">
        <div>
            <fieldset class="p-4">
                <legend>Tags</legend>

                <asp:Repeater ID="rptTags" runat="server" OnItemCommand="rptTags_ItemCommand">
                    <HeaderTemplate>
                        <div class="flex" style="overflow-x: scroll">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="tag">
                            <asp:Label ID="Label1" runat="server" Text='<%#$"{Eval(nameof(rwaLib.Models.Tag.NameEng))}" %>'></asp:Label>
                            <asp:Button ID="btnRemoveTag" OnClientClick="return confirm('Are you sure?')" CssClass="btn-close" runat="server" CommandArgument='<%#$"{Eval(nameof(rwaLib.Models.Tag.Id))}" %>' />
                        </div>



                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
                <hr class="solid">
                <asp:Button ID="btnAddTag" class="btn btn-primary" runat="server" Text="Add" OnClick="btnAddTag_Click" />
                <asp:DropDownList ID="ddlTags" runat="server"></asp:DropDownList>
            </fieldset>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <div class="form-group">
                    <div class="form-group">
                        <fieldset class="p-4">
                            <legend>Reservations</legend>
                            <asp:Repeater ID="rptReservations" runat="server" OnItemCommand="editReservation_Click">
                                <HeaderTemplate>

                                    <table id="myTable" class="table">
                                        <thead>
                                            <tr>
                                                <th scope="col">Details</th>
                                                <th scope="col">Reserved by</th>
                                                <th scope="col"></th>
                                            </tr>

                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval(nameof(rwaLib.Models.ApartmentReservation.Details)) %></td>
                                        <td><%#Eval(nameof(rwaLib.Models.ApartmentReservation.FullName)) %></td>
                                        <td>
                                            <asp:LinkButton ID="btnEditReservation" CommandArgument="<%#Eval(nameof(rwaLib.Models.ApartmentReservation.Id))%>" runat="server">Edit</asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                    </table>
                                </FooterTemplate>
                            </asp:Repeater>

                        </fieldset>
                    </div>
                    <fieldset class="p-4">
                        <legend>Edit Pictures</legend>
                        <div class="mb-3">
                            <asp:Label ID="lblMainPhoto" for="ddlMainPhoto" class="form-label" runat="server" Text="Select main photo"></asp:Label>
                            <asp:DropDownList ID="ddlMainPhoto" AutoPostBack="True" class="form-control" runat="server" OnSelectedIndexChanged="ddlMainPhoto_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="container">
                            <asp:Repeater ID="rptPictures" runat="server" OnItemCommand="DeletePicture_ItemCommand">
                                <HeaderTemplate>

                                    <table id="myTable3" class="table">
                                        <thead>
                                            <tr>
                                                <th scope="col"></th>
                                            </tr>

                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <%--<%#Eval(nameof(rwaLib.Models.ApartmentPicture.Base64Content))%>--%>
                                        <td><%#Eval(nameof(rwaLib.Models.ApartmentPicture.Name)) %></td>
                                        <td>
                                            <asp:Image ID="Image1" CssClass="img-thumbnail" Width="307" Height="240" src='<%#$"{Eval(nameof(rwaLib.Models.ApartmentPicture.Base64Content))}"%>' runat="server" />
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="btnDelete" OnClientClick="return confirm('Are you sure?')" CommandArgument="<%#Eval(nameof(rwaLib.Models.ApartmentPicture.Id))%>" runat="server">Delete</asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                        <asp:FileUpload ID="FileUpload1" accept=".png,.jpg,.jpeg,.gif" class="btn btn-light" runat="server" />
                        <asp:Button ID="btnAddPicture" class="btn btn-primary" runat="server" Text="Add" OnClick="btnAddPicture_Click" />
                    </fieldset>

                </div>
            </div>

            <div class="col-sm-6">
                <fieldset class="p-4">
                    <legend>Edit apartment</legend>
                    <asp:Label ID="lblResult" runat="server" CssClass="alert alert-danger d-block w-100"></asp:Label>
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
                        <asp:Label ID="lblAddress" for="txtAddress" class="form-label" runat="server" Text="Address"></asp:Label>
                        <asp:TextBox ID="txtAddress" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAddress" Display="Dynamic" ForeColor="Red">* Niste upisali adresu</asp:RequiredFieldValidator>
                    </div>

                    <div class="mb-3">
                        <asp:Label ID="lblMaxAdults" for="txtMaxAdults" class="form-label" runat="server" Text="Max Adults"></asp:Label>
                        <asp:TextBox ID="txtMaxAdults" type="number" class="form-control" min="0" max="10000" step="1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMaxAdults" Display="Dynamic" ForeColor="Red">* This field is required and cannot be empty</asp:RequiredFieldValidator>

                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblMaxChild" for="txtMaxChild" class="form-label" runat="server" Text="Max Children"></asp:Label>
                        <asp:TextBox ID="txtMaxChild" type="number" class="form-control" min="0" max="10000" step="1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMaxChild" Display="Dynamic" ForeColor="Red">* This field is required and cannot be empty</asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblTotalRooms" for="txtTotalRooms" class="form-label" runat="server" Text="Total Rooms"></asp:Label>
                        <asp:TextBox ID="txtTotalRooms" type="number" class="form-control" min="1" max="10000" step="1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTotalRooms" Display="Dynamic" ForeColor="Red">* This field is required and cannot be empty</asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblPrice" for="txtPrice" class="form-label" runat="server" Text="Price (kn)"></asp:Label>
                        <asp:TextBox ID="txtPrice" type="number" min="1" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPrice" Display="Dynamic" ForeColor="Red">* This field is required and cannot be empty</asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblStatus" for="ddlStatus" class="form-label" runat="server" Text="Status"></asp:Label>
                        <asp:DropDownList ID="ddlStatus" AutoPostBack="True" class="form-control" runat="server"></asp:DropDownList>

                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblBeachDistance" for="txtBeachDistance" class="form-label" runat="server" Text="Beach Distance (m)"></asp:Label>
                        <asp:TextBox ID="txtBeachDistance" type="number" min="1" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtBeachDistance" Display="Dynamic" ForeColor="Red">* This field is required and cannot be empty</asp:RequiredFieldValidator>
                    </div>
                    <asp:Button ID="updateApartment" class="btn btn-primary" runat="server" Text="Update" OnClick="updateApartment_Click" />
                </fieldset>
            </div>


        </div>
    </div>
</asp:Content>
