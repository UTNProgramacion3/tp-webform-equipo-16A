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
                Alert.InnerText = "El codigo de Voucher fue asignado correctamente";
                Alert.Attributes.Add("class", "alert alert-success");
                Session.Add("VoucherValidado", codigo);
                Alert.Visible = true;
                //Inyeccion de script de javascript que permite navegar a la siguiente pagina y dar el tiempo necesario para visualizar el refresco del alerta success
                //Suplanta a función Response.Redirect(...)

                ClientScript.RegisterStartupScript(this.GetType(), "redirectScript", "setTimeout(function(){ window.location.href = '/Pages/Rewards.aspx'; }, 3000);", true);
            }
            else
            {
                Alert.Attributes.Add("class", "alert alert-danger");
                Alert.InnerText = "El codigo de Voucher es invalido o ya fue utilizado";
                Alert.Visible = true;

                string script = "setTimeout(function () { document.getElementById('" + Alert.ClientID + "').style.display = 'none'; }, 3000);";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "HideAlert", script, true);
            }

        }

    }
}