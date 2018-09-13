using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class Numero
	{
		private double numero;
		private string setNumero
		{
			set
			{
				numero = ValidarNumero(value);
			}
		}
		public Numero()
		{
			
		}
		public Numero(double numero)
		{
			this.numero = numero;
		}
		public Numero(string strNumero)
		{
			this.numero = ValidarNumero(strNumero);
		}
		private double ValidarNumero(string strNumero)
		{
			double retorno = 0;
			double.TryParse(strNumero, out retorno);
			return retorno;
		}
		public string BinarioDecimal(string binario)
		{
			string cimalStr = "Valor Invalido";
			int cimal = 0;

			foreach (char c in binario)
				if (c != '0' && c != '1')
					return cimalStr;

			for (int i = 0; i < binario.Length; i++)
			{
				int aux = int.Parse(binario[i].ToString());
				cimal += aux * (int)Math.Pow(2, binario.Length - 1 - i);
			}
			return cimal.ToString();
		}
		public string DecimalBinario(double numero)
		{
			string binario = "";
			while (numero > 0)
			{
				if (Math.Round(numero) % 2 == 0)
					binario += '0';
				if (Math.Round(numero) % 2 == 1)
					binario += '1';
				numero = (int)(numero / 2);
			}
			return binario;
		}
		public string DecimalBinario(string numero)
		{
			double aux = 0;
			if (double.TryParse(numero, out aux))
				return DecimalBinario(aux);
			return "Valor Invalido";
		}
		public static double operator -(Numero n1, Numero n2)
		{
			return (n1.numero - n2.numero);
		}
		public static double operator *(Numero n1, Numero n2)
		{
			return (n1.numero * n2.numero);
		}
		public static double operator /(Numero n1, Numero n2)
		{
			return (n1.numero / n2.numero);
		}
		public static double operator  +(Numero n1, Numero n2)
		{
			return (n1.numero + n2.numero);
		}

	}
}
