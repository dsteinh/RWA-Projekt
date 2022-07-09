<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="RWA_Projekt_WebForms.Tags" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container p-2">
        <div class="col mb-2 mt-2">
            <asp:Button ID="addTag" class="btn btn-primary" runat="server" Text="New Tag" OnClick="addTag_Click" />
        </div>
        <asp:Repeater ID="rptTags" runat="server" OnItemCommand="rptTags_ItemCommand">
            <HeaderTemplate>

                <table id="myTable" class="table">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Tag</th>
                            <th class="filter" scope="col">Type</th>
                            <th class="filter" scope="col">ApartmentsUsing</th>
                            <th class="filter" scope="col"></th>
                        </tr>

                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval(nameof(rwaLib.Models.Tag.Id)) %></td>
                    <td><%#Eval(nameof(rwaLib.Models.Tag.NameEng)) %></td>
                    <td><%#Eval(nameof(rwaLib.Models.Tag.Type)) %></td>
                    <td><%#Eval(nameof(rwaLib.Models.Tag.ApartmentsUsing)) %></td>
                    <td>
                        <asp:LinkButton ID="HyperLink1" OnClientClick="return confirm('Are you sure?')" Visible='<%# IsApartmentsUsingZero(Eval(nameof(rwaLib.Models.Tag.ApartmentsUsing))) %>' CommandArgument="<%#Eval(nameof(rwaLib.Models.Tag.Id))%>" runat="server">Delete</asp:LinkButton>

                    </td>

                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>


    </div>
</asp:Content>
