using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
namespace Clases_Abstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        string apellido;
        int dni;
        ENacionalidad nacionalidad;
        string nombre;
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }
        public string StringToDNI
        {
            set
            {
                this.DNI = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        public Persona()
        {
        }
        public Persona(string nombre,string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni,ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Nombre completo: {0},{0}", this.Apellido, this.Nombre);
            sb.AppendFormat("Nacionalidad: {0}",this.Nacionalidad);
            sb.AppendFormat("Dni: {0}", this.DNI);
            return sb.ToString();
        }
        int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch(nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato >= 1 && dato <= 89999999)
                        return dato;
                    else
                        throw new DniInvalidoException();
                case ENacionalidad.Extranjero:
                    if (dato >= 90000000 && dato <= 99999999)
                        return dato;
                    else
                        throw new DniInvalidoException();
                default:
                    throw new NacionalidadInvalidaException();
            }
        }
        int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if(dato.Length <= 8 && dato.Length > 0)
            {
                foreach(char c in dato)
                {
                    if(!char.IsDigit(c))
                        throw new NacionalidadInvalidaException();
                }
                return ValidarDni(nacionalidad, int.Parse(dato));
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
        }
        string ValidarNombreApellido(string dato)
        {
            foreach(char c in dato)
            {
                if (!char.IsLetter(c))
                    return "";
            }
            return dato;
        }
    }
}
