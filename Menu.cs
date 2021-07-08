using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esami
{
    class Menu
    {
        //L'utente può:
        //- vedere tutti gli esami,
        //- aggiungere un nuovo appello,
        //- eliminare un appello,
        //- filtrare gli appelli per tipo,
        public static void Start()
        {
            Console.WriteLine("Benvenuto nel menù appelli!");
            int keepGoing = 1;
            do
            {
                Console.WriteLine("1: Aggiungi appello\n2: Elimina appello\n3: Vedi tutti gli appelli\n4: Filtra appelli per tipo");
                bool isSuccessful = int.TryParse(Console.ReadLine(), out int indexMenu);
                while(!(isSuccessful && indexMenu>=1 && indexMenu <= 4))
                {
                    isSuccessful = int.TryParse(Console.ReadLine(), out indexMenu);
                }
                switch (indexMenu)
                {
                    case 1:
                        Manager.AggiungiAppello();
                        break;
                    case 2:
                        Manager.EliminaAppello();
                        break;
                    case 3:
                        Manager.MostraAppelli(); 
                        break;
                    case 4:
                        Manager.FiltraTipoAppello();
                        break;
                }

                Console.WriteLine("Premi 1 per continuare, altrimenti premi 0");
                keepGoing = int.Parse(Console.ReadLine());
            
            } while (keepGoing == 1);
        }


    }

}
