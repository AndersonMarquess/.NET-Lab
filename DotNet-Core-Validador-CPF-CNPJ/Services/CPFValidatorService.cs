namespace DotNet_Core_Validador_CPF_CNPJ.Services
{
	public class CPFValidatorService : ValidatorUtilService
	{
		private readonly int[] _multiplicationFactorFirstDigit = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
		private readonly int[] _multiplicationFactorSecondDigit = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
		protected override int[] multiplicationFactorFirstDigit => _multiplicationFactorFirstDigit;
		protected override int[] multiplicationFactorSecondDigit => _multiplicationFactorSecondDigit;

		protected override bool HasInvalidFormat(string cpf)
		{
			return cpf.Length > 11 || cpf.Replace(cpf[0].ToString(), "").Length == 0;
		}

		protected override int CalculateDigitFrom(int sigma)
		{
			var digit = (sigma * 10) % 11;
			return digit == 10 ? 0 : digit;
		}

		protected override string CalculateSecondDigit(string cpf, string firstDigit)
		{
			var cpfWithFirstDigit = cpf.Substring(0, 9) + firstDigit;
			var sigma = MultiplicateNumberByFactor(cpfWithFirstDigit, _multiplicationFactorSecondDigit);
			return CalculateDigitFrom(sigma).ToString();
		}
	}
}
