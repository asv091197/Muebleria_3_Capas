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
        private float _Total;

        public int Id_Venta { get => _Id_Venta; set => _Id_Venta = value; }
        public string Fecha_Venta { get => _Fecha_Venta; set => _Fecha_Venta = value; }
        public int Cliente_Id { get => _Cliente_Id; set => _Cliente_Id = value; }
        public int Empleado_Id { get => _Empleado_Id; set => _Empleado_Id = value; }
        public float Total { get => _Total; set => _Total = value; }

        public Venta_VO() {

            _Id_Venta = 0;
            _Fecha_Venta = "";
            _Cliente_Id = 0;
            _Empleado_Id = 0;
            _Total = 0;
        }

        public Venta_VO(DataRow dr)
        {
            _Id_Venta = int.Parse(dr["Id_Venta"].ToString());
            _Fecha_Venta = dr["Fecha_Venta"].ToString();
            _Cliente_Id = int.Parse(dr["Cliente"].ToString());
            _Empleado_Id = int.Parse(dr["Empleado_Id"].ToString());
        }
    }
}
