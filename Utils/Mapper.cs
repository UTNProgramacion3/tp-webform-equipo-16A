using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using Utils.Interfaces;

namespace Utils
{
    public class Mapper<T> : IMapper<T> where T : class, new()
    {
        public T MapFromRow(DataRow row)
        {
            T obj = new T();
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            foreach (var prop in properties)
            {
                if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string))
                {
                    // Handle p/ nested class properties
                    PropertyInfo[] nestedProperties = prop.PropertyType.GetProperties();
                    object nestedObject = Activator.CreateInstance(prop.PropertyType);
                    foreach (var nestedProp in nestedProperties)
                    {
                        string columnName = $"{prop.Name}_{nestedProp.Name}";
                        if (row.Table.Columns.Contains(columnName))
                        {
                            var value = row[columnName];
                            if (value != DBNull.Value)
                            {
                                object convertedValue = Convert.ChangeType(value, nestedProp.PropertyType);
                                nestedProp.SetValue(nestedObject, convertedValue);
                            }
                        }
                    }
                    prop.SetValue(obj, nestedObject);
                }
                else
                {
                    // Handle p/ simple properties
                    if (row.Table.Columns.Contains(prop.Name))
                    {
                        var value = row[prop.Name];
                        if (value != DBNull.Value)
                        {
                            object convertedValue = Convert.ChangeType(value, prop.PropertyType);
                            prop.SetValue(obj, convertedValue);
                        }
                    }
                }
            }
            return obj;
        }

        public List<T> ListMapFromRow(DataTable table)
        {
            List<T> objList = new List<T>();
            foreach (DataRow row in table.Rows)
            {
                var res = MapFromRow(row);
                objList.Add(res);
            }
            return objList;
        }
    public DataTable MapFromDtoToTable(List<T> dtos)
        {
            DataTable table = new DataTable();

            if (dtos == null || !dtos.Any())
                return table;

            PropertyInfo[] properties = typeof(T).GetProperties();

            // Agregamos las columnas al DataTable
            foreach (var prop in properties)
            {
                if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string))
                {
                    PropertyInfo[] nestedProperties = prop.PropertyType.GetProperties();

                    foreach (var nestedProp in nestedProperties)
                    {
                        table.Columns.Add($"{prop.Name}_{nestedProp.Name}", typeof(string));
                    }
                }
                else
                {
                    table.Columns.Add(prop.Name, typeof(string));
                }
            }

            // Agregamos las filas al DataTable
            foreach (var dto in dtos)
            {
                DataRow row = table.NewRow();
                foreach (var prop in properties)
                {
                    if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string))
                    {
                        var nestedObject = prop.GetValue(dto); 

                        if (nestedObject != null) // Verificamos si el objeto no es nulo
                        {
                            PropertyInfo[] nestedProperties = prop.PropertyType.GetProperties();

                            foreach (var nestedProp in nestedProperties)
                            {
                                var nestedValue = nestedProp.GetValue(nestedObject) ?? DBNull.Value;
                                row[$"{prop.Name}_{nestedProp.Name}"] = nestedValue.ToString();
                            }
                        }
                        else
                        {
                           
                            PropertyInfo[] nestedProperties = prop.PropertyType.GetProperties();

                            foreach (var nestedProp in nestedProperties)
                            {
                                row[$"{prop.Name}_{nestedProp.Name}"] = DBNull.Value;
                            }
                        }
                    }
                    else
                    {
                        var value = prop.GetValue(dto) ?? DBNull.Value;
                        row[prop.Name] = value.ToString();
                    }
                }

                table.Rows.Add(row);
            }

            return table;
        }
    }
}
