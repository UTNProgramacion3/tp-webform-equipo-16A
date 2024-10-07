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

            //Traer resultado desde la pagina de carga de datos

            bool response = true;      /* <------Ingresar en esta linea */

            if(response)
            {
                successCard.Visible = true;
                failureCard.Visible = false;
            }
            else
            {
                successCard.Visible = false;
                failureCard.Visible = true;
            }
            ClientScript.RegisterStartupScript(this.GetType(), "redirectScript", "setTimeout(function(){ window.location.href = 'checkVoucher.aspx'; }, 8000);", true);

        }
    }
}