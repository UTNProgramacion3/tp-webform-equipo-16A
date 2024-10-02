using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IImagenManager
    {
        bool InsertLista(List<string> urls, int idArticulo);
    }
}
