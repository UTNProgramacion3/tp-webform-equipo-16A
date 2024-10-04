using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWeb_equipo_16A.Pages
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            // Aquí puedes agregar la lógica para validar el DNI.
            // Si es válido, mostrar el panel de datos.
            if (!string.IsNullOrEmpty(txtDNI.Text))
            {
                PanelDatos.Visible = true;
                PanelDNI.Visible = false; // Oculta el panel de DNI
            }
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            // Aquí puedes agregar la lógica para guardar los datos
            // Por ejemplo, mostrar un mensaje de éxito o guardar en la base de datos.
        }
    }
}