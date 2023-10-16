using CsvHelper;
public class FileManager
{
    static string filepathClients = "clients.csv";
    static string filepathLoans = "loans.csv";
    public void CreateFileClients(){
    try
    {
        if (!File.Exists(filepathClients))
        {
            using (StreamWriter file = File.CreateText(filepathClients)){}
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred while creating file: " + ex.Message);
    }
    }
    public void CreateFileLoans(){
    try
        {
            if (!File.Exists(filepathLoans))
            {
                using (StreamWriter file = File.CreateText(filepathLoans)){}
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while creating file: " + ex.Message);
        }
    }
    public void WriteDictionaryToCsv(Dictionary<string, Clients> ListOfClients)
    {
        try
        {
            using (var writer = new StreamWriter(filepathClients)) // Overwrite existing file
            using (var csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(ListOfClients.Select(kv => new { Id = kv.Key, Client = kv.Value }));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while writing the dictionary to the CSV file: " + ex.Message);
        }
    }
    public void WriteListToCsv(List<Loans> loans)
    {
        try
        {
            using (var writer = new StreamWriter(filepathLoans)) // Overwrite existing file
            using (var csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(loans);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while writing the list to the CSV file: " + ex.Message);
        }
    }
    public Dictionary<string, Clients> ReadDictionaryFromCsv()
    {
        Dictionary<string, Clients> ListOfClients = new Dictionary<string, Clients>();

        try
        {
            using (var reader = new StreamReader(filepathClients))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Clients>();
                foreach (var record in records)
                {
                    ListOfClients.Add(record.TaxIdCode, record);  // Use TaxIdCode as key
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while reading the dictionary from the CSV file: " + ex.Message);
        }

        return ListOfClients;
    }
    public List<Loans> ReadListFromCsv()
    {
        List<Loans> loans = new List<Loans>();

        try
        {
            using (var reader = new StreamReader(filepathLoans))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
            {
                loans = new List<Loans>(csv.GetRecords<Loans>());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while reading the list from the CSV file: " + ex.Message);
        }

        return loans;    
    }
}