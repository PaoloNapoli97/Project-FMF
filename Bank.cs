namespace Bank
{
    class Bank
    {
        static void Main(){
            Clients clients = new();
            Dictionary<string, Clients> ListOfClients = new Dictionary<string, Clients>(){
                {"PN32S", new Clients ("Paolo", "Napoli", "PN32S", 23)}
            };

            // Useremo il dictionary usando il codice fiscale come Key per associare la classe utente ed eventuali prestiti, a quello specifico codice fiscale

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("                     BANK");
            Console.WriteLine("---------------------------------------------");

            bool whileloop = false; 
            while (!whileloop)
            {         
                Console.WriteLine("Select one option: \n1 - Print clients Summary Table\n2 - Add client\n3 - Edit client\n4 - Delete client\n5 - Search Client\n6 - Add Loan\n7 - Search Loan\n8 - Amout of Loan given\n0 - Exit");
                int SelectOption = Convert.ToInt32(Console.ReadLine());
                switch (SelectOption)
                {
                    case 1:  //Stampa prospetto riassuntivo dei clienti
                    clients.SummaryTable(ListOfClients);
                    break;

                    case 2:
                    clients.AddClient(ListOfClients);
                    break;

                    case 3:
                    clients.EditClient(ListOfClients);
                    break;

                    case 4:
                    clients.RemoveClients(ListOfClients);
                    break;

                    default:
                    whileloop = true;
                    break;
                }
            }
        }
    }
}