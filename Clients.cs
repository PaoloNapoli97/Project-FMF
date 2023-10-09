// Nome
// Cognome
// Codice Fiscale
// Stipendio 
public class Clients
{
    public string? FirstName {get; set;}
    public string? LastName {get; set;}
    public string? TaxIdCode {get; set;}
    public int Salary {get; set;}
    public List<Loans> Loans= new List<Loans>();
    public Clients(string firstname, string lastname, string taxidcode, int salary){
        FirstName = firstname;
        LastName = lastname;
        TaxIdCode = taxidcode;
        Salary = salary;
    }
    public Clients(){}
    public void SummaryTable(Dictionary<string, Clients> ListOfClients){
        // TEST STAMPA DICTIONARY

        // foreach (KeyValuePair<string, ob> elmClient in Bank.ListOfClients)
        // {
            // ListOfClients.add  
            // Console.WriteLine($"Key: {TaxIdCode}, Value: {FirstName} {LastName} {Salary} {TaxIdCode}");
        // }
    }
}