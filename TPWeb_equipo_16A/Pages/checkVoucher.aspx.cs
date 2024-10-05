using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Managers;

namespace TPWeb_equipo_16A.Pages
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            VoucherManager voucherManager = new VoucherManager();

            string codigo = txtCodigoVoucher.Value;

            var res = voucherManager.VerificarCodigoVoucher(codigo);

            if (res)
            {
                successAlert.Visible = true;
                failureAlert.Visible = false;

                //Inyeccion de script de javascript que permite navegar a la siguiente pagina y dar el tiempo necesario para visualizar el refresco del alerta success
                //Suplanta a función Response.Redirect(...)

                ClientScript.RegisterStartupScript(this.GetType(), "redirectScript", "setTimeout(function(){ window.location.href = 'Page1.aspx'; }, 3000);", true);
            }
            else
            {
                failureAlert.Visible = true;
                successAlert.Visible = false;
            }
        }

    }
}