using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccess;
using Domain.Entities;
using Utils;
using Utils.Interfaces;

namespace Business.Managers
{
    public class MarcaManager : ICrudRepository<Marca>
    {
        private DBManager dataBManager;
        private IMapper<Marca> mapper;


        public MarcaManager()
        {
            dataBManager = new DBManager();
            mapper = new Mapper<Marca>();
        }

        public Marca ObtenerPorId(int idMarca)
        {
            Marca marca;

            string query = "select * from MARCAS where Id = @id";

            SqlParameter[] parametro = new SqlParameter[]
            {
                new SqlParameter("id", idMarca)
            };

            DataTable data = dataBManager.ExecuteQuery(query, parametro);

            ///response
            if (data.Rows.Count == 0)
                return null;

            marca = mapper.MapFromRow(data.Rows[0]);

            return marca;
        }

        public List<Marca> ObtenerTodos()
        {
            List<Marca> lista;

            string query = "Select * from MARCAS";

            DataTable data = dataBManager.ExecuteQuery(query);

            int rows = (int)dataBManager.ExecuteScalar(query);

            ///response
            if (rows == 0)
                return null;

            lista = mapper.ListMapFromRow(data);

            return lista;
        }

        public Marca Crear(Marca m)
        {

            string query = "insert into MARCAS values (@Descripcion)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Descripcion", m.Descripcion)
            };

            var res = dataBManager.ExecuteNonQuery(query, parametros);

            if (res == 0)
                return new Marca();

            MessageBox.Show("Marca agregada correctamente");
            return m;
        }

        public bool Update(Marca m)
        {
            string query = @"update MARCAS SET Descripcion = @descripcion where id = @id";

            SqlParameter[] parametro = new SqlParameter[]
            {
                new SqlParameter("@descripcion", m.Descripcion)
            };

            var res = dataBManager.ExecuteNonQuery(query, parametro);

            if(res == 0) return false;
            
            MessageBox.Show("Marca modificada correctamente");
            return true;
        }

        public bool Eliminar(int id)
        {           
            string query = "delete from MARCAS where id = @id";

            SqlParameter[] parametro = new SqlParameter[]
                {
                new SqlParameter("@id", id)
                };

            var res = dataBManager.ExecuteNonQuery(query, parametro);

            if(res == 0) return false;

            return true;  
        }


    }
}
