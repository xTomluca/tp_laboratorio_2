﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        int legajo;
        public override bool Equals(object obj)
        {
            if(this.GetType() == obj.GetType() && (((Universitario)obj).legajo == this.legajo || (this.DNI==((Universitario)obj).DNI)))
            {
                return true;
            }
            return false;
        }
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("Legajo: {0}\n", this.legajo);
            return sb.ToString();
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1==pg2);
        }
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        protected abstract string ParticiparEnClase();

        public Universitario()
        {

        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

    }
}
