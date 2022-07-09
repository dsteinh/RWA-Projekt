<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="RWA_Projekt_WebForms.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container">
        <asp:Repeater ID="rptUsers" runat="server">
            <HeaderTemplate>

                <table id="myTable" class="table">
                    <thead>
                        <tr>
                            <th id="id">Id</th>
                            <th class="filter" scope="col">UserName</th>
                        </tr>

                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval(nameof(rwaLib.Models.User.Id)) %></td>
                    <td><%#Eval(nameof(rwaLib.Models.User.Username)) %></td>

                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
