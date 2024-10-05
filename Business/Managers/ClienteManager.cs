using Business.Interfaces;
using DataAccess;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWeb_equipo_16A.Domain.Entities;
using Utils;
using Utils.Interfaces;

namespace Business.Managers
{
    public class ClienteManager : ICrudRepository<Cliente>, IClienteManager
    {
        private readonly DBManager _dbManager;
        private IMapper<Cliente> _mapper;

        public ClienteManager()
        {
            _dbManager = new DBManager();
            _mapper = new Mapper<Cliente>();
        }

        public Cliente VerificarExistenciaUsuario(string dni)
        {
            string query = "SELECT * FROM Clientes where Documento = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", dni)
            };

            var res = _dbManager.ExecuteQuery(query, parametros);

            if (res.Rows.Count == 0)
            {
                return new Cliente();
            }

            return _mapper.MapFromRow(res.Rows[0]);
        }


        public Cliente Crear(Cliente entity)
        {
            string query = "INSERT INTO Cliente (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CodigoPostal) VALUES (@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CodigoPostal)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Documento", entity.Documento),
                new SqlParameter("@Nombre", entity.Nombre),
                new SqlParameter("@Apellido", entity.Apellido),
                new SqlParameter("@Email", entity.Email),
                new SqlParameter("@Direccion", entity.Direccion),
                new SqlParameter("@Ciudad", entity.Ciudad),
                new SqlParameter("@CodigoPostal", entity.CodigoPostal)
            };

            var res = _dbManager.ExecuteNonQuery(query, parameters);

            if (res == 0)
            {
                return new Cliente();
            }

            return entity;
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public bool Update(Cliente entity)
        {
            throw new NotImplementedException();
        }
    }
}