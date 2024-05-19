using System;
using System.Collections.Generic;

namespace DatabaseConnection
{
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

        public static bool isValidChoice(int choice)
        {
            return (choice <= 10 && choice >= 0);
        }

        public static SqlConnection newSqlConnection()
        {
            Console.Write("Enter the connection string: ");
            string connection = Console.ReadLine();
            SqlConnection sql = new SqlConnection(connection);
            allSqlConnections.Add(sql);
            Console.WriteLine("The SQL Connection was successfully created.");
            Console.WriteLine();
            return sql;
        }

        public static OracleConnection newOracleConnection()
        {
            Console.Write("Enter the connection string: ");
            string connection = Console.ReadLine();
            OracleConnection oracle = new OracleConnection(connection);
            allOracleConnections.Add(oracle);
            Console.WriteLine("The Oracle Connection was successfully created.");
            Console.WriteLine();
            return oracle;
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
                    sql.CheckTimeout();
                    Console.WriteLine("SQL Connection #{0}", i);
                    Console.WriteLine("State : {0}", (sql.IsOpened && !sql.IsTimedOut) ? "Opened" : "Closed");
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
                foreach (var oracle in allOracleConnections)
                {
                    oracle.CheckTimeout();
                    Console.WriteLine("Oracle Connection #{0}", i);
                    Console.WriteLine("State : {0}", (oracle.IsOpened && !oracle.IsTimedOut)  ? "Opened" : "Closed");
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
                Console.Write("Enter a SQL Connection number from {0} to {1}: ", 0, allSqlConnections.Count - 1);
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || !(choice <= allSqlConnections.Count - 1 && choice >= 0))
                {
                    Console.Write("SQL Connection #{0} doesn't exist. Try again: ", choice);
                }
                allSqlConnections[choice].OpenConnection();
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
                Console.Write("Enter an Oracle Connection number from {0} to {1}: ", 0, allOracleConnections.Count - 1);
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || !(choice <= allOracleConnections.Count - 1 && choice >= 0))
                {
                    Console.Write("Oracle Connection #{0} doesn't exist. Try again: ", choice);
                }
                allOracleConnections[choice].OpenConnection();
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
                Console.Write("Enter a SQL Connection number from {0} to {1}: ", 0, allSqlConnections.Count - 1);
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || !(choice <= allSqlConnections.Count - 1 && choice >= 0))
                {
                    Console.Write("SQL Connection #{0} doesn't exist. Try again: ", choice);
                }
                allSqlConnections[choice].CloseConnection();
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
                Console.Write("Enter an Oracle Connection number from {0} to {1}: ", 0, allOracleConnections.Count - 1);
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || !(choice <= allOracleConnections.Count - 1 && choice >= 0))
                {
                    Console.Write("Oracle Connection #{0} doesn't exist. Try again: ", choice);
                }
                allOracleConnections[choice].CloseConnection();
                Console.WriteLine();
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
                Console.Write("Enter a SQL Connection number from {0} to {1}: ", 0, allSqlConnections.Count - 1);
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || !(choice <= allSqlConnections.Count - 1 && choice >= 0))
                {
                    Console.Write("SQL Connection #{0} doesn't exist. Try again: ", choice);
                }
                allSqlConnections[choice].Execute();
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
                Console.Write("Enter an Oracle Connection number from {0} to {1}: ", 0, allOracleConnections.Count - 1);
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || !(choice <= allOracleConnections.Count - 1 && choice >= 0))
                {
                    Console.Write("Oracle Connection #{0} doesn't exist. Try again: ", choice);
                }
                allOracleConnections[choice].Execute();
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            int choice;
            do
            {
                displayMenu();
                choice = takeInputChoice();
                switch (choice)
                {
                    case 1:
                        newSqlConnection();
                        break;
                    case 2:
                        newOracleConnection();
                        break;
                    case 3:
                        program.displayAllSqlConnection();
                        break;
                    case 4:
                        program.displayAllOracleConnection();
                        break;
                    case 5:
                        program.openSqlConnection();
                        break;
                    case 6:
                        program.openOracleConnection();
                        break;
                    case 7:
                        program.closeSqlConnection();
                        break;
                    case 8:
                        program.closeOracleConnection();
                        break;
                    case 9:
                        program.executeSqlConnection();
                        break;
                    case 10:
                        program.executeOracleConnection();
                        break;
                }
            } while (choice != 0);
            Console.WriteLine("You've successfully quit DbConnection.");
        }
    }
}
