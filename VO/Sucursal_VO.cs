using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Sucursal_VO
    {
        private int _Id_Sucursal;
        private string _Nombre_sucursal;
        private string _Direccion;
        private string _Telefono;

        public int Id_Sucursal { get => _Id_Sucursal; set => _Id_Sucursal = value; }
        public string Nombre_sucursal { get => _Nombre_sucursal; set => _Nombre_sucursal = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }

        public Sucursal_VO() {


            _Id_Sucursal = 0;
            _Nombre_sucursal = "";
            _Direccion = "";
            _Telefono = "";


        }

        public Sucursal_VO(DataRow dr)
        {
            _Id_Sucursal = int.Parse(dr["Id_Sucursal"].ToString());
            _Nombre_sucursal = dr["Nombre_Sucursal"].ToString();
            _Direccion = dr["Direccion"].ToString();
            _Telefono = dr["Telefono"].ToString();
        }
            
    }
}
