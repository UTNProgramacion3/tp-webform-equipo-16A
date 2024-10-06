using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWeb_equipo_16A.Pages
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificamos si se ha pasado información de error
            if (Session["ErrorMessage"] != null)
            {
                // Mostramos el mensaje de error en la página
                litErrorMessage.Text = $"<p><strong>Error: </strong>{Session["ErrorMessage"]}</p>";
            }

            if (Session["StackTrace"] != null)
            {
                // Mostramos el StackTrace
                litStackTrace.Text = $"<p><strong>Details:</strong></p><div>{Session["StackTrace"]}</div>";
            }

            // Limpiamos las variables de sesión para no seguir mostrando el error en futuras páginas
            Session.Remove("ErrorMessage");
            Session.Remove("StackTrace");

        }
    }
}