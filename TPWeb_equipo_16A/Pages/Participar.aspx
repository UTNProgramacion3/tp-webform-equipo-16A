<%@ Page Title="Participar!" Language="C#" MasterPageFile="~/Pages/Main.Master" AutoEventWireup="true" CodeBehind="Participar.aspx.cs" Inherits="TPWeb_equipo_16A.Pages.Participar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="col-md-4" runat="server" id="DNI">
    <label for="validationCustom01" class="form-label">Ingresá documento</label>
    <input type="number" class="form-control" id="validationCustom01" placeholder="hola">
   <asp:Button class="btn btn-primary" ID="btnClickMe" runat="server" Text="Ingresá tu documento" OnClick="handleParticipar" />
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
     <%--<asp:Button class="btn btn-primary" type="button" runat="server">Participar!</asp:Button>--%>
 </div>
  </div>
 <%-- <div class="col-md-4">
    <label for="validationCustom02" class="form-label">Last name</label>
    <input type="text" class="form-control" id="validationCustom02" value="Otto" required>
    <div class="valid-feedback">
      Looks good!
    </div>
  </div>
  <div class="col-md-4">
    <label for="validationCustomUsername" class="form-label">Username</label>
    <div class="input-group has-validation">
      <span class="input-group-text" id="inputGroupPrepend">@</span>
      <input type="text" class="form-control" id="validationCustomUsername" aria-describedby="inputGroupPrepend" required>
      <div class="invalid-feedback">
        Please choose a username.
      </div>
    </div>
  </div>
  <div class="col-md-6">
    <label for="validationCustom03" class="form-label">City</label>
    <input type="text" class="form-control" id="validationCustom03" required>
    <div class="invalid-feedback">
      Please provide a valid city.
    </div>
  </div>
  <div class="col-md-3">
    <label for="validationCustom04" class="form-label">State</label>
    <select class="form-select" id="validationCustom04" required>
      <option selected disabled value="">Choose...</option>
      <option>...</option>
    </select>
    <div class="invalid-feedback">
      Please select a valid state.
    </div>
  </div>
  <div class="col-md-3">
    <label for="validationCustom05" class="form-label">Zip</label>
    <input type="text" class="form-control" id="validationCustom05" required>
    <div class="invalid-feedback">
      Please provide a valid zip.
    </div>
  </div>
  <div class="col-12">
    <div class="form-check">
      <input class="form-check-input" type="checkbox" value="" id="invalidCheck" required>
      <label class="form-check-label" for="invalidCheck">
        Agree to terms and conditions
      </label>
      <div class="invalid-feedback">
        You must agree before submitting.
      </div>
    </div>
  </div>--%>
 

</asp:Content>
