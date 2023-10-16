using System.Globalization;

public class Manager 
{
    public void SummaryTable(Dictionary<string, Clients> ListOfClients, List<Loans> ListOfLoans){
        Console.WriteLine("---------------------");
        foreach (KeyValuePair<string, Clients> dict in ListOfClients)
        {
            Console.WriteLine($"\nTax ID Code: {dict.Value.TaxIdCode}\nName: {dict.Value.FirstName}\nSurname: {dict.Value.LastName}\nSalary: {dict.Value.Salary}\n ");
            string? tempTaxId = dict.Key;
            foreach (Loans loan in ListOfLoans)
            {
                if (tempTaxId == loan.TaxIdCode)
                {
                    Console.WriteLine($"\nLoan amount: {loan.Amount}€\nLoan fee: {loan.Instalment}€/month\nStarted: {loan.StartDate}\nEnds: {loan.EndDate}");
                }
            }
            Console.WriteLine("\n---------------------");
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
            Console.WriteLine("Insert your salary");
            double tempSalary = Convert.ToDouble(Console.ReadLine());
            ListOfClients.Add(tempTaxId, new Clients(tempName, tempLastName, tempTaxId, tempSalary));
            Console.WriteLine("Client successfully added!");
        }
    }
    public void EditClient(Dictionary<string, Clients> ListOfClients){
        Console.WriteLine("Insert the Tax Id Code of the client you want to edit.");
        string? tempTaxId = Console.ReadLine().ToUpper();
        string? tempName = "";
        string? tempLastName = "";
        double tempSalary = 0;
        bool Gotrue = false;
        if (ListOfClients.ContainsKey(tempTaxId))
        {
            bool OptionEdit = false;
            while (!OptionEdit)
            {
                foreach (KeyValuePair<string, Clients> dict in ListOfClients)
                {
                    if (dict.Key == tempTaxId)
                    {
                        Console.WriteLine($"Select what data you want to edit:\n1 - Name: {dict.Value.FirstName}\n2 - Lastname: {dict.Value.LastName}\n3 - Tax Id Code: {dict.Value.TaxIdCode}\n4 - Salary: {dict.Value.Salary}€");
                        int tempChoice = Convert.ToInt32(Console.ReadLine());
                        switch (tempChoice)
                        {
                            case 1:
                            Console.WriteLine("Insert the new name");
                            tempName = Console.ReadLine();
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
                            tempLastName = Console.ReadLine();
                            ListOfClients[tempTaxId] = new Clients(dict.Value.FirstName, tempLastName, dict.Value.TaxIdCode, dict.Value.Salary);
                            Console.WriteLine("Name changed successfully. Do you want to continue edit?\nPress Y to continue");
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
                            tempName = dict.Value.FirstName;
                            tempLastName = dict.Value.LastName;
                            tempSalary = dict.Value.Salary;
                            Gotrue = true;
                            goto Edit;
                            
                            case 4:
                            Console.WriteLine("Insert the new salary");
                            tempSalary = Convert.ToDouble(Console.ReadLine());
                            ListOfClients[tempTaxId] = new Clients(dict.Value.FirstName, dict.Value.LastName, dict.Value.TaxIdCode, tempSalary);
                            Console.WriteLine("Salary changed successfully. Do you want to continue edit?\nPress Y to continue");
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
                Edit:
                if (Gotrue)
                {                    
                    Console.WriteLine("Insert the new Tax Id Code");
                    string? newTempTaxId = Console.ReadLine().ToUpper();
                    if (ListOfClients.ContainsKey(newTempTaxId))
                    {
                        Console.WriteLine("The Tax Id Code inserted altready exist");
                    }
                    else
                    {
                        ListOfClients.Add(newTempTaxId, new Clients (tempName, tempLastName, newTempTaxId, tempSalary));
                        ListOfClients.Remove(tempTaxId);
                        Console.WriteLine("Tax Id Code changed successfully.");
                        OptionEdit = true;
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
                    Console.WriteLine($"Client {dict.Value.FirstName} {dict.Value.LastName}, Tax Id Code: {dict.Value.TaxIdCode} has been successfully deleted");
                }   
            }
            ListOfClients.Remove(tempTaxId);
        }
        else
        {
            Console.WriteLine("!!!!!!-----------!!!!!!\nTax Id Code Error: client not found\n!!!!!!-----------!!!!!!");
        }
    }
    public void SearchClient(Dictionary<string, Clients> ListOfClients){
        Console.WriteLine("Insert the Tax Id Code of the customer you want to search");
        string? tempTaxId = Console.ReadLine().ToUpper();
        if (ListOfClients.ContainsKey(tempTaxId))
        {            
            foreach (KeyValuePair<string, Clients> dict in ListOfClients)
            {
                if (tempTaxId == dict.Key)
                {
                    // dict.Value.ToString();
                    Console.WriteLine($"Tax Id Code: {dict.Value.TaxIdCode}\nName: {dict.Value.FirstName}\nLastname: {dict.Value.LastName}\nSalary: {dict.Value.Salary}");
                }
            }
        }
        else
        {
            Console.WriteLine("Error: Tax Id Code not found!");
        }
    }   
    public List<Loans> SearchLoans(List<Loans> ListOfLoans)
    {
        Console.WriteLine("\nEnter client tax ID code to see accounted loans: ");
        string? tempTaxId = Console.ReadLine().ToUpper();
        if (ListOfLoans.Any(x => x.TaxIdCode == tempTaxId)){
            foreach (Loans loan in ListOfLoans)
            {
                if (tempTaxId == loan.TaxIdCode)
                {
                    System.Console.WriteLine($"\n------------\nLoan accounted to: {loan.TaxIdCode}\nLoan amount: {loan.Amount}€\nLoan fee: {loan.Instalment}€/Month\nStarted: {loan.StartDate}\nEnds: {loan.EndDate}\n------------");
                }
            }
        }
        else
        {
            Console.WriteLine("Error: Tax Id Code not found!");
        }
        return ListOfLoans;
    }
    public List<Loans> AddLoan(List<Loans> loans, Dictionary<string, Clients> ListOfClients)
    {
        Loans loan = new Loans();
        System.Console.WriteLine("Insert the tax id code of the client you want to create a loan for: ");
        string? tempTaxID = Console.ReadLine().ToUpper();
        string format = "dd/MM/yyyy";
        string tempStartDate;
        string tempEndDate;

        if(ListOfClients.ContainsKey(tempTaxID))
        {
            foreach (KeyValuePair<string, Clients> client in ListOfClients)
            {
                if(tempTaxID == client.Key)
                {
                    loan.TaxIdCode = tempTaxID;
                    Console.WriteLine("Insert an amount: ");
                    loan.Amount = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Insert an instalment: ");
                    loan.Instalment = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Insert a starting date (dd/mm/yyyy): ");
                    tempStartDate = Console.ReadLine();
                    loan.StartDate = DateTime.Parse(tempStartDate).ToString(format);
                    Console.WriteLine("Insert an ending date (dd/mm/yyyy): ");
                    tempEndDate = Console.ReadLine();
                    loan.EndDate = DateTime.Parse(tempEndDate).ToString(format); 
                    if (DateTime.ParseExact(loan.StartDate, format, CultureInfo.InvariantCulture) <= DateTime.ParseExact(loan.EndDate, format, CultureInfo.InvariantCulture) )
                    {
                        loans.Add(loan);
                        Console.WriteLine($"\nThis loan has been accounted to '{client.Key}'");
                    }
                    else
                    {
                        Console.WriteLine("Invalid End Date");
                    }
                }     
            }
        }
        else
        {
            System.Console.WriteLine("\nYou entered a wrong ID! Retry.");
        }

        return loans;
    }
    public void PrintLoansStats(List<Loans> loans)
    {
        Console.WriteLine("\nEnter client tax ID code to see accounted loans stats: ");
        string? tempTaxId = Console.ReadLine().ToUpper();

        double loansCounter = 0;
        double loansTot = 0;
        if (loans.Any(x => x.TaxIdCode == tempTaxId)){
            foreach (Loans loan in loans)
            {
                if (tempTaxId == loan.TaxIdCode)
                {
                    loansCounter++;
                    loansTot += loan.Amount;
                    Console.WriteLine($"\n------------\nHere are stats for accounted loans:\nNumber of loans accounted: {loansCounter}\nTotal amount of loans accounted: {loansTot}€\n------------");
                }
            }   
        }

        else
        {
            Console.WriteLine("Error: Tax Id Code not found!");
        }
    }
}