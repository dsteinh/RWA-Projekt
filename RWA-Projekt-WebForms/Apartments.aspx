<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Apartments.aspx.cs" Inherits="RWA_Projekt_WebForms.Apartments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container">
        <div class="container p-4">

            <div class="row">
                <div class="col-nd-6">
                    <div class="d-flex align-items-end mb-2 mt-2">
                        <fieldset class="p-4 w-25 gap-1 d-flex align-items-end">
                            <legend>Filters</legend>
                            <div class="w-50">
                                <asp:Label ID="lblCity" for="ddlCity" class="form-label " runat="server" Text="City"></asp:Label>
                                <asp:DropDownList class="form-control " AutoPostBack="true" ID="ddlCity" runat="server" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="w-50">
                                <asp:Label ID="lblStatus" for="ddlStatus" class="form-label" runat="server" Text="Status"></asp:Label>
                                <asp:DropDownList class="form-control " AutoPostBack="true" ID="ddlStatus" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </fieldset>
                        <asp:Button ID="addApartment" class="btn btn-primary h-25 m-2" runat="server" Text="New Apartment" OnClick="addApartment_Click" />
                    </div>
                    <asp:Repeater ID="rptApartments" runat="server" OnItemCommand="rptApartments_ItemCommand">
                        <HeaderTemplate>

                            <table id="myTable" class="table">
                                <thead>
                                    <tr>
                                        <th id="id">Id</th>
                                        <th class="filter" scope="col">Name</th>
                                        <th class="filter" scope="col">City</th>
                                        <th class="filter" scope="col">Address</th>
                                        <th class="filter" scope="col">MaxAdults</th>
                                        <th class="filter" scope="col">MaxChildren</th>
                                        <th class="filter" scope="col">TotalRooms</th>
                                        <th class="filter" scope="col">Price</th>
                                        <th class="filter" scope="col">Owner</th>
                                        <th class="filter" scope="col">Status</th>
                                        <th class="filter" scope="col">BeachDistance</th>
                                        <th id="edit"></th>
                                        <th id="delete"></th>
                                    </tr>

                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval(nameof(rwaLib.Models.Apartment.Id)) %></td>
                                <td><%#Eval(nameof(rwaLib.Models.Apartment.Name)) %></td>
                                <td><%#Eval(nameof(rwaLib.Models.Apartment.City)) %></td>
                                <td><%#Eval(nameof(rwaLib.Models.Apartment.Address)) %></td>
                                <td><%#Eval(nameof(rwaLib.Models.Apartment.MaxAdults)) %></td>
                                <td><%#Eval(nameof(rwaLib.Models.Apartment.MaxChildren)) %></td>
                                <td><%#Eval(nameof(rwaLib.Models.Apartment.TotalRooms)) %></td>
                                <td><%#Eval(nameof(rwaLib.Models.Apartment.Price)) %></td>
                                <td><%#Eval(nameof(rwaLib.Models.Apartment.Owner)) %></td>
                                <td><%#Eval(nameof(rwaLib.Models.Apartment.Status)) %></td>
                                <td><%#Eval(nameof(rwaLib.Models.Apartment.BeachDistance)) %></td>
                                <td><a href="Edit.aspx?id=<%#Eval(nameof(rwaLib.Models.Apartment.Id))%>&city=<%#Eval(nameof(rwaLib.Models.Apartment.City))%>&status=<%#Eval(nameof(rwaLib.Models.Apartment.Status))%>">Edit</td>
                                <td>
                                    <asp:LinkButton ID="LinkButton1" OnClientClick="return confirm('Are you sure?')" CommandArgument="<%#Eval(nameof(rwaLib.Models.Apartment.Id))%>" runat="server">Delete</asp:LinkButton>

                                </td>

                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                    </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="col-nd-6">
                    <%//GridView %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


