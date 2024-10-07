<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Main.Master" AutoEventWireup="true" CodeBehind="Rewards.aspx.cs" Inherits="TPWeb_equipo_16A.Pages.Rewards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-container {
            display: grid;
            grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
            gap: 20px;
        }

        .card {
            margin-bottom: 20px;
            margin-left: 50px;
            border-radius: 5px;
            overflow: hidden;
            transition: transform 0.3s ease 0.1s;
        }

            .card:hover {
                transform: scale(1.05);
            }

            .card img {
                width: auto;
                height: 300px;
            }

        .select-button {
            margin: 10px;
            padding: 10px 15px;
            background-color: #0094ff;
            border: none;
            border-radius: 5px;
            color: #fff;
            cursor: pointer;
            transition: background-color 0.3s ease 0.1s;
            transition: color 0.3s ease 0.1s;
        }

            .select-button:hover {
                background-color: whitesmoke;
                color: #0094ff;
            }
    </style>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card-container">
        <asp:Repeater runat="server" ID="repRepeater" OnItemDataBound="repRepeater_ItemDataBound">
            <ItemTemplate>
                <div class="card" style="width: 300px; margin-bottom: 20px;">
                    <h3><%# Eval("Articulo.Nombre") %></h3>

                    <!-- Carrusel de imágenes -->
            <div id="carousel<%# Eval("Articulo.Id") %>" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-inner">
                    <asp:Repeater runat="server" ID="repImagenes">
                        <ItemTemplate>
                            <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                <img src='<%# Container.DataItem %>' class="d-block w-100" alt="Imagen del artículo">
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%# Eval("Articulo.Id") %>" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carousel<%# Eval("Articulo.Id") %>" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>

                    <asp:Button Text="Quiero este premio!" runat="server" CssClass="select-button" ID="btnSeleccionar" OnClick="btnSeleccionar_Click" CommandArgument='<%# Eval("Articulo.Id") %>' />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
