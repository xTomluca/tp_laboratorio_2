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
            System.Threading.Thread.Sleep(2000);
            this.clasesDelDia.Enqueue((EClases)random.Next(4));
            System.Threading.Thread.Sleep(2000);
            this.clasesDelDia.Enqueue((EClases)random.Next(4));
        }
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase()); /// DUDA!!!
            return sb.ToString();
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CLASES DEL DIA");
            foreach(EClases c in this.clasesDelDia)
            {
                sb.Append("");
                sb.Append(c);
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
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        public static bool operator ==(Profesor i, EClases clase)
        {
            if (i.clasesDelDia.Contains(clase))
                return true;
            return false;
        }

    }
}
