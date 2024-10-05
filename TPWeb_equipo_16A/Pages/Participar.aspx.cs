﻿using Business.Interfaces;
using Business.Managers;
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

        public Participar()
        {
            _clienteManager = new ClienteManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ingreso_dni_container.Visible = true;
            ingresar_datos_manual.Visible = false;
            documento_validado.Enabled = false;
            form_usuario_existente.Visible = false;
        }

        protected void ValidarDniIngresado(object sender, EventArgs e)
        {

            if (ValidarDni(dni.Text))
            {
                failureCard.Visible = true;
                Mensaje.Text = "El DNI ingresado no es válido";
                mensajeError.Text = "Intente nuevamente";
                ClientScript.RegisterStartupScript(this.GetType(), "redirectScript", "setTimeout(function(){ window.location.href = 'Participar.aspx'; }, 3000);", true);
                return;
            }

            ingreso_dni_container.Visible = false;
            var cliente = _clienteManager.VerificarExistenciaUsuario(dni.Text);

            if (cliente.Id != 0 )
            {
                form_usuario_existente.Visible = true;

                documentoCliente.Text = dni.Text;
                documentoCliente.Enabled = false;
                nombre.Text = cliente.Nombre;
                apellido.Text = cliente.Apellido;
                email.Text = cliente.Email;
                direccion.Text = cliente.Direccion;
                ciudad.Text = cliente.Ciudad;
                codigoPostal.Text = cliente.CP.ToString();
            }
            else
            {
                ingresar_datos_manual.Visible = true;
            }
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

            _clienteManager.Crear(nuevoCliente);
        }

        protected void btnClickMe_Click(object sender, EventArgs e)
        {
            // Lógica de la función
            Response.Write("¡Hola, se ha llamado a la función del code-behind!");
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