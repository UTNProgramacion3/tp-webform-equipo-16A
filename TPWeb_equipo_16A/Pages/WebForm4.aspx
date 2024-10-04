<%@ Page Title="Formulario de Carga de Datos" Language="C#" MasterPageFile="~/Pages/Main.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="TPWeb_equipo_16A.Pages.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Formulario de Carga de Datos</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h1>Carga de Datos</h1>
        <asp:Panel ID="PanelDNI" runat="server">
            <div class="mb-3">
                <label for="txtDNI" class="form-label">DNI:</label>
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI"
                    ErrorMessage="El DNI es requerido." CssClass="text-danger" />
                <asp:Button ID="btnVerificar" runat="server" Text="Verificar" CssClass="btn btn-primary mt-2" 
                    OnClick="btnVerificar_Click" />
            </div>
        </asp:Panel>

        <asp:Panel ID="PanelDatos" runat="server" Visible="false">
            <h3>Ingrese sus Datos</h3>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                    ErrorMessage="El nombre es requerido." CssClass="text-danger" />
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido:</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido"
                    ErrorMessage="El apellido es requerido." CssClass="text-danger" />
            </div>
            <div class="mb-3">
                <label for="txtDireccion" class="form-label">Dirección:</label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion"
                    ErrorMessage="La dirección es requerida." CssClass="text-danger" />
            </div>
            <asp:Button ID="btnParticipar" runat="server" Text="Participar!" CssClass="btn btn-success mt-2" 
                OnClick="btnParticipar_Click" />
        </asp:Panel>
    </div>
</asp:Content>
