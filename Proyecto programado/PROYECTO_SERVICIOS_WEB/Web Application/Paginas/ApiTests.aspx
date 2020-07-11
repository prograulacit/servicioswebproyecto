<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/SesionAnonimo.Master" AutoEventWireup="true" CodeBehind="ApiTests.aspx.cs" Inherits="Web_Application.Paginas.ApiTests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <form action="ApiTests.aspx" method="post">
        <label for="fname">First name:</label><br>
        <input type="text" id="fname" name="fname" value="John"><br>
        <label for="lname">Last name:</label><br>
        <input type="text" id="lname" name="lname" value="Doe"><br>
        <br>
        <input type="submit" value="Submit">
    </form>

    <script>

    </script>

</asp:Content>
