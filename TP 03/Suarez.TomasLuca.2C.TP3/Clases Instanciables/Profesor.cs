using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using static Clases_Instanciables.Universidad;
using Excepciones;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        Queue<EClases> clasesDelDia;
        static Random random;
        void _randomClases()
        {
            this.clasesDelDia.Enqueue((EClases)random.Next(4));
            System.Threading.Thread.Sleep(1000);
            this.clasesDelDia.Enqueue((EClases)random.Next(4));
        }
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clases del dia:");
            foreach(EClases c in this.clasesDelDia)
            {
                sb.AppendLine(c.ToString());
            }
            return sb.ToString();
        }

        static Profesor()
        {
            random = new Random();
        }

        public Profesor()
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id,nombre, apellido,dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Profesor desigual a Clase si no dicta esta
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">EClase</param>
        /// <returns>TRUE Profesor NO da esta Clase | FALSE Da esta clase</returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        /// <summary>
        /// Profesor igual a Clase si dicta esta
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">EClase</param>
        /// <returns>TRUE Profesor da esta Clase | FALSE No da esta clase</returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            if (i.clasesDelDia.Contains(clase))
                return true;
            return false;
        }

    }
}
