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
                this.apellido = this.ValidarNombreApellido(value);
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
            sb.AppendFormat("Nombre completo: {0},{1}\n", this.Apellido, this.Nombre);
            sb.AppendFormat("Nacionalidad: {0}\n", this.Nacionalidad);
            sb.AppendFormat("DNI: {0}\n", this.DNI);
            return sb.ToString();
        }
        int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch(nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato >= 1 && dato <= 89999999)
                        return dato;
                    break;
                case ENacionalidad.Extranjero:
                    if (dato >= 90000000 && dato <= 99999999)
                        return dato;
                    break;
                   // else
                        //throw new DniInvalidoException("ERROR, DNI Extranjero invalido: Fuera de rango");
               // default:
            }
                    throw new NacionalidadInvalidaException("ERROR, Nacionalidad INVALIDA");
        }
        int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int auxdni;
            if(dato.Length <= 8 && dato.Length > 0 && (int.TryParse(dato, out auxdni)))
            {
                foreach(char c in dato)
                {
                    if(!char.IsDigit(c))
                        throw new DniInvalidoException("ERROR, DNI contiene caracteres NO numericos");
                }
                return ValidarDni(nacionalidad, auxdni);
            }
            else
            {
                throw new DniInvalidoException("ERROR, Cantidad de caracteres erronea || Imposibilidad Parsear");
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
