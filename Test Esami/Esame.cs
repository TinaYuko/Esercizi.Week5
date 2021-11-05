using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Esami
{
    public class Esame
    {
        /*Un esame tiene conto del corso e se è passato o non passato. */
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Passato { get; set; }
        public int IdStudente { get; set; }

        public Esame()
        {

        }
    }
}
