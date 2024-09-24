using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Detalle_Venta_VO
    {

        private int _Id_Detalle;
        private int _Venta_Id;
        private int _Producto_Id;
        private int _Cantidad;
        private int _Precio_Unitario;

        public int Id_Detalle { get => _Id_Detalle; set => _Id_Detalle = value; }
        public int Venta_Id { get => _Venta_Id; set => _Venta_Id = value; }
        public int Producto_Id { get => _Producto_Id; set => _Producto_Id = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public int Precio_Unitario { get => _Precio_Unitario; set => _Precio_Unitario = value; }

        public Detalle_Venta_VO() {


         _Id_Detalle =0;
         _Venta_Id =0;
         _Producto_Id=0;
         _Cantidad=0;
         _Precio_Unitario=0;

    }

        public Detalle_Venta_VO(DataRow dr)
        {
            _Id_Detalle = int.Parse(dr["Id_Detalle"].ToString());
            _Venta_Id = int.Parse(dr["Venta_Id"].ToString());
            _Producto_Id = int.Parse(dr["Producto_Id"].ToString());
            _Cantidad = int.Parse(dr["Cantidad"].ToString());
            _Precio_Unitario = int.Parse(dr["Precio_Unitario"].ToString());

        }

    }
}
