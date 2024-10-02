using DataAccess;
using Domain.Entities;
using Utils;
using Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Business.Dtos;

namespace Business.Managers
{
    public class ArticuloManager : ICrudRepository<ArticuloDTO>
    {
        private DBManager _dbManager;
        private IMapper<ArticuloDTO> _mapper;

        public ArticuloManager()
        {
            _dbManager = new DBManager();
            _mapper = new Mapper<ArticuloDTO>();
        }

        public ArticuloDTO Crear(ArticuloDTO entity)
        {
            string query = @"Insert into ARTICULOS values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)";

            SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Codigo", entity.Articulo.Codigo),
                    new SqlParameter("@Nombre", entity.Articulo.Nombre),
                    new SqlParameter("@Descripcion", entity.Articulo.Descripcion),
                    new SqlParameter("@IdMarca", entity.Articulo.IdMarca),
                    new SqlParameter("@IdCategoria", entity.Articulo.IdCategoria),
                    new SqlParameter("@Precio", entity.Articulo.Precio)
                };

            try
            {

                var res = _dbManager.ExecuteNonQuery(query, parametros);

                if (res == 0)
                {
                    return new ArticuloDTO();
                }
                entity.Articulo.Id = (int)_dbManager.ExecuteScalar("Select Max(Id) From ARTICULOS");
                return entity;
            }catch (Exception ex)
            {
                throw new Exception("Problemas al crear un articulo: " + ex.Message.ToString());
            }
        }

        public bool Eliminar(int id)
        {
            //Eliminacion virtual:
            //      Cambiamos el codigo del art a eliminar a 0000.
            string query = @"Update ARTICULOS
                            Set Codigo = @Codigo
                            Where Id = @Id";

            SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Codigo", "0000"),
                    new SqlParameter("@Id", id)
                };

