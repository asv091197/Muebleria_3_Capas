using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Categoria_VO
    {
        private int _Id_Categoria;

        private string _Nombre_Categoria;

        private string _Descripcion;

        public int Id_Categoria { get => _Id_Categoria; set => _Id_Categoria = value; }
        public string Nombre_Categoria { get => _Nombre_Categoria; set => _Nombre_Categoria = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
    
    

        public Categoria_VO() {

            _Id_Categoria = 0;

            _Nombre_Categoria = "";

            _Descripcion = "";
        }

        public Categoria_VO(DataRow dr)
        {
            _Id_Categoria = int.Parse(dr["Id_Categoria"].ToString());
            _Nombre_Categoria = dr["Nombre_Categoria"].ToString();
            _Descripcion = dr["Descripcion"].ToString();
        }



    }

}
