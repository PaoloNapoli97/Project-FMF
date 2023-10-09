// Ammontare
// Rata
// Data Inizio
// Data fine

public class Loans
{
    private int Amount {get; set;}
    private int Instalment {get; set;}
    private string StartDate {get; set;}
    private string EndDate {get; set;}
    public Loans(int amount, int instalment, string startdate, string enddate){
        Amount = amount;
        Instalment = instalment;
        StartDate = startdate;
        EndDate = enddate;
    }
}