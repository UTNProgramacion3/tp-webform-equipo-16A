<%@ Page Title="Participar!" Language="C#" MasterPageFile="~/Pages/Main.Master" AutoEventWireup="true" CodeBehind="Participar.aspx.cs" Inherits="TPWeb_equipo_16A.Pages.Participar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="col-md-4" runat="server" id="ingreso_dni_container">
    <label for="dni" class="form-label">Ingresá documento para comenzar...</label>
      <input type="number" class="form-control" id="documento_inicial" placeholder="xx.xxx.xxx">
   <asp:Button class="btn btn-primary" ID="dni" runat="server" Text="Ingresá tu documento" OnClick="ValidarDniIngresado" />
  </div>

    <div id="failureCard" runat="server" class="card card-style body-card" visible="false">
    <div class="card-header header-failure-card-style">
        <div class="font-color">
            <p>
                <asp:Literal ID="Mensaje" runat="server" />
            </p>
        </div>
    </div>
    <div class="card-body body-failure-card-style">
        <h5 class="card-title"><asp:Literal ID="mensajeError" runat="server" /></h5>
        <p class="card-text">Por favor, vuelva a ingresar los datos para asignar el premio solicitado...</p>
    </div>
</div>

  <div class="col-md-4" id="participar_form" runat="server">
      <div>
        <label for="documento_validado" class="form-label">Documento</label>
        <asp:TextBox ID="documento_validado" runat="server" CssClass="form-control" TextMode="Number" />
        </div>
      <div>
        <label for="nombreCliente" class="form-label">Nombre</label>
        <input type="text" class="form-control" id="nombreCliente" value="Mark" required>
      </div>
      <div>
        <label for="validationCustom01" class="form-label">Apellido</label>
        <input type="text" class="form-control" id="apellidoCliente" value="Mark" required>
      </div>
       <div class="col-12">
    
 </div>
  </div>

     <div id="form_usuario_existente" runat="server">
        <div class="container mt-5">
            <h2>Detalles del Cliente</h2>
            <div class="mb-3">
                <label for="documento" class="form-label">Documento</label>
                <asp:TextBox ID="documento" runat="server" CssClass="form-control" Text='<%# Bind("Documento") %>'  />
            </div>
            <div class="mb-3">
                <label for="nombre" class="form-label">Nombre</label>
                <asp:TextBox ID="nombre" runat="server" CssClass="form-control" Text='<%# Bind("Nombre") %>'  />
            </div>
            <div class="mb-3">
                <label for="apellido" class="form-label">Apellido</label>
                <asp:TextBox ID="apellido" runat="server" CssClass="form-control" Text='<%# Bind("Apellido") %>'  />
            </div>
            <div class="mb-3">
                <label for="email" class="form-label">Email</label>
                <asp:TextBox ID="email" runat="server" CssClass="form-control" Text='<%# Bind("Email") %>'  />
            </div>
            <div class="mb-3">
                <label for="direccion" class="form-label">Dirección</label>
                <asp:TextBox ID="direccion" runat="server" CssClass="form-control" Text='<%# Bind("Direccion") %>'  />
            </div>
            <div class="mb-3">
                <label for="ciudad" class="form-label">Ciudad</label>
                <asp:TextBox ID="ciudad" runat="server" CssClass="form-control" Text='<%# Bind("Ciudad") %>'  />
            </div>
            <div class="mb-3">
                <label for="codigoPostal" class="form-label">Código Postal</label>
                <asp:TextBox ID="codigoPostal" runat="server" CssClass="form-control" Text='<%# Bind("CodigoPostal") %>'  />
            </div>
        </div>
    </div>

</asp:Content>
