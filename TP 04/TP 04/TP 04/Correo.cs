using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        List<Thread> mockPaquetes;
        List<Paquete> paquetes;
        #endregion

        #region Propiedades
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion

        #region Constructor
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.Paquetes = new List<Paquete>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Finaliza hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread t in mockPaquetes)
            {
                if (t.IsAlive)
                    t.Abort();
            }
        }

        /// <summary>
        /// Muestra datos de la lista de Paquetes
        /// </summary>
        /// <param name="elementos">Lista de paquetes</param>
        /// <returns>Todos los datos de los paquetes</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string retorno = "";

            List<Paquete> provisorio = (List<Paquete>)((Correo)elementos).Paquetes;

            foreach (Paquete p in provisorio)
            {
                retorno += string.Format("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }
            return retorno;
        }
        #endregion

        #region Sobrecarga operadores
        /// <summary>
        /// Agrega correo a Lista de paquetes
        /// </summary>
        /// <param name="c">Correo</param>
        /// <param name="p">Paquete a agregar</param>
        /// <returns>Correo</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete aux in c.Paquetes)
            {
                if (aux == p)
                    throw new TrackingIdRepetidoException("Paquete repetido!");
            }
            c.Paquetes.Add(p);
            Thread thread = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(thread);
            thread.Start();
            return c;
        }
        #endregion
    }
}
