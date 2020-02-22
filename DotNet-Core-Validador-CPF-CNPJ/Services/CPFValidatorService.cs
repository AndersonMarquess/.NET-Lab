using System.Text.RegularExpressions;

namespace DotNet_Core_Validador_CPF_CNPJ.Services
{
	public class CPFValidatorService
	{
		private static readonly int[] multiplicationFactorFirstDigit = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
		private static readonly int[] multiplicationFactorSecondDigit = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

		public static bool IsValid(string cpf)
		{
			string cpfOnlyNumbers = ExtractNumberFrom(cpf);
			if (HasInvalidFormat(cpfOnlyNumbers))
			{
				return false;
			}

			string firstDigit = CalculateFirstDigit(cpfOnlyNumbers);
			string secondDigit = CalculateSecondDigitFrom(cpfOnlyNumbers, firstDigit);

			return cpfOnlyNumbers.EndsWith(firstDigit + secondDigit);
		}

		private static string ExtractNumberFrom(string cpf)
		{
			return Regex.Replace(cpf, "[^\\d]", "");
		}

		private static bool HasInvalidFormat(string cpf)
		{
			return cpf.Length > 11 || cpf.Replace(cpf[0].ToString(), "").Length == 0;
		}

		private static string CalculateFirstDigit(string cpf)
		{
			return CalculateDigitFrom(cpf, multiplicationFactorFirstDigit);
		}

		private static string CalculateDigitFrom(string cpf, int[] multiplicationFactor)
		{
			int sigma = 0;
			for (int i = 0; i < multiplicationFactor.Length; i++)
			{
				sigma += int.Parse(cpf[i].ToString()) * multiplicationFactor[i];
			}
			return CalculateDigitFrom(sigma).ToString();
		}

		private static int CalculateDigitFrom(int sigma)
		{
			var digit = (sigma * 10) % 11;
			return digit == 10 ? 0 : digit;
		}

		private static string CalculateSecondDigitFrom(string cpf, string firstDigit)
		{
			var cpfWithFirstDigit = cpf + firstDigit;
			return CalculateDigitFrom(cpfWithFirstDigit, multiplicationFactorSecondDigit);
		}
	}
}