using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos
{
    public class ArticuloDTO
    {
       public Articulo Articulo { get; set; }
       public Marca Marca { get; set; }
       public Categoria Categoria { get; set; }
    }
}
