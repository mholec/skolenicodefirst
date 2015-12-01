using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SkoleniCodeFirst.ZakladniSchemaAnotace.OwnAnnotation
{
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            return IsValidEmail(value.ToString());
        }

        private bool IsValidEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                return true;
            }

            return false;
        }
    }
}
