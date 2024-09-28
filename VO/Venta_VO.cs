using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Venta_VO
    {
        private int _Id_Venta;
        private string _Fecha_Venta;
        private int _Cliente_Id;
        private int _Empleado_Id;
        private int _Producto_Id;
        private int _Cantidad;
        private float _Precio_Unitario;
        private float _Total;

        public int Id_Venta { get => _Id_Venta; set => _Id_Venta = value; }
        public string Fecha_Venta { get => _Fecha_Venta; set => _Fecha_Venta = value; }
        public int Cliente_Id { get => _Cliente_Id; set => _Cliente_Id = value; }
        public int Empleado_Id { get => _Empleado_Id; set => _Empleado_Id = value; }
        public int Producto_Id { get => _Producto_Id; set => _Producto_Id = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public float Precio_Unitario { get => _Precio_Unitario; set => _Precio_Unitario = value; }
        public float Total { get => _Total; set => _Total = value; }




        public Venta_VO() {

            Id_Venta = 0;
            Fecha_Venta = "";
            Cliente_Id = 0;
            Empleado_Id = 0;
            Producto_Id = 0;
            Cantidad = 0;
            Precio_Unitario = 0;
            Total = 0;
        }

        public Venta_VO(DataRow dr)
        {
            Id_Venta = int.Parse(dr["Id_Venta"].ToString());
            Fecha_Venta = dr["Fecha_Venta"].ToString();
            Cliente_Id = int.Parse(dr["Cliente_Id"].ToString());
            Empleado_Id = int.Parse(dr["Empleado_Id"].ToString());
            Producto_Id = int.Parse(dr["Producto_Id"].ToString());
            Cantidad= int.Parse(dr["Cantidad"].ToString());
            Precio_Unitario = float.Parse(dr["Precio_Unitario"].ToString());
            Total = float.Parse(dr["Total"].ToString());
        }

        
    }
}
