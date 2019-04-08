using System;
using System.Collections.Generic;
using System.Text;

namespace MoVenture
{
    public interface ICoreValidationService
    {
        bool IsLoginValid(string email, string password);
        bool IsRegisterValid(string email, string password, string password2);
    }
}
