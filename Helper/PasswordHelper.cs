using System.Text.RegularExpressions;

namespace ASPWebApp.Helpers
{
    public static class PasswordHelper
    {
        /// <summary>
        /// Validates a password for:
        /// - At least 8 characters
        /// - At least one uppercase letter
        /// - At least one number
        /// </summary>
        public static bool IsValid(string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Password cannot be empty.";
                return false;
            }

            if (password.Length < 8)
            {
                errorMessage = "Password must be at least 8 characters long.";
                return false;
            }

            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                errorMessage = "Password must contain at least one uppercase letter.";
                return false;
            }

            if (!Regex.IsMatch(password, "[0-9]"))
            {
                errorMessage = "Password must contain at least one number.";
                return false;
            }

            return true;
        }
    }
}
