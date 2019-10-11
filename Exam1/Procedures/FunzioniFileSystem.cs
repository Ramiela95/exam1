using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Exam1.Procedures
{
    class FunzioniFileSystem
    {
        public static string AssicuratiCheEsistaCartellaDiArchivio()
        {
            //1) Compongo il percorso della cartella di lavoro
            var workingFolder = AppDomain.CurrentDomain.BaseDirectory;

            const string DataFolderName = "data";

            //Composizone del percorso della folder
            var folderPath = Path.Combine(workingFolder, DataFolderName);

            //Se non esiste, la creo
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            return folderPath;
        }

        private static string ComponiPercorsoFileDatabase(string archiveFolder)
        {
            const string DataBaseFileName = "database.txt";

            //Composizione del percorso del file database
            string databasePath = Path.Combine(archiveFolder, DataBaseFileName);

            //Ritorno il percorso
            return databasePath;
        }

        internal static void AggiungiTestoAFileDatabase(string testoDiProva, string archiveFolder)
        {
            var databasePath = ComponiPercorsoFileDatabase(archiveFolder);

            //Se il file non esiste, creo il file e aggiungo il testo
            if (!File.Exists(databasePath))
            {
                //Creazione dello stream in Create
                using (StreamWriter writer = File.CreateText(databasePath))
                {
                    writer.WriteLine(testoDiProva);
                    writer.Close();
                }
            }
            else
            {
                //Creazione dello stream in Append
                using (StreamWriter writer = File.AppendText(databasePath))
                {
                    writer.WriteLine(testoDiProva);
                    writer.Close();
                }
            }
        }
    }
}
