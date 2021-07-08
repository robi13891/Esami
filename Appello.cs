using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Un appello ha:
//- un nome(materia),
//- una data di verbalizzazione,
//- la tipologia(Scritto o orale),

namespace Esami
{
    class Appello
    {
        public string Materia { get; set; }
        public DateTime DataEsame { get; set; }
        public Tipologia TipoEsame { get; set; }

        public Appello()
        {

        }

    }

    enum Tipologia
    {
        Scritto,
        Orale
    }
}
