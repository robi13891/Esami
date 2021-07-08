using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//L'utente può:
//- vedere tutti gli esami,
//- aggiungere un nuovo appello,
//- eliminare un appello,
//- filtrare gli appelli per tipo,

//Al termine delle operazioni vengono salvati gli appelli su file
//!!!  Attenzione : la data dell'appello deve essere almeno 10 giorni dopo la data di inserimento dell'appello

namespace Esami
{
    class Manager
    {
        static List<Appello> appelli = new List<Appello>();

        public static void MostraAppelli(List<Appello> appelli)
        {
            int count = 1;
            if (appelli.Count > 0)
            {
                foreach (Appello appello in appelli)
                {
                    Console.WriteLine($"{count} --> Materia: {appello.Materia}\tData: {appello.DataEsame}\tTipologia: {appello.TipoEsame}");
                    count++;
                }
            }
            else
            {
                Console.WriteLine("Non sono presenti appelli");
            }
        }

        public static void MostraAppelli()
        {
            MostraAppelli(appelli);
        }
        public static void AggiungiAppello()
        {
            Appello appello = new Appello();
            Console.Write("Inserisci la materia: ");
            appello.Materia = Console.ReadLine();
            DateTime dataInserimento = DateTime.Now;
            Console.WriteLine("Inserisci la data dell'esame: ");
            DateTime dataEsame = DateTime.Parse(Console.ReadLine());
            while (!(dataEsame > dataInserimento.AddDays(10)))
            {
                Console.WriteLine("La data dell'appello deve essere almeno 10 giorni dopo la data dell'inserimento!\nInserisci la data dell'esame");
                dataEsame = DateTime.Parse(Console.ReadLine());
            }
            appello.DataEsame = dataEsame;
            appello.TipoEsame = SceltaTipo();
            appelli.Add(appello);

        }

        public static void EliminaAppello()
        {
            Console.WriteLine("Inserisci il numero dell'appello che vuoi eliminare");
            MostraAppelli();
            Console.Write("Scelta: ");
            bool isInteger = int.TryParse(Console.ReadLine(), out int scelta);
            while (!isInteger)
            {
                Console.Write("Scelta non valida!\nScelta: ");
                isInteger = int.TryParse(Console.ReadLine(), out scelta);
            }
            Appello appelloDaEliminare = new Appello();
            appelloDaEliminare = appelli.ElementAt(scelta - 1);
            appelli.Remove(appelloDaEliminare);
        }

        public static void FiltraTipoAppello()
        {
            List<Appello> appelliFiltrati = new List<Appello>();
            Tipologia tipologiaAppello = SceltaTipo();
            foreach (Appello appello in appelli)
            {
                if (appello.TipoEsame == tipologiaAppello)
                {
                    appelliFiltrati.Add(appello);
                }
            }
            MostraAppelli(appelliFiltrati);

        }

        public static Tipologia SceltaTipo()
        {
            Console.WriteLine($"Premi {(int)Tipologia.Scritto} per {Tipologia.Scritto}");
            Console.WriteLine($"Premi {(int)Tipologia.Orale} per {Tipologia.Orale}");
            Console.Write("Scelta: ");
            bool isInteger = int.TryParse(Console.ReadLine(), out int sceltaTipologia);
            while (!(isInteger && sceltaTipologia >= 0 && sceltaTipologia <= 1))
            {
                Console.Write("Scelta: ");
                isInteger = int.TryParse(Console.ReadLine(), out sceltaTipologia);
            }
            return (Tipologia)sceltaTipologia;
        }

        public static void SalvaSuFile()
        {
            string path = @"C:\Users\utente\Desktop\Esercizi\Week2\Appelli.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Appello appello in appelli)
                {
                    sw.WriteLine($"Materia: {appello.Materia}\n ");
                }
            }

        }
    }
