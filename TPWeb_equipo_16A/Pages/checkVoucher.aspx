<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Main.Master" AutoEventWireup="true" CodeBehind="checkVoucher.aspx.cs" Inherits="TPWeb_equipo_16A.Pages.WebForm3"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="#" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col"></div>
        <div class="col">
            <div class="mb-3">
                <label for="formGroupExampleInput2" class="form-label">Codigo de Voucher</label>
                <input id="txtCodigoVoucher" type="text" runat="server" class="form-control" placeholder="Ingrese su codigo de Voucher...">
            </div>
            <div>
                <asp:Button Text="Cargar" class="btn btn-primary" OnClick="btnCargar_Click" runat="server" />
                <div id="successAlert" runat="server" class="alert alert-success" role="alert" visible="false">
                    El codigo de Voucher fue asignado correctamente
                </div>
                <div id="failureAlert" runat="server" class="alert alert-danger" role="alert" visible="false">
                    El codigo de Voucher es invalido o ya fue utilizado
                </div>
            </div>
        </div>
        <div class="col"></div>
    </div>


</asp:Content>
