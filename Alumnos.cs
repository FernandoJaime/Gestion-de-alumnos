using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa___Lista_de_alumnos
{
    public class Alumnos
    {
        // Atributos privados
        private int _legajo;
        private string _nombre;
        private string _apellido;
        private DateTime _fechanacimiento;
        private DateTime _fechaingreso;
        private int _edad;
        private bool _activo;
        private int _mataprobadas;

        // Propiedades
        public int Legajo
        {
            get { return _legajo; }
            set { _legajo = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public DateTime Fechanacimiento
        {
            get { return _fechanacimiento; }
            set { _fechanacimiento = value; }
        }
        public DateTime Fechaingreso
        {
            get { return _fechaingreso; }
            set { _fechaingreso = value; }
        }
        public int Edad
        {
            // get para calcular la edad
            get
            {
                int añosIngreso;
                TimeSpan dif;
                dif = DateTime.Now.Subtract(_fechanacimiento);
                añosIngreso = Convert.ToInt32(Math.Floor(dif.TotalDays / 360));
                _edad = añosIngreso;

                return añosIngreso;
            }
        }
        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }
        public int Mataprobadas
        {
            get { return _mataprobadas; }
            set { _mataprobadas = value; }
        }

        // Constructor
         public Alumnos (int legajo, string nombre, string apellido, DateTime fechanacimiento, DateTime fechaingreso, bool activo, int mataprobadas)
        {
            this._legajo = legajo;
            this._nombre = nombre;
            this._apellido = apellido;
            this._fechanacimiento = fechanacimiento;
            this._fechaingreso = fechaingreso;
            this._activo = activo;
            this._mataprobadas = mataprobadas;
        } 

        // Metodo para sacar la antiguedad del alumno
        public string Antiguedad ()
        {
            TimeSpan dif = DateTime.Now.Subtract(_fechaingreso);
            int año = (int)(dif.TotalDays / 365);
            int mes = (int)((dif.TotalDays % 365) / 30.5);
            int dias = (int)(dif.TotalDays % 30.5);

            return $"{dias} días, {mes} meses y {año} años";
        }
        
        // Metodo para sacar las materias no aprobadas
        public int matNoaprobadas ()
        {
            int Noaprobo;
            Noaprobo = 36 - _mataprobadas;

            return Noaprobo;
        }
        
        //Metodo para sacar la edad de ingreso
        public int EdadIngreso ()
        {
            int añosIngreso;
            TimeSpan dif;
            dif = _fechaingreso.Subtract(_fechanacimiento);
            añosIngreso = Convert.ToInt32(Math.Floor(dif.TotalDays / 360));

            return añosIngreso;
        }
    }
}