            try
            {

                var res = _dbManager.ExecuteNonQuery(query, parametros);

                if (res == 0)
                {
                    return false;
                }

                return true;
            }catch (Exception ex)
            {
                throw new Exception("Problemas al eliminar articulo: " + ex.Message.ToString());
            }
        }
        public ArticuloDTO ObtenerPorId(int id)
        {
            string query = @"SELECT 
                                A.Id,
                                A.Codigo,
                                A.Nombre,
                                A.Descripcion,
                                A.Precio,
                                M.Id AS MarcaId,
                                M.Descripcion AS MarcaDescripcion,
                                C.Id AS CategoriaId,
                                C.Descripcion AS CategoriaDescripcion
                            FROM ARTICULOS A
                            LEFT JOIN MARCAS M ON A.IdMarca = M.Id
                            LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id
                            WHERE A.Id = @Id;";

            SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", id)
                };

            try
            {

                DataTable res = _dbManager.ExecuteQuery(query, parametros);

                if (res.Rows.Count == 0)
                {
                    return new ArticuloDTO();
                }

                ArticuloDTO articulo = _mapper.MapFromRow(res.Rows[0]);

                return articulo;
            }catch (Exception ex)
            {
                throw new Exception("Problemas al obtener articulo por id: " + ex.Message.ToString());
            }


        }

        public List<ArticuloDTO> ObtenerTodos()
        {
            string query = @"SELECT 
                    A.Id AS Articulo_Id,
                    A.Codigo AS Articulo_Codigo,
                    A.Nombre AS Articulo_Nombre,
                    A.Descripcion AS Articulo_Descripcion,
                    A.Precio AS Articulo_Precio,
                    M.Id AS Marca_Id,
                    M.Descripcion AS Marca_Descripcion,
                    C.Id AS Categoria_Id,
                    C.Descripcion AS Categoria_Descripcion
                FROM ARTICULOS A
                LEFT JOIN MARCAS M ON A.IdMarca = M.Id
                LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id;";

            try
            {

                DataTable res = _dbManager.ExecuteQuery(query);

                if (res.Rows.Count == 0)
                {
                    return new List<ArticuloDTO>();
                }

                var articulosList = _mapper.ListMapFromRow(res);

                return articulosList;
            }catch(Exception ex)
            {
                throw new Exception("Problemas al obtener todos los articulos: " + ex.ToString());
            }
        }

        public bool Update(ArticuloDTO entity)
        {
            string query = @"Update ARTICULOS 
                            Set Codigo = @Codigo,
                                Nombre = @Nombre,
                                Descripcion = @Descripcion,
                                IdMarca = @IdMarca,
                                IdCategoria = @IdCategoria,
                                Precio = @Precio
                            Where Id = @Id";

            SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Codigo", entity.Articulo.Codigo),
                    new SqlParameter("@Nombre", entity.Articulo.Nombre),
                    new SqlParameter("@Descripcion", entity.Articulo.Descripcion),
                    new SqlParameter("@IdMarca", entity.Articulo.IdMarca),
                    new SqlParameter("@IdCategoria", entity.Articulo.IdCategoria),
                    new SqlParameter("@Precio", entity.Articulo.Precio),
                    new SqlParameter("@Id", entity.Articulo.Id)
                };

            try
            {

                var res = _dbManager.ExecuteNonQuery(query, parametros);

                if(res == 0)
                {
                    return false;
                }

                return true;
            }catch (Exception ex)
            {
                throw new Exception("Error al hacer update: " + ex.ToString());
            }

        }

        private string FilterQueryBuilder(string campo, string condicion, string filtro, bool eliminados)
        {
            string query = @"SELECT 
                    A.Id AS Articulo_Id,
                    A.Codigo AS Articulo_Codigo,
                    A.Nombre AS Articulo_Nombre,
                    A.Descripcion AS Articulo_Descripcion,
                    A.Precio AS Articulo_Precio,
                    M.Id AS Marca_Id,
                    M.Descripcion AS Marca_Descripcion,
                    C.Id AS Categoria_Id,
                    C.Descripcion AS Categoria_Descripcion
                FROM ARTICULOS A
                LEFT JOIN MARCAS M ON A.IdMarca = M.Id
                LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id 
                Where ";

            if (eliminados == false)
            {
                query += "A.Codigo != '0000' And ";
            }

            if (campo == "Precio")
            {
                switch (condicion)
                {
                    case "Mayor a":
                        query += "A.Precio > " + filtro;
                        break;
                    case "Menor a":
                        query += "A.Precio < " + filtro;
                        break;
                    case "Igual a":
                        query += "A.Precio = " + filtro;
                        break;
                }
            }
            else
            {
                switch (campo)
                {
                    case "Codigo":
                        query += "A.Codigo ";
                        break;
                    case "Nombre":
                        query += "A.Nombre ";
                        break;
                    case "Marca":
                        query += "M.Descripcion ";
                        break;
                    case "Categoria":
                        query += "C.Descripcion ";
                        break;
                }

                switch (condicion)
                {
                    case "Empieza con":
                        query += "like  '" + filtro + "%' ";
                        break;
                    case "Termina por":
                        query += "like '%" + filtro + "' ";
                        break;
                    case "Igual a":
                        query += "like '%" + filtro + "%' ";
                        break;
                }

            }

            return query;
        }

        public List<ArticuloDTO> Filtrar(string campo, string condicion, string filtro, bool eliminados)
        {
            List<ArticuloDTO> listaFiltrada;

            string query = FilterQueryBuilder(campo, condicion, filtro, eliminados);

            try
            {
                DataTable res = _dbManager.ExecuteQuery(query);

                if (res.Rows.Count == 0)
                {
                    return new List<ArticuloDTO>();
                }

                listaFiltrada = _mapper.ListMapFromRow(res);

                return listaFiltrada;
            }catch (Exception ex)
            {
                throw new Exception("Error al filtrar " + ex.ToString());
            }
        }
    }
}
