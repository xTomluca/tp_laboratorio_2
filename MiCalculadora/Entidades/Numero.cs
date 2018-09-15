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
			double.TryParse(strNumero, out retorno);  // CONVIERTO DE STRING A DOUBLE Y RETORNO
			return retorno;
		}
		public string BinarioDecimal(string binario)
		{
			string cimalStr = "Valor Invalido";
			int dcimal = 0;

			for (int i = 0; i < binario.Length; i++)
			{
				if (binario[i] != '0' && binario[i] != '1') // VERIFICO QUE SEA NUEVO BINARIO 
					return cimalStr;                        // CASO CONTRARIO DEVUELVO VALOR INVALIDO

				int aux = int.Parse(binario[i].ToString());
				dcimal += aux * (int)Math.Pow(2, binario.Length - 1 - i); // MULTIPLICO AUX POR POTENCIA EN BASE 2 Y LA SUMO A DECIMAL 
			}
			return dcimal.ToString();
		}
		public string DecimalBinario(double numero)
		{
			string binario = "";
			numero = Math.Abs(numero); // OBTENGO VALOR ABSOLUTO ( POSITIVO )
			while (numero > 0)
			{
				if (Math.Round(numero) % 2 == 0) // SI EL RESTO ES 0 AGREGO UN 0 EN MI STRING
					binario += '0';
				if (Math.Round(numero) % 2 == 1) // SI EL RESTO ES 1 AGREGO UN 1 EN MI STRING
					binario += '1';
				numero = (int)(numero / 2);
			}
			char[] arrayTemp = binario.ToArray(); // CONVIERTO STRING EN ARRAY
			Array.Reverse(arrayTemp);	// DOY VUELTA EL ARRAY

			return arrayTemp.ToString(); // DEVUELVO STRING 
		}
		public string DecimalBinario(string numero)
		{
			double aux = 0;
			if (double.TryParse(numero, out aux)) // SI ES NUMERO VALIDO Y PASO AL METODO SOBRECARGADO CON DOUBLE
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
