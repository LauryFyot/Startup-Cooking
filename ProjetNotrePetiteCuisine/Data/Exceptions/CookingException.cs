using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNotrePetiteCuisine.Data.Exceptions
{
    public class CookingException : Exception
    {
        public CookingException(string msg) : base(msg) { }
    }
}
