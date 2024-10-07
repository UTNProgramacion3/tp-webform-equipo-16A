<%@ Page Title="Participar!" Language="C#" MasterPageFile="~/Pages/Main.Master" AutoEventWireup="true" CodeBehind="Participar.aspx.cs" Inherits="TPWeb_equipo_16A.Pages.Participar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container mt-5">
    <div class="row justify-content-center">

<%-- Inicio número de DNI pre-validación: --%>
  <div class="col-md-4 container" runat="server" id="ingreso_dni_container">
    <label for="dni" class="form-label">Ingresá documento para comenzar...</label>
      <asp:TextBox  TextMode="Number" CssClass="form-control mb-3" ID="documento_inicial" placeholder="12345678" runat="server"/>
   <asp:Button class="btn btn-primary" ID="dni" runat="server" Text="Ingresá tu documento" OnClick="ValidarDniIngresado" />
  </div>
    <%-- Fin validación número de DNI --%>

    <%-- Error en dni cargado: --%>
    <div id="failureCard" runat="server" class="card card-style body-card" visible="false">
    <div class="card-header header-failure-card-style">
        <div class="font-color">
            <p>
                <asp:Literal ID="Mensaje" runat="server" />
            </p>
        </div>
    </div>
    <div class="card-body body-failure-card-style">
        <h5 class="card-title">
            <asp:Literal ID="mensajeError" runat="server" />
        </h5>
        <p class="card-text">
            <asp:Literal ID="contentError" runat="server" />

        </p>
    </div>
</div>
    <%-- Fin error en dni cargado --%>

    <%-- Inicio formulario para participar: --%>
<div class="col-md-4" id="ingresar_datos_manual" runat="server">
    <div class="container mt-5">
        <div>

        <label for="documentoCliente" class="form-label">Documento</label>
        <asp:TextBox ID="documentoCliente" runat="server" CssClass="form-control" />
    </div>
    <div>
        <label for="nombreCliente" class="form-label">Nombre</label>
        <asp:TextBox ID="nombreCliente" runat="server" CssClass="form-control" required="required" />
    </div>
    <div>
        <label for="apellidoCliente" class="form-label">Apellido</label>
        <asp:TextBox ID="apellidoCliente" runat="server" CssClass="form-control" required="required" />
    </div>
    <div>
        <label for="emailCliente" class="form-label">Email</label>
        <asp:TextBox ID="emailCliente" runat="server" CssClass="form-control" TextMode="Email" required="required" />
    </div>
    <div>
        <label for="direccionCliente" class="form-label">Dirección</label>
        <asp:TextBox ID="direccionCliente" runat="server" CssClass="form-control" required="required" />
    </div>
    <div>
        <label for="ciudadCliente" class="form-label">Ciudad</label>
        <asp:TextBox ID="ciudadCliente" runat="server" CssClass="form-control" required="required" />
    </div>
    <div>
        <label for="codigoPostalCliente" class="form-label">Código Postal</label>
        <asp:TextBox ID="codigoPostalCliente" runat="server" CssClass="form-control" TextMode="Number" required="required" />
    </div>
    <div class="col-12">
        <asp:Button ID="btnSubmit" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
    </div>
</div>
    
 </div>
  </div>
    <%-- Fin formulario para participar --%>

    <%-- Inicio formulario con datos pre-cargados: --%>
     <div id="form_usuario_existente" runat="server">
        <div class="container mt-5">
            <h2>Detalles del Cliente</h2>
            <div class="mb-3">
                <label for="documento" class="form-label">Documento</label>
                <asp:TextBox ID="documento_validado" runat="server" CssClass="form-control" Enabled="false" Text='<%# Bind("Documento") %>'  />
            </div>
            <div class="mb-3">
                <label for="nombre" class="form-label">Nombre</label>
                <asp:TextBox ID="nombre" runat="server" CssClass="form-control" Text='<%# Bind("Nombre") %>' Enabled="false" />
            </div>
            <div class="mb-3">
                <label for="apellido" class="form-label">Apellido</label>
                <asp:TextBox ID="apellido" runat="server" CssClass="form-control" Text='<%# Bind("Apellido") %>' Enabled="false" />
            </div>
            <div class="mb-3">
                <label for="email" class="form-label">Email</label>
                <asp:TextBox ID="email" runat="server" CssClass="form-control" Text='<%# Bind("Email") %>' Enabled="false" />
            </div>
            <div class="mb-3">
                <label for="direccion" class="form-label">Dirección</label>
                <asp:TextBox ID="direccion" runat="server" CssClass="form-control" Text='<%# Bind("Direccion") %>' Enabled="false" />
            </div>
            <div class="mb-3">
                <label for="ciudad" class="form-label">Ciudad</label>
                <asp:TextBox ID="ciudad" runat="server" CssClass="form-control" Text='<%# Bind("Ciudad") %>' Enabled="false" />
            </div>
            <div class="mb-3">
                <label for="codigoPostal" class="form-label">Código Postal</label>
                <asp:TextBox ID="codigoPostal" runat="server" CssClass="form-control" Text='<%# Bind("CodigoPostal") %>' Enabled="false"  />
            </div>
            <div class="col-12">
    <asp:Button ID="confirmarYParticipar" runat="server" Text="Participar!" CssClass="btn btn-primary" OnClick="ConfirmarDatosYParticipar" />
</div>
        </div>
         <%-- Fin formulario con datos pre-cargados --%>
    </div>
        </div>
    </div>
    </div>

</asp:Content>
