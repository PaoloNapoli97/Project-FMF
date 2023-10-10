// Nome
// Cognome
// Codice Fiscale
// Stipendio 
public class Clients
{
    public string? FirstName {get; set;}
    public string? LastName {get; set;}
    public string? TaxIdCode {get; set;}
    public double Salary {get; set;}
    private List<Loans> Loans {get;} = new List<Loans>(); 
    public Clients(string firstname, string lastname, string taxidcode, double salary){
        FirstName = firstname;
        LastName = lastname;
        TaxIdCode = taxidcode;
        Salary = salary;
    }
    public Clients(){}
    public void SummaryTable(Dictionary<string, Clients> ListOfClients){
        // TEST STAMPA DICTIONARY
        foreach (KeyValuePair<string, Clients> dict in ListOfClients)
        {
            Console.WriteLine($"Chiave: {dict.Key}, Valori: \nTax ID Code: {dict.Value.TaxIdCode}\nName: {dict.Value.FirstName}\nSurname: {dict.Value.LastName}\nSalary: {dict.Value.Salary}\n ");
        }
    }
    public void AddClient(Dictionary<string, Clients> ListOfClients){
        Console.WriteLine("Insert name");
        string? tempName = Console.ReadLine(); 
        Console.WriteLine("Insert lastname");
        string? tempLastName = Console.ReadLine(); 
        Console.WriteLine("Insert your Tax Id Code");
        string? tempTaxId = Console.ReadLine().ToUpper();
        if (ListOfClients.ContainsKey(tempTaxId))
        {
            Console.WriteLine("The Tax Id Code inserted altready exist");
        }
        else
        {           
            Console.WriteLine("Inser your salary");
            double tempSalary = Convert.ToDouble(Console.ReadLine());
            ListOfClients.Add(tempTaxId, new Clients(tempName, tempLastName, tempTaxId, tempSalary));
            Console.WriteLine("Client successfully added!");
        }
    }
    public void EditClient(Dictionary<string, Clients> ListOfClients){
        // La modifica è una matriosca non del tutto necessara ma ci tenevo a mettere dei controlli e di dare la possibilità all'utente di modificare anche un solo elemento del dictionary
        Console.WriteLine("Insert the Tax Id Code of the client you want to edit.");
        string? tempTaxId = Console.ReadLine().ToUpper();
        if (ListOfClients.ContainsKey(tempTaxId))
        {
            bool OptionEdit = false;
            while (!OptionEdit)
            {
                foreach (KeyValuePair<string, Clients> dict in ListOfClients)
                {
                    if (dict.Key == tempTaxId)
                    {
                        Console.WriteLine($"Select what data you want to edit:\n1 - Name: {dict.Value.FirstName}\n2 - Lastname: {dict.Value.LastName}\n3 - Tax Id Code: {dict.Value.TaxIdCode}\n4 - Salary: {dict.Value.Salary}");
                        int tempChoice = Convert.ToInt32(Console.ReadLine());
                        switch (tempChoice)
                        {
                            case 1:
                            Console.WriteLine("Insert the new name");
                            string? tempName = Console.ReadLine();
                            ListOfClients[tempTaxId] = new Clients(tempName, dict.Value.LastName, dict.Value.TaxIdCode, dict.Value.Salary);
                            Console.WriteLine("Name changed successfully. Do you want to continue edit?\nPress Y to continue");
                            char ch ;
                            char.TryParse(Console.ReadLine(), out ch);
                            ch = char.ToLower(ch);
                            if (ch == 'y' || ch == 's' )
                            {
                                OptionEdit = false;
                            }
                            else
                            {
                                OptionEdit = true;
                            }
                            break;

                            case 2:
                            Console.WriteLine("Insert the new lastname");
                            string? tempLastName = Console.ReadLine();
                            ListOfClients[tempTaxId] = new Clients(dict.Value.FirstName, tempLastName, dict.Value.TaxIdCode, dict.Value.Salary);
                            Console.WriteLine("Name changed successfully. Do you want to continue edit?\n Press Y to continue");
                            char.TryParse(Console.ReadLine(), out ch);
                            ch = char.ToLower(ch);
                            if (ch == 'y' || ch == 's' )
                            {
                                OptionEdit = false;
                            }
                            else
                            {
                                OptionEdit = true;
                            }
                            break;

                            case 3:
                            // Il caso 3 è sbagliato a livello logico e darà SEMPRE errore, visto che si stava cercando di eleminare ed aggiungere una lista con una key e valori nel mentre
                            // si ciclava nella stessa lista. Con una piccola ricerca si scopre che la KEY del dictionary NON può essere modificata, quindi l'unica soluzione è di aggiungere 
                            // una seconda collezione e di eliminare quella originaria. Pensavo di uscire dal ciclo con un goto ma non avevo considerato che avrei perso i valori originali
                            Console.WriteLine("Insert the new Tax Id Code");
                            string? newTempTaxId = Console.ReadLine();
                            // ListOfClients.Add(newTempTaxId, new Clients (dict.Value.FirstName, dict.Value.LastName, newTempTaxId, dict.Value.Salary));
                            if (ListOfClients.ContainsKey(newTempTaxId))
                            {
                                Console.WriteLine("The Tax Id Code inserted altready exist");
                            }
                            else
                            {
                                ListOfClients.Remove(tempTaxId);
                                Console.WriteLine("Tax Id Code changed successfully.");
                                OptionEdit = true;
                            }
                            break;

                            case 4:
                            Console.WriteLine("Insert the new salary");
                            double tempSalary = Convert.ToDouble(Console.ReadLine());
                            ListOfClients[tempTaxId] = new Clients(dict.Value.FirstName, dict.Value.LastName, dict.Value.TaxIdCode, tempSalary);
                            Console.WriteLine("Salary changed successfully. Do you want to continue edit?\n Press Y to continue");
                            char.TryParse(Console.ReadLine(), out ch);
                            ch = char.ToLower(ch);
                            if (ch == 'y' || ch == 's' )
                            {
                                OptionEdit = false;
                            }
                            else
                            {
                                OptionEdit = true;
                            }
                            break;

                            default:
                            break;
                        }
                    }   
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid Input");
        }
    }
    public void RemoveClients(Dictionary<string, Clients> ListOfClients){
        Console.WriteLine("Insert the Tax Id Code of the client you want to remove from the system");
        string? tempTaxId = Console.ReadLine().ToUpper();
        if (ListOfClients.ContainsKey(tempTaxId))
        {            
            foreach (KeyValuePair<string, Clients> dict in ListOfClients)
            {
                if (dict.Key == tempTaxId)
                {
                    Console.WriteLine($"Client {dict.Value.FirstName} {dict.Value.LastName}, Tax Id Code: {dict.Value.TaxIdCode} h0as been successfully deleted");
                }   
            }
            ListOfClients.Remove(tempTaxId);
        }
        else
        {
            Console.WriteLine("!!!!!!-----------!!!!!!\nTax Id Code Error: client not found\n!!!!!!-----------!!!!!!");
        }
    }
}