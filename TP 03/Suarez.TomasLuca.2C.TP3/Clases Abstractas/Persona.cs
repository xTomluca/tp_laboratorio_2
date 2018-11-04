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
        #region Enumerado
        /// <summary>
        /// Enumero de Nacionalidad
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #endregion

        #region Atributos
        string apellido;
        int dni;
        ENacionalidad nacionalidad;
        string nombre;
        #endregion

        #region Propiedades
        /// <summary>
        /// Getter y Setter de Apellido 
        /// </summary>
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

        /// <summary>
        /// Getter y Setter de DNI 
        /// </summary>
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

        /// <summary>
        /// Getter y Setter de Nacionalidad 
        /// </summary>
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

        /// <summary>
        /// Getter y Setter de Nombre 
        /// </summary>
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

        /// <summary>
        /// Setter de DNI String
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.DNI = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor Persona sin Parametros
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Constructor Persona
        /// </summary>
        /// <param name="nombre">Nombre de Persona</param>
        /// <param name="apellido">Apellido de Persona</param>
        /// <param name="nacionalidad">Nacionalidad de Persona</param>
        public Persona(string nombre,string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor de Persona
        /// </summary>
        /// <param name="nombre">Nombre de Persona</param>
        /// <param name="apellido">Apellido de Persona</param>
        /// <param name="dni">DNI de Persona</param>
        /// <param name="nacionalidad">Nacionalidad de Persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor Persona
        /// </summary>
        /// <param name="nombre">Nombre de Persona</param>
        /// <param name="apellido">Apellido de Persona</param>
        /// <param name="dni">DNI de Persona(String)</param>
        /// <param name="nacionalidad">Nacionalidad de Persona</param>
        public Persona(string nombre, string apellido, string dni,ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra datos de Persona
        /// </summary>
        /// <returns>Datos Persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);
            sb.AppendFormat("DNI: {0}\n", this.DNI);
            return sb.ToString();
        }

        /// <summary>
        /// Valida DNI
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la Persona</param>
        /// <param name="dato">DNI</param>
        /// <returns>Retorna DNI valido, caso contrario Excepcion</returns>
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
            }
            throw new NacionalidadInvalidaException("ERROR, Nacionalidad INVALIDA");
        }
        /// <summary>
        /// Valida DNI
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la Persona</param>
        /// <param name="dato">DNI</param>
        /// <returns>Retorna DNI valido, caso contrario Excepcion</returns>
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
                throw new DniInvalidoException("ERROR, Cantidad de caracteres erronea || Imposibilidad de pasar a valor Numerico");

        }

        /// <summary>
        /// Valida Nombre y Apellido
        /// </summary>
        /// <param name="dato">Dato a validar</param>
        /// <returns>Retorna Nombre/Apellido</returns>
        string ValidarNombreApellido(string dato)
        {
            foreach(char c in dato)
            {
                if (!char.IsLetter(c))
                    return "";
            }
            return dato;
        }
        #endregion
    }
}
