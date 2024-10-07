using Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using TPWeb_equipo_16A.Domain.Entities;
using DataAccess;
using System.Data.SqlClient;
using Domain.Entities;
using System.Data;

namespace Business.Managers
{
    public class VoucherManager : IVoucherManager
    {
        private DBManager _dbManager;

        public VoucherManager()
        {
            _dbManager = new DBManager();
        }


        public bool VerificarCodigoVoucher(string codigo)
        {
            
            string query = "Select CodigoVoucher From Vouchers Where CodigoVoucher = @codigo AND IdCliente IS NULL AND FechaCanje IS NULL AND IdArticulo IS NULL";

            SqlParameter[] parametros = new SqlParameter[]
            {
                    new SqlParameter("@codigo", codigo)
            };

            DataTable data = _dbManager.ExecuteQuery(query, parametros);
             
            
            if (data.Rows.Count == 0)
            {
                return false;
            }

            return true;
        }

        public Voucher Crear(Voucher v)
        {

            string query = "insert into Vouchers (CodigoVoucher) values (@CodigoVoucher);";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@CodigoVoucher", v.CodigoVoucher)
            };

            var res = _dbManager.ExecuteNonQuery(query, parametros);

            if (res == 0)
                return new Voucher();

            return v;
        }

        public bool Eliminar(string cod)
        {
            string query = "delete from Vouchers where CodigoVoucher = @CodigoVoucher";

            SqlParameter[] parametro = new SqlParameter[]
                {
                new SqlParameter("@CodigoVoucher", cod)
                };

            var res = _dbManager.ExecuteNonQuery(query, parametro);

            if (res == 0) return false;

            return true;
        }

        public bool CompletarVoucher(string codVoucher, int idCliente, string idArticulo)
        {

            DateTime fecha = DateTime.Now;
            string query = "update Vouchers SET IdCliente = @idCliente, FechaCanje = GETDATE(), IdArticulo = @idArticulo Where CodigoVoucher = @codigoVoucher";

            SqlParameter[] parametro = new SqlParameter[]
            {
                new SqlParameter("@codigoVoucher", codVoucher),
                new SqlParameter("@idCliente", idCliente),
                new SqlParameter("@idArticulo", idArticulo)
            };

            var res = _dbManager.ExecuteNonQuery(query, parametro);

            if (res == 0) return false;

            return true;
        }
    }


}
