using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Proveedor_VO
    {
        private int _Id_Proveedor;
        private string _Nombre_Proveedor;
        private string _Direccion;
        private string _Telefono;
        private string _Email;

        public int Id_Proveedor { get => _Id_Proveedor; set => _Id_Proveedor = value; }
        public string Nombre_Proveedor { get => _Nombre_Proveedor; set => _Nombre_Proveedor = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }


        public Proveedor_VO() {
            _Id_Proveedor = 0;
            _Nombre_Proveedor = "";
            _Direccion = "";
            _Telefono = "";
            _Email = "";
        }

        public Proveedor_VO(DataRow dr)
        {
            _Id_Proveedor = int.Parse(dr["Id_Proveedor"].ToString());
            _Nombre_Proveedor = dr["Nombre_Proveedor"].ToString();
            _Direccion = dr["Direccion"].ToString();
            _Telefono = dr["Telefono"].ToString();
            _Email = dr["Email"].ToString();
        }
    }
}
