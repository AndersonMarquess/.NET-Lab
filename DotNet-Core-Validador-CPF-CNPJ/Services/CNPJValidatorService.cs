namespace DotNet_Core_Validador_CPF_CNPJ.Services
{
	public class CNPJValidatorService
	{
		private readonly int[] multiplicationFactorFirstDigit = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
		private readonly int[] multiplicationFactorSecondDigit = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

		public bool IsValid(string cnpj)
		{
			var cnpjOnlyNumber = ValidatorUtilService.ExtractNumberFrom(cnpj);
			if (HasInvalidFormat(cnpjOnlyNumber))
			{
				return false;
			}

			string firstDigit = CalculateFirstDigit(cnpjOnlyNumber);
			string secondDigit = CalculateSecondDigit(cnpjOnlyNumber, firstDigit);

			return cnpjOnlyNumber.EndsWith(firstDigit + secondDigit);
		}

		private bool HasInvalidFormat(string cnpj)
		{
			return cnpj.Length > 14;
		}

		private string CalculateFirstDigit(string cnpjOnlyNumber)
		{
			var sigma = ValidatorUtilService.CalculateDigit(cnpjOnlyNumber, multiplicationFactorFirstDigit);
			return CalculateDigitFrom(sigma).ToString();
		}

		private int CalculateDigitFrom(int sigma)
		{
			var digit = sigma % 11;
			return digit < 2 ? 0 : 11 - digit;
		}

		private string CalculateSecondDigit(string cnpjOnlyNumber, string firstDigit)
		{
			var cnpjWithDigit = cnpjOnlyNumber.Substring(0, 12) + firstDigit;
			var sigma = ValidatorUtilService.CalculateDigit(cnpjWithDigit, multiplicationFactorSecondDigit);
			return CalculateDigitFrom(sigma).ToString();
		}
	}
}
