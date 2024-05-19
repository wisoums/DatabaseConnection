namespace DatabaseConnection;

public class Program
{
    public static List<SqlConnection> allSqlConnections = new List<SqlConnection>();
    public static List<OracleConnection> allOracleConnections = new List<OracleConnection>();

    public static void displayMenu()
    {
        Console.WriteLine("****************************" +
                          "\n1- Create a new SQL Connection" + 
                          "\n2- Create a new Oracle Connection" + 
                          "\n3- Display all SQL Connections" + 
                          "\n4- Display all Oracle Connections" + 
                          "\n5- Open a SQL Connection" +
                          "\n6- Open an Oracle Connection" +
                          "\n7- Close a SQL Connection" +
                          "\n8- Close an Oracle Connection" +
                          "\n9- Execute a SQL Connection" +
                          "\n10- Execute an Oracle Connection" +
                          "\n0- Quit" +
                          "\n****************************");
    }

    public static int takeInputChoice()
    {
        Console.Write("Enter a choice: ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || !isValidChoice(choice))
        {
            Console.Write("Your choice is invalid. Try again: ");
        }
        Console.WriteLine();
        return choice;
    }
    
    public static Boolean isValidChoice(int choice)
    {
        return (choice <= 10 && choice >= 0);
    }

    public static SqlConnection newSqlConnection()
    {
        Console.Write("Enter the string connection: ");
        string connection = Console.ReadLine();
        SqlConnection sql = new SqlConnection(connection);
        allSqlConnections.Add(sql);
        Console.WriteLine("The SQL Connection was successfully created.");
        Console.WriteLine();
        return sql;
    }

    public static OracleConnection newOracleConnection()
    {
        Console.Write("Enter the string connection: ");
        string connection = Console.ReadLine();
        OracleConnection orl = new OracleConnection(connection);
        allOracleConnections.Add(orl);
        Console.WriteLine("The Oracle Connection was successfully created.");
        Console.WriteLine();
        return orl;
    }
    
    public void displayAllSqlConnection()
    {
        if (allSqlConnections.Count == 0)
        {
            Console.WriteLine("No SQL Connection created yet.");
            Console.WriteLine();
        }
        else
        {
            int i = 0;
            foreach (var sql in allSqlConnections)
            {
                Console.WriteLine("SQL Connection #{0}", i);
                Console.WriteLine("State : {0}", sql.IsOpened? "Opened" : "Closed");
                Console.WriteLine();
                i++;
            }
        }
    }
    
    public void displayAllOracleConnection()
    {
        if (allOracleConnections.Count == 0)
        {
            Console.WriteLine("No Oracle Connection created yet.");
            Console.WriteLine();
        }
        else
        {
            int i = 0;
            foreach (var orl in allOracleConnections)
            {
                Console.WriteLine("Oracle Connection #{0}", i);
                Console.WriteLine("State : {0}", orl.IsOpened? "Opened" : "Closed");
                Console.WriteLine();
                i++;
            }
        }
    }
    
    public void openSqlConnection()
    {
        if (allSqlConnections.Count == 0)
        {
            Console.WriteLine("No SQL Connection created yet.");
            Console.WriteLine();
        }
        else
        {
            displayAllSqlConnection();
            Console.Write("Enter a SQL Connection number from {0} to {1}: ", 0,allSqlConnections.Count-1);
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || !(choice <= allSqlConnections.Count-1 && choice >= 0))
            {
                Console.Write("SQL Connection #{0} doesn't exist. Try again: ", choice);
            }
            allSqlConnections[choice].openConnection();
            allSqlConnections[choice].IsOpened = true;
            allSqlConnections[choice].OpenTime = DateTime.Now;
            
            //Console.WriteLine("SQL Connection #{0} successfully opened", choice);
            Console.WriteLine();
        }
        
    }
    
