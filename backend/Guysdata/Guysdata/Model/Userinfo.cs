using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guysdata.Model
{
    public class Userinfo
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
    }
}
