using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Producto_VO
    {
        private int _Id_Producto;
        private string _Nombre_Producto;
        private string _Descripcion;
        private float _Precio;
        private int _Categoia_Id;
        private int _Proveedor_Id;

        public int Id_Producto { get => _Id_Producto; set => _Id_Producto = value; }
        public string Nombre_Producto { get => _Nombre_Producto; set => _Nombre_Producto = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public float Precio { get => _Precio; set => _Precio = value; }
        public int Categoia_Id { get => _Categoia_Id; set => _Categoia_Id = value; }
        public int Proveedor_Id { get => _Proveedor_Id; set => _Proveedor_Id = value; }

        public Producto_VO()
        {
        _Id_Producto=0;
        _Nombre_Producto="";
        _Descripcion="";
        _Precio=0;
        _Categoia_Id=0;
        _Proveedor_Id = 0;
    }

        public Producto_VO(DataRow dr)
        {
            _Id_Producto = int.Parse(dr["Id_Producto"].ToString());
            _Nombre_Producto = dr["Nombre_Producto"].ToString();
            _Descripcion = dr["Descripcion"].ToString();
            _Precio = float.Parse(dr["Precio"].ToString());
            _Categoia_Id = int.Parse(dr["Categoria_Id"].ToString());
            _Proveedor_Id = int.Parse(dr["Proveedor_Id"].ToString());
        }


    }
}
