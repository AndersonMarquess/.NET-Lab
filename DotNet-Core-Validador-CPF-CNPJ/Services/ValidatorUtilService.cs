using System.Text.RegularExpressions;
namespace DotNet_Core_Validador_CPF_CNPJ.Services
{
	public abstract class ValidatorUtilService
	{
		protected abstract int[] multiplicationFactorFirstDigit { get; }
		protected abstract int[] multiplicationFactorSecondDigit { get; }

		public bool IsValid(string cnpj)
		{
			var cnpjOnlyNumber = ExtractNumberFrom(cnpj);
			if (HasInvalidFormat(cnpjOnlyNumber))
			{
				return false;
			}

			string firstDigit = CalculateFirstDigit(cnpjOnlyNumber);
			string secondDigit = CalculateSecondDigit(cnpjOnlyNumber, firstDigit);

			return cnpjOnlyNumber.EndsWith(firstDigit + secondDigit);
		}

		public string ExtractNumberFrom(string source)
		{
			return Regex.Replace(source, "[^\\d]", "");
		}

		private string CalculateFirstDigit(string cnpjOnlyNumber)
		{
			var sigma = MultiplicateNumberByFactor(cnpjOnlyNumber, multiplicationFactorFirstDigit);
			return CalculateDigitFrom(sigma).ToString();
		}

		public int MultiplicateNumberByFactor(string cnpjOnlyNumber, int[] multiplicationFactor)
		{
			int sigma = 0;
			for (int i = 0; i < multiplicationFactor.Length; i++)
			{
				sigma += int.Parse(cnpjOnlyNumber[i].ToString()) * multiplicationFactor[i];
			}
			return sigma;
		}

		protected abstract bool HasInvalidFormat(string cnpj);
		protected abstract int CalculateDigitFrom(int sigma);
		protected abstract string CalculateSecondDigit(string cnpjOnlyNumber, string firstDigit);
	}
}
