namespace DatabaseConnection;

public class SqlConnection: DbConnection
{
    //Constructor
    public SqlConnection(string _connection) : base(_connection)
    {
        OpenTime = DateTime.MinValue;
        IsOpened = false;
    }

    //Method for opening connection
    public void openConnection()
    {
        if (IsOpened)
        {
            Console.WriteLine("The connection is already opened.");
        }
        else
        {
            IsOpened = true;
            OpenTime = DateTime.Now;
            Console.WriteLine("The connection is now opened.");  
        }
        
    }
        
    //Method for closing connection
    public void closeConnection()
    {
        if (!IsOpened)
        {
            Console.WriteLine("The connection is already closed.");
        }else if ((DateTime.Now - OpenTime) > TimeSpan.FromMinutes(1))
        {
            IsOpened = false;
            OpenTime=DateTime.MinValue;
            Console.WriteLine("The connection timed Out and already closed automatically.");
        }
        else
        {
            IsOpened = false;
            Console.WriteLine("The connection is now closed.");
        }
        
    }
    
    public void Execute()
    {
        if (!IsOpened)
        {
            Console.WriteLine("The connection is not opened yet. Try opening it before executing an instruction.");
        } else if ((DateTime.Now - OpenTime) > TimeSpan.FromMinutes(1))
        {
            IsOpened = false;
            OpenTime=DateTime.MinValue;
            Console.WriteLine("The connection timed out and closed automatically. Please try opening it again.");
        }
        else
        {
            Console.WriteLine("The instruction was successfully sent to the database.");
        }
    }

}