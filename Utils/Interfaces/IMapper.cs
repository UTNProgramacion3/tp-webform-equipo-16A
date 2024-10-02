using System;
using System.Collections.Generic;
using System.Data;

namespace Utils.Interfaces
{
    public interface IMapper<T> where T : class, new()
    {
        T MapFromRow(DataRow row);
        List<T> ListMapFromRow(DataTable table);
        DataTable MapFromDtoToTable(List<T> dto);
    }
}
