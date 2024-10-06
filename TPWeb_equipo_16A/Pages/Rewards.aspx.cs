using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Entities;
using Business.Managers;
using Business.Dtos;

namespace TPWeb_equipo_16A.Pages
{
	public partial class Rewards : System.Web.UI.Page
	{
        protected List<ArticuloDTO> Articulos;
        protected List<Imagen> Imagenes;
        protected ImagenManager imgManager;
        protected ArticuloManager artManager;

        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                InitializeManagers();
                Articulos = artManager.ObtenerTodos();
                repRepeater.DataSource = Articulos;
                repRepeater.DataBind();
            }
        }

        private void InitializeManagers()
        {
            imgManager = new ImagenManager();
            artManager = new ArticuloManager();
        }

        protected void repRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var articuloDto = (ArticuloDTO)e.Item.DataItem;

                var carouselInner = (Literal)e.Item.FindControl("carouselInnerLiteral");

                if (carouselInner != null)
                {
                    var imagenes = imgManager.ObtenerImagenesPorArticulo(articuloDto.Articulo.Id);

                    string imagenHtml = "";
                    foreach (var imagen in imagenes)
                    {
                        imagenHtml += $"<div class='carousel-item {(imagenes.First() == imagen ? "active" : "")}'>";
                        imagenHtml += $"<img src='{imagen.ImagenUrl}' class='d-block w-100' alt='Imagen de {articuloDto.Articulo.Nombre}'>";
                        imagenHtml += "</div>";
                    }

                    carouselInner.Text = imagenHtml;
                }
                else
                {
                    throw new Exception("El control carouselInner no fue encontrado.");
                }
            }
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;

            var articuloId = button.CommandArgument;

            Session.Add("ArticuloSeleccionado", articuloId);

            Response.Redirect("~/Pages/Participar.aspx");
        }
    }
}