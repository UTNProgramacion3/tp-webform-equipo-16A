using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Interfaces;
using Business.Managers;
using Domain.Entities;
using TPWeb_equipo_16A.Domain.Entities;

namespace TPWeb_equipo_16A.Pages
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Voucher voucher = new Voucher();

            VoucherManager voucherManager = new VoucherManager();

            string cod = "@CodigoVoucher";

            voucher.CodigoVoucher = cod;

            //voucherManager.VerificarCodigoVoucher(cod);
            //voucherManager.Crear(voucher);
            //voucherManager.Eliminar(cod);

        }
    }
}