// Ammontare
// Rata
// Data Inizio
// Data fine

public class Loans
{
    private Clients Clients {get;}
    public double Amount {get; set;}
    public double Instalment {get; set;}
    public string StartDate {get; set;}
    public string EndDate {get; set;}
    public Loans(double amount, double instalment, string startdate, string enddate, Clients clients){
        Amount = amount;
        Instalment = instalment;
        StartDate = startdate;
        EndDate = enddate;
        Clients = clients; 
    }
}