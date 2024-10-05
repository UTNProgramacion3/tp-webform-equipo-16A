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
        protected void Page_Load(object sender, EventArgs e)
        {
            DNI.Visible = true;
            participar_form.Visible = false;
            documento_validado.Enabled = false;
        }

        protected void handleParticipar(object sender, EventArgs e)
        {
            bool existe = true;
            if (existe)
            {
                Session["dni"] = 36915861;
                DNI.Visible = false;
                participar_form.Visible = true;
                documento_validado.Text = 36915861.ToString();


            }
        }
        protected void btnClickMe_Click(object sender, EventArgs e)
        {
            // Lógica de la función
            Response.Write("¡Hola, se ha llamado a la función del code-behind!");
        }
    }
}