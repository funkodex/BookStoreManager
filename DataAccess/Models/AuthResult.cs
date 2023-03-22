using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class AuthResult
    {
        public bool IsAuthenticated { get; set; }
        public List<string> Errors { get; set; }

        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }
    }

    public class PasswordRecoveryResult
    {
        public bool IsRecovered { get; set; }
        public bool IsEmailSent { get; set; }
        public List<string> Errors { get; set; }

    }


}
