namespace DatabaseConnection
{
    public class OracleConnection : DbConnection
    {
        // Constructor
        public OracleConnection(string connection) : base(connection)
        {
            OpenTime = DateTime.MaxValue;
            IsOpened = false;
            IsTimedOut = false;
        }

        // Method for opening connection
        public void OpenConnection()
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
        
        // Method for closing connection
        public void CloseConnection()
        {
            CheckTimeout();
            if (!IsOpened)
            {
                Console.WriteLine("The connection is already closed.");
            }
            else if (IsTimedOut)
            {
                IsOpened = false;
                OpenTime = DateTime.MaxValue;
                Console.WriteLine("The connection timed out and closed automatically.");
                IsTimedOut = false;
            }
            else
            {
                IsOpened = false;
                Console.WriteLine("The connection is now closed.");
            }
        }

        public void Execute()
        {
            CheckTimeout();
            if (!IsOpened)
            {
                Console.WriteLine("The connection is not opened yet. Try opening it before executing an instruction.");
            }
            else if (IsTimedOut)
            {
                IsOpened = false;
                OpenTime = DateTime.MaxValue;
                Console.WriteLine("The connection timed out and closed automatically. Please try opening it again.");
                IsTimedOut = false;
            }
            else
            {
                Console.WriteLine("The instruction was successfully sent to the database.");
            }
        }
        
        public void CheckTimeout()
        {
            if (IsOpened && (DateTime.Now - OpenTime) > TimeSpan.FromMinutes(1))
            {
                IsTimedOut = true;
                IsOpened = false;
            }
        }
    }
}
