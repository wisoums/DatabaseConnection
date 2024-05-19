using System;

namespace DatabaseConnection
{
    public class DbConnection
    {
        // Attributes:
        private string _connection;
        private bool _isOpened;
        private DateTime _openTime;
        private bool _isTimedOut;
        
        // Properties:
        public DateTime OpenTime
        {
            get => _openTime;
            set => _openTime = value;
        }
        
        public string Connection
        {
            get => _connection;
            set => _connection = value;
        }
        
        public bool IsOpened
        {
            get => _isOpened && !_isTimedOut;
            set => _isOpened = value;
        }
        
        public bool IsTimedOut
        {
            get
            {
                if ((DateTime.Now - _openTime) > TimeSpan.FromMinutes(1))
                {
                    _isTimedOut = true;
                }
                else
                {
                    _isTimedOut = false;
                }
                return _isTimedOut;
            }
            set => _isTimedOut = value;
        }
        
        // Constructor:
        public DbConnection(string connection)
        {
            if (string.IsNullOrWhiteSpace(connection))
            {
                throw new ConnectionNullorWhitespaceException("Null or Empty connection string is invalid.");
            }
            _connection = connection;
            _isOpened = false;
            _isTimedOut = false;
            _openTime = DateTime.MaxValue;
        }
        
        // Method for opening connection:
        public void OpenConnection()
        {
            CheckTimeout();
            if (_isOpened)
            {
                Console.WriteLine("The connection is already opened.");
            }
            else
            {
                _isOpened = true;
                _openTime = DateTime.Now;
                Console.WriteLine("The connection is now opened.");  
            }
        }
        
        // Method for closing connection:
        public void CloseConnection()
        {
            CheckTimeout();
            if (!_isOpened)
            {
                Console.WriteLine("The connection is already closed.");
            }
            else
            {
                _isOpened = false;
                Console.WriteLine(_isTimedOut 
                    ? "The connection timed out and is now closed automatically." 
                    : "The connection is now closed.");
            }
        }
        public void CheckTimeout()
        {
            if (IsOpened && (DateTime.Now - OpenTime) > TimeSpan.FromMinutes(1))
            {
                IsTimedOut = true;
                IsOpened=false;
            }
        }
    }
}


