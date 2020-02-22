using System;
using System.Linq;
using DotNet_Core_Validador_CPF_CNPJ.Services;

namespace DotNet_Core_Validador_CPF_CNPJ
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] cpf = { "529.982.247-25", "777.777.777-77", "52998224725", "123456789900", "111.111.111-11", "759.749.870-55" };

			cpf.ToList().ForEach(cpf => PrintResult(cpf));
		}

		private static void PrintResult(string cpf)
		{
			Console.WriteLine($"O cpf {cpf} é válido? {CPFValidatorService.IsValid(cpf)}");
		}
	}
}
