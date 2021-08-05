using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstoreAPI.models
{
    public class Libri
    {
        public int libriID { get; set; }
        public string libriImage { get; set; }
        public string titulli { get; set; }
        public int nr_faqev { get; set; }
        public int  isbn{ get; set; }
        public decimal price { get; set; }
        public int autoriID { get; set; }
    }
}
