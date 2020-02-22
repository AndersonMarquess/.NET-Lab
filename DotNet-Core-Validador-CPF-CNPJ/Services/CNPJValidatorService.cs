namespace DotNet_Core_Validador_CPF_CNPJ.Services
{
	public class CNPJValidatorService : ValidatorUtilService
	{
		private readonly int[] _multiplicationFactorFirstDigit = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
		private readonly int[] _multiplicationFactorSecondDigit = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
		protected override int[] multiplicationFactorFirstDigit => _multiplicationFactorFirstDigit;
		protected override int[] multiplicationFactorSecondDigit => _multiplicationFactorSecondDigit;

		protected override bool HasInvalidFormat(string cnpj)
		{
			return cnpj.Length > 14;
		}

		protected override int CalculateDigitFrom(int sigma)
		{
			var digit = sigma % 11;
			return digit < 2 ? 0 : 11 - digit;
		}

		protected override string CalculateSecondDigit(string cnpjOnlyNumber, string firstDigit)
		{
			var cnpjWithDigit = cnpjOnlyNumber.Substring(0, 12) + firstDigit;
			var sigma = MultiplicateNumberByFactor(cnpjWithDigit, multiplicationFactorSecondDigit);
			return CalculateDigitFrom(sigma).ToString();
		}
	}
}
