using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Atributos
        public delegate void DelegadoEstado(object obj, EventArgs args);
        public delegate void DelegadoSQL(object obj, EventArgs args);
        string direccionEntrega;
        EEstado estado;
        string trackingID;
        public event DelegadoSQL BaseSql;
        public event DelegadoEstado InformaEstado;
        #endregion

        #region Enumerado
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion

        #region Propiedades
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        #endregion

        #region Metodos
        
        /// <summary>
        /// Encargado de cambio de estado de los paquetes
        /// </summary>
        public void MockCicloDeVida()
        {
            do
            {
                InformaEstado.Invoke(this,null);
                Thread.Sleep(4000);
                this.Estado++;
            }while (this.Estado != EEstado.Entregado);

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch(Exception)
            {
                this.BaseSql.Invoke(this,null);
            }
            InformaEstado.Invoke(this, null);
        }

        /// <summary>
        /// Muestra todos los datos de paquete
        /// </summary>
        /// <param name="elemento">Paquete</param>
        /// <returns>Datos del paquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;

            return string.Format("{0} para {1}\n", p.TrackingID, p.DireccionEntrega);
        }

        /// <summary>
        /// Sobreescritura del metodo ToString, devuelve datos del paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Verifica si dos paquetes son distintos
        /// </summary>
        /// <param name="p1">Paquete 1 a comparar</param>
        /// <param name="p2">Paquete 2 a comparar</param>
        /// <returns>True si los paquetes son distitos, false contrario</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Verifica si los dos paquetes son iguales
        /// </summary>
        /// <param name="p1">Paquete 1 a comparar</param>
        /// <param name="p2">Paquete 2 a comparar</param>
        /// <returns>True si los paquetes son iguales, false contrario</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (p1.TrackingID == p2.TrackingID)
                return true;
            return false;
        }
        #endregion

        #region Constructor
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }
        #endregion
    }
}
