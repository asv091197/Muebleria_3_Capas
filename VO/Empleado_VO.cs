﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Empleado_VO
    {
        
        private int _Id_Empleado;
        private string _Nombre;
        private string _Apellido_paterno;
        private string _Apellido_materno;
        private string _Fecha_nacimiento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;

        public int Id_Empleado { get => _Id_Empleado; set => _Id_Empleado = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido_paterno { get => _Apellido_paterno; set => _Apellido_paterno = value; }
        public string Apellido_materno { get => _Apellido_materno; set => _Apellido_materno = value; }
        public string Fecha_nacimiento { get => _Fecha_nacimiento; set => _Fecha_nacimiento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }

        public Empleado_VO()
        {
            _Id_Empleado = 0;
            _Nombre = "";
            _Apellido_paterno = "";
            _Apellido_materno = "";
            _Fecha_nacimiento = "";
            _Direccion = "";
            _Telefono = "";
            _Email = "";
        }

        public Empleado_VO(DataRow dr)
        {
            _Id_Empleado = int.Parse(dr["Id_Empleado"].ToString());
            _Nombre = dr["Nombre"].ToString();
            _Apellido_paterno = dr["Apellido_paterno"].ToString();
            _Apellido_materno = dr["Apellido_materno"].ToString();
            _Fecha_nacimiento = dr["Fecha_nacimiento"].ToString();
            _Direccion = dr["Direccion"].ToString();
            _Telefono = dr["Telefono"].ToString();
            _Email = dr["Email"].ToString();
        }
    }
}
