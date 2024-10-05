using Business.Interfaces;
using Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            participar_form.Visible = false;
            documento_validado.Enabled = false;
            form_usuario_existente.Visible = false;
        }

        protected void ValidarDniIngresado(object sender, EventArgs e)
        {

            if (!ValidarDni(dni.Text))
            {
                failureCard.Visible = true;
                Mensaje.Text = "El DNI ingresado no es válido";
                mensajeError.Text = "Intente nuevamente";
                ClientScript.RegisterStartupScript(this.GetType(), "redirectScript", "setTimeout(function(){ window.location.href = 'Participar.aspx'; }, 3000);", true);
                return;
            }

            var cliente = _clienteManager.VerificarExistenciaUsuario(dni.Text);

            if (cliente.Id != null)
            {
                form_usuario_existente.Visible = true;
                nombre.Text = cliente.Nombre;
                apellido.Text = cliente.Apellido;
                email.Text = cliente.Email;
                direccion.Text = cliente.Direccion;
                ciudad.Text = cliente.Ciudad;
                codigoPostal.Text = cliente.CodigoPostal.ToString();
            }
        }
        protected void btnClickMe_Click(object sender, EventArgs e)
        {
            // Lógica de la función
            Response.Write("¡Hola, se ha llamado a la función del code-behind!");
        }

        private bool ValidarDni(string dni)
        {
            if (dni.Length != 8 || dni.Length != 7)
            {
                return false;
            }
            return true;
        }
    }
}