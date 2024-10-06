using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Entities;
using Business.Managers;
using Business.Dtos;
using Utils;

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
                if(Session["VoucherValidado"] != null)
                {
                    InitializeManagers();
                    Articulos = artManager.ObtenerTodos();

                    foreach (var articuloDTO in Articulos)
                    {
                        var imagenes = imgManager.ObtenerImagenesPorArticulo(articuloDTO.Articulo.Id);

                        if(imagenes != null)
                        articuloDTO.Imagenes = Utils.ObjectConverter.ConvertToStringList(imagenes, i => i.ImagenUrl);
                    }

                    repRepeater.DataSource = Articulos;
                    repRepeater.DataBind();
                }
                else
                {
                    Response.Redirect("~/Pages/Participar.aspx");
                }
            }
        }

        private void InitializeManagers()
        {
            imgManager = new ImagenManager();
            artManager = new ArticuloManager();
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;

            var articuloId = button.CommandArgument;

            Session.Add("ArticuloSeleccionado", articuloId);

            Response.Redirect("~/Pages/Participar.aspx");
        }

        protected void repRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var articuloDto = (ArticuloDTO)e.Item.DataItem;
                var repImagenes = (Repeater)e.Item.FindControl("repImagenes");

                if (articuloDto.Imagenes != null && articuloDto.Imagenes.Count > 0)
                {
                    repImagenes.DataSource = articuloDto.Imagenes;
                    repImagenes.DataBind();
                }
            }
        }
    }
}