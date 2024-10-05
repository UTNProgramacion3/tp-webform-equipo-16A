<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Main.Master" AutoEventWireup="true" CodeBehind="priceResult.aspx.cs" Inherits="TPWeb_equipo_16A.Pages.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="/Content/Styles/card-styles.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <div class="row">
            <div class="col"></div>
            <div class="col">
                <div>
                    <div id="successCard" runat="server" class="card card-style body-card" visible="false">
                        <div class="card-header header-success-card-style">
                            <div class="font-color">
                                Premio asignado correctamente
                            </div>
                        </div>
                        <div class="card-body body-success-card-style">
                            <h5 class="card-title">¡ Muchas gracias por participar !</h5>
                            <p class="card-text">Una vez finalizado el sorteo informaremos por nuestras redes al ganador/a de nuestro sorteo.</p>
                        </div>
                    </div>
                </div>

                <div>
                    <div id="failureCard" runat="server" class="card card-style body-card" visible="false">
                        <div class="card-header header-failure-card-style">
                            <div class="font-color">
                                Premio no asignado
                            </div>
                        </div>
                        <div class="card-body body-failure-card-style">
                            <h5 class="card-title">¡ Error al asignar el premio !</h5>
                            <p class="card-text">Por favor, vuelva a ingresar los datos para asignar el premio solicitado...</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col"></div>
        </div>
    </div>
</asp:Content>
