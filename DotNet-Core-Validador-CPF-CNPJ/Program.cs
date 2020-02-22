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
			string[] cnpj = { "16.123.339/0001-15", "11.222.333/0001-XX", "11.111.111/1111-11", "86.655.058/0001-99", "18781203/0001-28" };

			cpf.ToList().ForEach(PrintResult);
			cnpj.ToList().ForEach(PrintResultCnpj);
		}

		private static void PrintResult(string cpf)
		{
			Console.WriteLine($"O cpf {cpf} é válido? {new CPFValidatorService().IsValid(cpf)}");
		}

		private static void PrintResultCnpj(string cnpj)
		{
			Console.WriteLine($"O cnpj {cnpj} é válido? {new CNPJValidatorService().IsValid(cnpj)}");
		}
	}
}
