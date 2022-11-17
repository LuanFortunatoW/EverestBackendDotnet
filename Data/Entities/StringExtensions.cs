namespace Data.Entities
{
    public static class StringExtensions
    {
        public static string formatCpf(this string cpf)
        {
            return cpf.Trim().Replace(".","").Replace(",","").Replace("-","");
        }
        internal static string formatPostalCode(this string cpf)
        {
            return cpf.Trim().Replace("-","");
        }
        internal static string formatCellphone(this string cpf)
        {
            return cpf.Trim().Replace("+","").Replace("-","").Replace("(","").Replace(")","");
        }
    }
}
