using System;

namespace DotNet_Core_Validador_CPF_CNPJ.Services
{
	public class CPFValidatorService
	{
		private static readonly int[] multiplicationFactorCPF1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
		private static readonly int[] multiplicationFactorCPF2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

		public static bool IsValid(string cpf)
		{
			string cpfOnlyNumbers = ExtractNumberFrom(cpf);
			if (IsAllTheSameNumber(cpfOnlyNumbers))
			{
				return false;
			}

			int sigma = 0;
			for (int i = 0; i < multiplicationFactorCPF1.Length; i++)
			{
				sigma += int.Parse(cpfOnlyNumbers.ToCharArray()[i].ToString()) * multiplicationFactorCPF1[i];
			}

			string firstDigit = CalculateDigitFrom(sigma).ToString();
			string secondDigit = CalculateSecondDigitFrom(cpfOnlyNumbers.Substring(0, cpfOnlyNumbers.Length - 2), firstDigit);

			var rightSize = cpfOnlyNumbers.Length == 11;
			var teste1 = cpfOnlyNumbers[9].ToString();
			var rightFirstDigit = teste1.Equals(firstDigit);
			var teste2 = cpfOnlyNumbers[10].ToString();
			var rightSecondDigit = teste2.Equals(secondDigit);
			return rightSize && rightFirstDigit && rightSecondDigit;
		}

		private static bool IsAllTheSameNumber(string cpf)
		{
			return cpf.Replace(cpf[0].ToString(), "").Length == 0;
		}

		private static string CalculateSecondDigitFrom(string cpfWithoutDigit, string firstDigit)
		{
			var sigma = 0;
			var cpfWithFirstDigit = cpfWithoutDigit + firstDigit;
			for (int i = 0; i < multiplicationFactorCPF2.Length; i++)
			{
				sigma += int.Parse(cpfWithFirstDigit[i].ToString()) * multiplicationFactorCPF2[i];
			}
			var secondDigit = CalculateDigitFrom(sigma);
			return secondDigit.ToString();
		}

		private static int CalculateDigitFrom(int sigma)
		{
			var digit = (sigma * 10) % 11;
			return digit == 10 ? 0 : digit;
		}

		private static string ExtractNumberFrom(string cpf)
		{
			return cpf.Replace(" ", "").Replace(".", "").Replace("-", "");
		}
	}
}