﻿using Business.Interfaces;
using Business.Managers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using TPWeb_equipo_16A.Domain.Entities;

namespace TPWeb_equipo_16A.Pages
{
    public partial class Participar : System.Web.UI.Page
    {
        private readonly IClienteManager _clienteManager;
        private readonly IVoucherManager _voucherManager;
        private string _voucherValidado;

        public Participar()
        {
            _clienteManager = new ClienteManager();
            _voucherManager = new VoucherManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _voucherValidado = Session["VoucherValidado"]?.ToString();

            if (_voucherValidado == null)
            {
                Session.Abandon();
                Response.Redirect("~/Pages/checkVoucher.aspx");
            }

                ingreso_dni_container.Visible = true;
                ingresar_datos_manual.Visible = false;
                documento_validado.Enabled = false;
                form_usuario_existente.Visible = false;

                Session.Add("Resultado", false);
        }

        protected void ValidarDniIngresado(object sender, EventArgs e)
        {

            if (!ValidarDni(documento_inicial.Text))
            {
                failureCard.Visible = true;
                Mensaje.Text = "El DNI ingresado no es válido";
                mensajeError.Text = "Intente nuevamente";
                contentError.Text = "Recuerde que el DNI debe tener 8 dígitos";
                ClientScript.RegisterStartupScript(this.GetType(), "redirectScript", "setTimeout(function(){ window.location.href = 'Participar.aspx'; }, 3000);", true);
                return;
            }

            ingreso_dni_container.Visible = false;
            var cliente = _clienteManager.VerificarExistenciaUsuario(documento_inicial.Text);

            if (cliente.Documento != null )
            {
                form_usuario_existente.Visible = true;

                documento_validado.Text = documento_inicial.Text;
                documentoCliente.Enabled = false;
                nombre.Text = cliente.Nombre;
                apellido.Text = cliente.Apellido;
                email.Text = cliente.Email;
                direccion.Text = cliente.Direccion;
                ciudad.Text = cliente.Ciudad;
                codigoPostal.Text = cliente.CP.ToString();

                 var res = _voucherManager.CompletarVoucher(Session["VoucherValidado"].ToString(), cliente.Id, Session["ArticuloSeleccionado"].ToString());

                if (res)
                {
                    Session["Resultado"] = true;
                }
            }
            else
            {
                ingresar_datos_manual.Visible = true;
                documentoCliente.Text = documento_inicial.Text;
                documentoCliente.Enabled = false;

            }
        }

        protected void ConfirmarDatosYParticipar(object sender, EventArgs e)
        {
            ingresar_datos_manual.Visible = false;
            form_usuario_existente.Visible = false;


            ClientScript.RegisterStartupScript(this.GetType(), "redirectScript", "setTimeout(function(){ window.location.href = 'priceResult.aspx'; }, 1000);", true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Cliente nuevoCliente = new Cliente()
            {
                Documento = documentoCliente.Text,
                Nombre = nombreCliente.Text,
                Apellido = apellidoCliente.Text,
                Email = emailCliente.Text,
                Direccion = direccionCliente.Text,
                Ciudad = ciudadCliente.Text,
                CP = int.Parse(codigoPostalCliente.Text)
            };

            var res = _clienteManager.Crear(nuevoCliente);

            if(res.Documento == null)
            {
                failureCard.Visible = true;
                Mensaje.Text = "Hubo un error al cargar los datos";
                mensajeError.Text = "Intente nuevamente";
                contentError.Text = "Si el problema persiste, por favor comuníquese con el administrador";
                ClientScript.RegisterStartupScript(this.GetType(), "redirectScript", "setTimeout(function(){ window.location.href = 'Participar.aspx'; }, 3000);", true);
                return;
            }
            
            var registro = _voucherManager.CompletarVoucher(Session["VoucherValidado"].ToString(), res.Id, Session["ArticuloSeleccionado"].ToString());

            if (registro)
            {
                Session["Resultado"] = true;
            Session.Add("DocumentoCliente", res.Documento);
            Session["Resultado"] = true;
            Response.Redirect("~/Pages/priceResult.aspx");

            }
            else
            {
                Response.Redirect("~/Pages/Error.aspx");
            }

        }

        private bool ValidarDni(string dni)
        {
            if (dni.Length != 8)
            {
                return false;
            }
            return true;
        }
    }
}