using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class Calculadora
	{
		private static string ValidarOperador(string operador)
		{
			if (operador.Equals("+") || operador.Equals("-") || operador.Equals("*") || operador.Equals("/")) // COMPARO STRING CON OPERADOR VALIDO
				return operador; // SI ES VALIDO RETORNO OPERADOR

			return "+";
		}
		public double Operar(Numero num1, Numero num2, string operador)
		{
			double resultado = 0;
			operador = ValidarOperador(operador);
			switch (operador)
			{
				case "+":
					resultado = num1 + num2;
					break;
				case "-":
					resultado = num1 - num2;
					break;
				case "*":
					resultado = num1 * num2;
					break;
				case "/":
					resultado = num1 / num2;
					break;
			}
			return resultado;
		}
	}
}
