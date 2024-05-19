using System;
using System.Runtime.CompilerServices;

namespace DatabaseConnection;
    public class DbConnection
    {
        //Attributes:
        private string _connection;
        private Boolean _isOpened;
        private DateTime _openTime;
        private Boolean _isTimedOut;
        
        //Getter & Setter
        public DateTime OpenTime
        {
            get => _openTime;
            set => _openTime = value;
        }
        public string Connection
        {
            get
            {
                return _connection;
            }
            set
            {
                _connection = value;
            }
        }
        
        public  Boolean IsOpened
        {
            get
            {
                if ((DateTime.Now - _openTime) > TimeSpan.FromMinutes(1))
                {
                    _isOpened = false;
                }
                else
                {
                    _isOpened = true;
                }
                return _isOpened;
            }
            set
            {
                _isOpened = value;
                
            }
        }
        
        public  Boolean IsTimedOut
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
            set
            {
                _isTimedOut = value;
                
            }
        }
        
        
        //Constructor:
        public DbConnection(string _connection)
        {
            if (String.IsNullOrWhiteSpace(_connection))
            {
                throw new ConnectionNullorWhitespaceException("Null or Empty connection string are invalid.");
            }
            this._connection = _connection;
            this._isOpened = false;
            _isTimedOut = false;
            _openTime = DateTime.MinValue;

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
                _openTime=DateTime.Now;
                Console.WriteLine("The connection is now opened.");  
            }
        }
        
        //Method for closing connection
        public void closeConnection()
        {
            if (!IsOpened)
            {
                Console.WriteLine("The connection is already closed.");
            }else if (_isTimedOut)
            {
                Console.WriteLine("The connection timed Out and already closed automatically.");
            }
            else
            {
                IsOpened = false;
                Console.WriteLine("The connection is now closed.");
            }
        }
    }



