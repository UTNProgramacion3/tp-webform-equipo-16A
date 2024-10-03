<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Main.Master" AutoEventWireup="true" CodeBehind="checkVoucher.aspx.cs" Inherits="TPWeb_equipo_16A.Pages.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-3"></div>
        <div class="col">
        <div class="mb-3">
            <label for="formGroupExampleInput" class="form-label">Nombre</label>
            <input type="text" class="form-control" id="txtNombre" placeholder="Ingrese Nombre...">
        </div>
        <div class="mb-3">
            <label for="formGroupExampleInput2" class="form-label">Apellido</label>
            <input type="text" class="form-control" id="txtApellido" placeholder="Ingrese Apellido...">
        </div>
        <div class="mb-3">
            <label for="formGroupExampleInput2" class="form-label">DNI</label>
            <input type="text" class="form-control" id="txtDNI" placeholder="Ingrese DNI...">
        </div>
        <div class="mb-3">
            <label for="formGroupExampleInput2" class="form-label">Codigo de Voucher</label>
            <input type="text" class="form-control" id="txtCodigoVoucher" placeholder="Ingrese su codigo de Voucher...">
        </div>
        </div>
        <div class="col-3"></div>
    </div>


</asp:Content>
