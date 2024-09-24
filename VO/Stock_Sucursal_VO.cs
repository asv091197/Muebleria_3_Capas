using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Stock_Sucursal_VO
    {

        private int _Id_Stock;
        private int _Producto_Id;
        private int _Sucursal_Id;
        private int _Cantidad;

        public int Id_Stock { get => _Id_Stock; set => _Id_Stock = value; }
        public int Producto_Id { get => _Producto_Id; set => _Producto_Id = value; }
        public int Sucursal_Id { get => _Sucursal_Id; set => _Sucursal_Id = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }

        public Stock_Sucursal_VO()
        {
            _Id_Stock = 0;
            _Producto_Id = 0;
            _Sucursal_Id = 0;
            _Cantidad = 0;
        }

        public Stock_Sucursal_VO(DataRow dr)
        {
            _Id_Stock = int.Parse(dr["Id_Stock"].ToString());
            _Producto_Id = int.Parse(dr["Producto_Id"].ToString());
            _Sucursal_Id = int.Parse(dr["Sucursal_Id"].ToString());
            _Cantidad =  int.Parse(dr["Cantidad"].ToString());
        }
    }
}