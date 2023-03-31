using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public interface ICurrentEmail
    {
        bool CheckEmail(string email);
    }

    public class CurrentEmail : ICurrentEmail
    {
        public bool CheckEmail(string email)
        {
            if (email == null) { }
            return false;
        }
    }
}
