using Domain.Entities;
using Business.Managers;
using Business.Dtos;
using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;

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
                if (Session["VoucherValidado"] != null)
                {
                    try
                    {
                        InitializeManagers();
                        Articulos = artManager.ObtenerTodos();

                        foreach (var articuloDTO in Articulos)
                        {
                            try
                            {
                                var imagenes = imgManager.ObtenerImagenesPorArticulo(articuloDTO.Articulo.Id);

                                if (imagenes != null)
                                    articuloDTO.Imagenes = Utils.ObjectConverter.ConvertToStringList(imagenes, i => i.ImagenUrl);
                            }
                            catch (Exception ex)
                            {
                                RedirectToErrorPage(ex);
                            }
                        }

                        repRepeater.DataSource = Articulos;
                        repRepeater.DataBind();
                    }
                    catch (Exception ex)
                    {
                        RedirectToErrorPage(ex);
                    }
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
            try
            {
                var button = (Button)sender;
                var articuloId = button.CommandArgument;

                Session.Add("ArticuloSeleccionado", articuloId);

                Response.Redirect("~/Pages/Participar.aspx", false);
            }
            catch (Exception ex)
            {
                RedirectToErrorPage(ex);
            }
        }

        protected void repRepeater_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                RedirectToErrorPage(ex);
            }
        }

        private void RedirectToErrorPage(Exception ex)
        {
            Session["ErrorMessage"] = ex.Message;
            Session["StackTrace"] = ex.StackTrace;
            Response.Redirect("~/Pages/Error.aspx");
        }


    }
}
