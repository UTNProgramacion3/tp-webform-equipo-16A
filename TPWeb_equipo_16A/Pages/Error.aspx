<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Main.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPWeb_equipo_16A.Pages.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f8f8;
            text-align: center;
            padding: 50px;
        }
        .error-container {
            background-color: #fff;
            border: 1px solid #ddd;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            display: inline-block;
        }
        h1 {
            color: #d9534f;
        }
        p {
            color: #333;
        }
        .stack-trace {
            margin-top: 20px;
            background-color: #f0f0f0;
            border-radius: 5px;
            padding: 15px;
            text-align: left;
            font-size: 0.9em;
            color: #555;
            word-break: break-all;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="error-container">
            <h1>Oops! Something went wrong.</h1>
            <p>We're sorry, but an unexpected error has occurred. Please try again later.</p>

            <!-- Mostramos el mensaje de error y el StackTrace solo si están presentes -->
            <asp:Literal ID="litErrorMessage" runat="server" />
            <asp:Literal ID="litStackTrace" runat="server" CssClass="stack-trace" />

            <br />
            <a href="~/Pages/Participar.aspx">Go back</a>
        </div>

</asp:Content>
