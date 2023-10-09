namespace BankProgram
{
    class Program
    {
        static void Main(){
            Clients clients = new();
            Dictionary<string, Clients> ListOfClients = new Dictionary<string, Clients>();
            // Useremo il dictionary usando il codice fiscale come Key per associare la classe utente ed eventuali prestiti, a quello specifico codice fiscale

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("                     BANK");
            Console.WriteLine("---------------------------------------------");

            bool whileloop = false; 
            while (!whileloop)
            {         
                Console.WriteLine("Select one option: \n1 - Print clients Summary Table\n2 - Add client\n3 - Edit client\n4 - Delete client\n5 - Add Loan\n6 - Search Loan\n7 - Amout of Loan given");
                int SelectOption = Convert.ToInt32(Console.ReadLine());
                switch (SelectOption)
                {
                    case 1:  //Stampa prospetto riassuntivo dei clienti
                    clients.SummaryTable();

                    break;
                }
            }
        }
    }
}