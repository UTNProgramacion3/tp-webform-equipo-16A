using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPWeb_equipo_16A.Domain.Entities
{
    public class Voucher
    {
        public int CodigoVoucher { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaCanje { get; set; }
        public int IdArticulo { get; set; }

    }
}