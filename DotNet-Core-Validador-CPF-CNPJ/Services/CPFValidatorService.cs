namespace DotNet_Core_Validador_CPF_CNPJ.Services
{
	public class CPFValidatorService
	{
		private readonly int[] multiplicationFactorFirstDigit = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
		private readonly int[] multiplicationFactorSecondDigit = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

		public bool IsValid(string cpf)
		{
			string cpfOnlyNumbers = ValidatorUtilService.ExtractNumberFrom(cpf);
			if (HasInvalidFormat(cpfOnlyNumbers))
			{
				return false;
			}

			string firstDigit = CalculateFirstDigit(cpfOnlyNumbers);
			string secondDigit = CalculateSecondDigit(cpfOnlyNumbers, firstDigit);

			return cpfOnlyNumbers.EndsWith(firstDigit + secondDigit);
		}

		private bool HasInvalidFormat(string cpf)
		{
			return cpf.Length > 11 || cpf.Replace(cpf[0].ToString(), "").Length == 0;
		}

		private string CalculateFirstDigit(string cpf)
		{
			var sigma = ValidatorUtilService.CalculateDigit(cpf, multiplicationFactorFirstDigit);
			return CalculateDigitFrom(sigma).ToString();
		}

		private int CalculateDigitFrom(int sigma)
		{
			var digit = (sigma * 10) % 11;
			return digit == 10 ? 0 : digit;
		}

		private string CalculateSecondDigit(string cpf, string firstDigit)
		{
			var cpfWithFirstDigit = cpf.Substring(0, 9) + firstDigit;
			var sigma = ValidatorUtilService.CalculateDigit(cpfWithFirstDigit, multiplicationFactorSecondDigit);
			return CalculateDigitFrom(sigma).ToString();
		}
	}
}
