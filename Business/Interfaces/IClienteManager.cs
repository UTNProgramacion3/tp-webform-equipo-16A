using Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWeb_equipo_16A.Domain.Entities;

namespace Business.Interfaces
{
    public interface IClienteManager : ICrudRepository<Cliente>
    {
        Cliente VerificarExistenciaUsuario(string dni);
    }
}