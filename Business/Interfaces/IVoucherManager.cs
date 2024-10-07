using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWeb_equipo_16A.Domain.Entities;
namespace Business.Interfaces

{
    public interface IVoucherManager
    {
        bool VerificarCodigoVoucher(string codigo);

        Voucher Crear(Voucher v);

        bool Eliminar(string v);

        bool CompletarVoucher(string codVoucher, int idCliente, int idArticulo);
    }
}
