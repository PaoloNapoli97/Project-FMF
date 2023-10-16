// Ammontare
// Rata
// Data Inizio
// Data fine

public class Loans
{
    public double Amount {get; set;}
    public double Instalment {get; set;}
    public string StartDate {get; set;}
    public string EndDate {get; set;}
    public string TaxIdCode {get; set;}
    public Loans(double amount, double instalment, string startdate, string enddate, string taxID){
        Amount = amount;
        Instalment = instalment;
        StartDate = startdate;
        EndDate = enddate;
        TaxIdCode = taxID;
    }
    public Loans(){}
}