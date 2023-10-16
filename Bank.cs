using System.Text.Json;
using System.IO;

namespace Bank
{
    class Bank
    {
        static void Main(){
            FileManager fileManager = new FileManager();
            fileManager.CreateFileClients();
            fileManager.CreateFileLoans();
            List<Loans> loans = new List<Loans>();
            Dictionary<string, Clients> ListOfClients = new Dictionary<string, Clients>(){
                // {"PN32S", new Clients ("Paolo", "Napoli", "PN32S", 23)},
                // {"CL05A", new Clients ("Claudio", "Leone", "CL05A", 21)},
                // {"GP12Z", new Clients ("Gino", "Paoli", "GP12Z", 5)}
            };
            ListOfClients = fileManager.ReadDictionaryFromCsv();
            loans = fileManager.ReadListFromCsv();
            Manager bankManager = new Manager();
            // Useremo il dictionary usando il codice fiscale come Key per associare la classe utente ed eventuali prestiti, a quello specifico codice fiscale

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("                BANK UNIFROGS");
            Console.WriteLine("---------------------------------------------");

            bool whileloop = false; 
            while (!whileloop)
            {   
                Console.WriteLine("\nSelect one option: \n1 - Print clients Summary Table\n2 - Add client\n3 - Edit client\n4 - Delete client\n5 - Search Client\n6 - Add Loan\n7 - Search Loan\n8 - Amout of Loan given\n0 - Exit");
                int SelectOption = Convert.ToInt32(Console.ReadLine());
                switch (SelectOption)
                {
                    case 1:  //Stampa prospetto riassuntivo dei clienti
                    bankManager.SummaryTable(ListOfClients, loans);
                    break;

                    case 2:
                    bankManager.AddClient(ListOfClients);
                    break;

                    case 3:
                    bankManager.EditClient(ListOfClients);
                    break;

                    case 4:
                    bankManager.RemoveClients(ListOfClients);
                    break;

                    case 5:
                    bankManager.SearchClient(ListOfClients);
                    break;

                    case 6:
                    loans.Concat(bankManager.AddLoan(loans, ListOfClients));
                    break;

                    case 7:
                    bankManager.SearchLoans(loans);
                    break;

                    case 8:
                    bankManager.PrintLoansStats(loans);
                    break;

                    default:
                    fileManager.WriteDictionaryToCsv(ListOfClients);
                    fileManager.WriteListToCsv(loans);
                    whileloop = true;
                    break;
                }
            }
        }
    }
}