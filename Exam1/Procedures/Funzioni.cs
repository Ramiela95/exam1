using System;
using System.Collections.Generic;
using System.Text;
using Exam1.Utils;
using Exam1.Entities;



namespace Exam1.Procedures
{
    class Funzioni
    {
        public static void InserisciNumeroArbitrarioProdottiInElenco()
        {
            //1) Richiedo il numero di prodotti da inserire
            Console.WriteLine("Quanti prodotti vuoi inserire (da 1 a 10)? ");
            int totalProducts = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 9);

            

            //Dimensionamento dell'elenco
            Product[] elenco = new Product[totalProducts];


            //4) Itero per il numero di persone richiesto
            for (int index = 0; index < totalProducts; index++)
            {
                //Richiamo una funzione a cui passo la rubrica
                //e l'indice corrente e questa mi aggiunge la persona
                AggiungiProdottoAElencoInPosizione(elenco,index);
            }

            //9) Itero la rubrica e stampo a video (con for) tutte le persone
            StampaElenco(elenco);

            
        }

        private static void AggiungiProdottoAElencoInPosizione(Product[] elenco, int index)
        {
            //5) Richiedo il nome e cognome della persona
            Console.Write("nome: ");
            var nome = Console.ReadLine();
            Console.Write("codice: ");
            var codiceStr = Console.ReadLine();
            int codice=int.Parse(codiceStr);


            //6) Creo oggetto Product da inserire in elenco
            Product prodotto = new Product();
            {
                prodotto.Name = nome;
                prodotto.Code = codice;
                
            };

            //7) Aggiungo prodotto a elenco
            elenco[index] = prodotto;

            //Aggiungo la persona al file database
            SalvaProdottoInFile(prodotto);

            //8) Se ho inserito tutte le persone termino il ciclo
        }

        private static void StampaElenco(Product[] elenco)
        {
            Console.WriteLine("*** Visualizzazione contenuto elenco***");
            for (var index = 0; index < elenco.Length; index++)
            {
                Console.WriteLine($" => {elenco[index].Name}, {elenco[index].Code}");
                //Console.WriteLine(" => " + rubrica[index].FirstName + ", " + rubrica[index].LastName);
            }
        }

        private static void SalvaProdottoInFile(Product prodotto)
        {
            //Assicuriamoci che esista la folder per il file di archivio
            var archiveFolder = FunzioniFileSystem.AssicuratiCheEsistaCartellaDiArchivio();
            //** Arrivo a questo punto e sono sicuro al 100% che la cartella dove
            //** sarà conservato il file database esiste: ne ottengo il percorso

            string datiDelProdottoInFormatoStringa = ConvertiProdottoInStringa(prodotto);

            //Aggiungi testo a file
            FunzioniFileSystem.AggiungiTestoAFileDatabase(datiDelProdottoInFormatoStringa, archiveFolder);
        }

        private static string ConvertiProdottoInStringa(Product prodotto)
        {
            return $"{prodotto.Name},{prodotto.Code.ToString()}";
        }

    }
}
