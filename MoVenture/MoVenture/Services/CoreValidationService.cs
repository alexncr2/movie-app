using System;
using System.Collections.Generic;
using System.Text;

namespace MoVenture.Services
{
    public class CoreValidationService : ICoreValidationService
    {
        private static readonly int MIN_PASSWORD_LENGTH = 3;
        private static readonly int MAX_PASSWORD_LENGTH = 20;

        public bool IsLoginValid(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            return true;
        }


        public bool IsRegisterValid(string email, string password, string password2)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(password2))
            {
                return false;
            }
            if (!password.Equals(password2) ||
                !(password.Length == password2.Length && password.Length >= MIN_PASSWORD_LENGTH && password.Length <= MAX_PASSWORD_LENGTH))
            {
                return false;
            }
            return true;
        }
    }
}
