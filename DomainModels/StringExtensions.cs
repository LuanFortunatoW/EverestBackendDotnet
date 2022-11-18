namespace DomainModels
{
    public static class StringExtensions
    {
        public static string formatCpf(this string cpf)
        {
            return cpf.Trim().Replace(".", "").Replace(",", "").Replace("-", "");
        }
        public static string formatPostalCode(this string postalCode)
        {
            return postalCode.Trim().Replace("-", "");
        }
        public static string formatCellphone(this string cellphone)
        {
            return cellphone.Trim().Replace("+", "").Replace("-", "").Replace("(", "").Replace(")", "");
        }
    }
}