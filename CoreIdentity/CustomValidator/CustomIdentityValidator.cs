using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CoreIdentity.CustomValidator
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Parola minumum {length} karakter olmalıdır"
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Parola bir alfanumerik karakter (!.) içermelidir"
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "DuplicateUserName",
                Description = $"İlgili kullanıcı adı ({userName}) zaten sistemde kayıtlı"
            };
        }

        
    }
}
