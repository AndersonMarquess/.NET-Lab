using System.Text.RegularExpressions;
namespace DotNet_Core_Validador_CPF_CNPJ.Services
{
	public static class ValidatorUtilService
	{
		public static string ExtractNumberFrom(string source)
		{
			return Regex.Replace(source, "[^\\d]", "");
		}

		public static int CalculateDigit(string cnpjOnlyNumber, int[] multiplicationFactor)
		{
			int sigma = 0;
			for (int i = 0; i < multiplicationFactor.Length; i++)
			{
				sigma += int.Parse(cnpjOnlyNumber[i].ToString()) * multiplicationFactor[i];
			}
			return sigma;
		}
	}
}
