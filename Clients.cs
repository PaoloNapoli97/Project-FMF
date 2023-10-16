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
    public List<Loans> Loans {get; set;} = new List<Loans>();
    public Clients(string firstname, string lastname, string taxidcode, double salary){
        FirstName = firstname;
        LastName = lastname;
        TaxIdCode = taxidcode;
        Salary = salary;
    }
    public Clients(){}
    public override string ToString()
    {
        return $"Tax Id Code {TaxIdCode}\nName: {FirstName}\nLast Name: {LastName}\nSalary: {Salary}";
    }
}