    public void openOracleConnection()
    {
        if (allOracleConnections.Count == 0)
        {
            Console.WriteLine("No Oracle Connection created yet.");
            Console.WriteLine();
        }
        else
        {
            displayAllOracleConnection();
            Console.Write("Enter a Oracle Connection number from {0} to {1}: ", 0,allOracleConnections.Count-1);
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || !(choice <= allOracleConnections.Count-1 && choice >= 0))
            {
                Console.Write("Oracle Connection #{0} doesn't exist. Try again: ", choice);
            }
            allOracleConnections[choice].openConnection();
            allOracleConnections[choice].IsOpened = true;
            allOracleConnections[choice].OpenTime = DateTime.Now;
            //Console.WriteLine();
            //Console.WriteLine("Oracle Connection #{0} successfully opened", choice);
            Console.WriteLine();
        }
        
    }
    
    public void closeSqlConnection()
    {
        if (allSqlConnections.Count == 0)
        {
            Console.WriteLine("No SQL Connection created yet.");
            Console.WriteLine();
        }
        else
        {
            displayAllSqlConnection();
            Console.Write("Enter a SQL Connection number from {0} to {1}: ", 0,allSqlConnections.Count-1);
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || !(choice <= allSqlConnections.Count-1 && choice >= 0))
            {
                Console.Write("SQL Connection #{0} doesn't exist. Try again: ", choice);
            }if (allSqlConnections[choice].IsTimedOut)
            {
                Console.WriteLine("The connection timed Out and already closed automatically. ", choice);
                allSqlConnections[choice].IsTimedOut = false;
            }
            else
            {
                allSqlConnections[choice].closeConnection();
                allSqlConnections[choice].IsOpened = false;
                allSqlConnections[choice].OpenTime=DateTime.MinValue;
            }
            //Console.WriteLine("SQL Connection #{0} successfully close", choice);
            Console.WriteLine();
        }
        
    }
    
    public void closeOracleConnection()
    {
        if (allOracleConnections.Count == 0)
        {
            Console.WriteLine("No Oracle Connection created yet.");
            Console.WriteLine();
        }
        else
        {
            displayAllOracleConnection();
            Console.Write("Enter a Oracle Connection number from {0} to {1}: ", 0,allOracleConnections.Count-1);
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || !(choice <= allOracleConnections.Count-1 && choice >= 0))
            {
                Console.Write("Oracle Connection #{0} doesn't exist. Try again: ", choice);
            }if (allOracleConnections[choice].IsTimedOut)
            {
                Console.WriteLine("The connection timed Out and already closed automatically. ", choice);
                allOracleConnections[choice].IsTimedOut = false;
            }
            else
            {
                allOracleConnections[choice].closeConnection();
                allOracleConnections[choice].IsOpened = false;
                allOracleConnections[choice].OpenTime=DateTime.MinValue;
            }
            
            Console.WriteLine();
            //Console.WriteLine("Oracle Connection #{0} successfully closed", choice);
            //Console.WriteLine();
        }
    }
    
    public void executeSqlConnection()
    {
        if (allSqlConnections.Count == 0)
        {
            Console.WriteLine("No SQL Connection created yet.");
            Console.WriteLine();
        }
        else
        {
            displayAllSqlConnection();
            Console.Write("Enter a SQL Connection number from {0} to {1}: ", 0,allSqlConnections.Count-1);
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || !(choice <= allSqlConnections.Count-1 && choice >= 0))
            {
                Console.Write("SQL Connection #{0} doesn't exist. Try again: ", choice);
            }if (allSqlConnections[choice].IsTimedOut)
            {
                Console.WriteLine("The connection timed Out and already closed automatically. ", choice);
                allSqlConnections[choice].IsTimedOut = false;
            }
            else
            {
                allSqlConnections[choice].Execute();
            }
            Console.WriteLine();
        }
    }
    
    public void executeOracleConnection()
    {
        if (allOracleConnections.Count == 0)
        {
            Console.WriteLine("No Oracle Connection created yet.");
            Console.WriteLine();
        }
        else
        {
            displayAllOracleConnection();
            Console.Write("Enter a Oracle Connection number from {0} to {1}: ", 0,allOracleConnections.Count-1);
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || !(choice <= allOracleConnections.Count-1 && choice >= 0))
            {
                Console.Write("Oracle Connection #{0} doesn't exist. Try again: ", choice);
            }
            if (allOracleConnections[choice].IsTimedOut)
            {
                Console.WriteLine("The connection timed Out and already closed automatically. ", choice);
                allOracleConnections[choice].IsTimedOut = false;
            }
            else
            {
                allOracleConnections[choice].Execute();
            }
            Console.WriteLine();
        }
       
    }

    static void Main(String[] args)
    {
        Program program = new Program();
        int choice;
        do
        {
            displayMenu();
            choice = takeInputChoice();
            switch (choice)
            {
                case 1 :
                    newSqlConnection();
                    break; 
                case 2 :
                    newOracleConnection();
                    break;
                case 3 :
                   program.displayAllSqlConnection();
                    break; 
                case 4:
                    program.displayAllSqlConnection();
                    break;
                case 5 :
                    program.openSqlConnection();
                    break; 
                case 6 :
                    program.openOracleConnection();
                    break;
                case 7 :
                    program.closeSqlConnection();
                    break; 
                case 8 :
                    program.closeOracleConnection();
                    break;
                case 9 :
                    program.executeSqlConnection();
                    break; 
                case 10 :
                    program.executeOracleConnection();
                    break; 
            }
        } while (choice != 0);
        Console.WriteLine("You've successfully quit DbConnection.");
    }
}