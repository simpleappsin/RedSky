using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DatabaseApp2022
{
    class Program
    {
        static string server;
        static string port;
        static string database;
        static string uid;
        static string pass;
        static string TableName;
        static string DatabaseName;
        static string path;
        static MySqlConnection conn;
        static List<string> NameColumns = new List<string>();
        static List<string> TypeColumns = new List<string>();

        static void CreateDatabase()
        {
            Console.Clear();
            Console.Write("Please enter the Database Name: ");
            DatabaseName = Console.ReadLine();
            Console.Clear();

            string connText = $"SERVER={server};PORT={port};DATABASE={database};UID={uid};PASSWORD={pass};sslmode=none";
            conn = new MySqlConnection(connText);
            conn.Open();

            string SQLcommand = $"CREATE DATABASE {DatabaseName};";
            MySqlCommand cm = new MySqlCommand(SQLcommand, conn);
            cm.ExecuteNonQuery();
            conn.Close();
        }

        static void DropDatabase()
        {
            Console.Clear();
            Console.Write("Please enter the Database Name: ");
            DatabaseName = Console.ReadLine();
            Console.Clear();

            string connText = $"SERVER={server};PORT={port};DATABASE={database};UID={uid};PASSWORD={pass};sslmode=none";
            conn = new MySqlConnection(connText);
            conn.Open();

            string SQLcommand = $"DROP DATABASE {DatabaseName};";
            MySqlCommand cm = new MySqlCommand(SQLcommand, conn);
            cm.ExecuteNonQuery();
            conn.Close();
        }

        static void BackUp()
        {
            string name;
            Console.Clear();
            Console.Write("Please enter the Database Name: ");
            DatabaseName = Console.ReadLine();
            Console.Write("Please enter the Path: ");
            path = Console.ReadLine();
            Console.Write("Please enter the Name: ");
            name = Console.ReadLine();
            Console.Clear();

            string connText = $"SERVER={server};PORT={port};DATABASE={database};UID={uid};PASSWORD={pass};sslmode=none";
            conn = new MySqlConnection(connText);
            conn.Open();

            string SQLcommand = $"BACKUP DATABASE {DatabaseName} TO DISK = {path + "\\" + name + ".bak"};";
            MySqlCommand cm = new MySqlCommand(SQLcommand, conn);
            cm.ExecuteNonQuery();
            conn.Close();
        }

        static void DropTable()
        {
            Console.Clear();
            Console.Write("Please enter the Table Name: ");
            TableName = Console.ReadLine();
            Console.Clear();

            string connText = $"SERVER={server};PORT={port};DATABASE={database};UID={uid};PASSWORD={pass};sslmode=none";
            conn = new MySqlConnection(connText);
            conn.Open();

            string SQLcommand = $"DROP TABLE {TableName};";
            MySqlCommand cm = new MySqlCommand(SQLcommand, conn);
            cm.ExecuteNonQuery();
            conn.Close();
        }

        static void AlterTable()
        {
            Console.Clear();
            NameColumns.Clear();
            TypeColumns.Clear();
            string connText = $"SERVER={server};PORT={port};DATABASE={database};UID={uid};PASSWORD={pass};sslmode=none";
            conn = new MySqlConnection(connText);
            conn.Open();

            Console.Write("Please enter the Table Name: ");
            TableName = Console.ReadLine();

            Console.Write("How many columns? ");
            int number = Convert.ToInt32(Console.ReadLine());
            number -= 1;
            for (int i = 0; i <= number; i++)
            {
                int a;
                a = i + 1;
                Console.Write($"{a} Please enter the column name: ");
                string name = Console.ReadLine();
                string DataType = @"Please choose the DataType:
1] VARCHAR(255)
2] INT
Option: ";
                string type;
                Console.Write($"{a} " + DataType);
                int option;
                option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    type = "VARCHAR (255)";
                    NameColumns.Add(name);
                    TypeColumns.Add(type);

                    string SQLcommandTwo = $"ALTER TABLE {TableName} ADD {NameColumns[i]} {TypeColumns[i]}";
                    MySqlCommand cmTwo = new MySqlCommand(SQLcommandTwo, conn);
                    cmTwo.ExecuteNonQuery();
                    Console.Clear();
                }
                else if (option == 2)
                {
                    type = "INT";
                    NameColumns.Add(name);
                    TypeColumns.Add(type);

                    string SQLcommandTwo = $"ALTER TABLE {TableName} ADD {NameColumns[i]} {TypeColumns[i]}";
                    MySqlCommand cmTwo = new MySqlCommand(SQLcommandTwo, conn);
                    cmTwo.ExecuteNonQuery();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"Please check the option that you entered: {option}");
                    Console.ReadLine();
                }
            }
            conn.Close();
        }

        static void CreateTable()
        {
            Console.Clear();
            Console.Write("Please enter the Table Name: ");
            TableName = Console.ReadLine();
            Console.Clear();

            string connText = $"SERVER={server};PORT={port};DATABASE={database};UID={uid};PASSWORD={pass};sslmode=none";
            conn = new MySqlConnection(connText);
            conn.Open();

            string SQLcommand = $"CREATE TABLE {TableName} (ID int NOT NULL AUTO_INCREMENT PRIMARY KEY);";
            MySqlCommand cm = new MySqlCommand(SQLcommand, conn);
            cm.ExecuteNonQuery();

            Console.Write("How many columns? ");
            int number = Convert.ToInt32(Console.ReadLine());
            number -= 1;
            for (int i = 0; i <= number; i++)
            {
                int a;
                a = i + 1;
                Console.Write($"{a} Please enter the column name: ");
                string name = Console.ReadLine();
                string DataType = @"Please choose the DataType:
1] VARCHAR(255)
2] INT
Option: ";
                string type;
                Console.Write($"{a} " + DataType);
                int option;
                option = Convert.ToInt32(Console.ReadLine());
                if(option == 1)
                {
                    type = "VARCHAR (255)";
                    NameColumns.Add(name);
                    TypeColumns.Add(type);

                    string SQLcommandTwo = $"ALTER TABLE {TableName} ADD {NameColumns[i]} {TypeColumns[i]}";
                    MySqlCommand cmTwo = new MySqlCommand(SQLcommandTwo, conn);
                    cmTwo.ExecuteNonQuery();
                    Console.Clear();
                }
                else if(option == 2)
                {
                    type = "INT";
                    NameColumns.Add(name);
                    TypeColumns.Add(type);

                    string SQLcommandTwo = $"ALTER TABLE {TableName} ADD {NameColumns[i]} {TypeColumns[i]}";
                    MySqlCommand cmTwo = new MySqlCommand(SQLcommandTwo, conn);
                    cmTwo.ExecuteNonQuery();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"Please check the option that you entered: {option}");
                    Console.ReadLine();
                }
            }
            conn.Close();
        }

        static void Menu()
        {

            Console.Write("Please enter the Server: ");
            server = Console.ReadLine();

            Console.Write("Please enter the Port Number: ");
            port = Console.ReadLine();

            Console.Write("Please enter the DataBase: ");
            database = Console.ReadLine();

            Console.Write("Please enter the UID: ");
            uid = Console.ReadLine();

            Console.Write("Please enter the Password: ");
            pass = Console.ReadLine();

            while (true)
            {
                Console.Clear();
                string menu = @"

  _____          _  _____ _            _____        _        _                    
 |  __ \        | |/ ____| |          |  __ \      | |      | |                   
 | |__) |___  __| | (___ | | ___   _  | |  | | __ _| |_ __ _| |__   __ _ ___  ___ 
 |  _  // _ \/ _` |\___ \| |/ / | | | | |  | |/ _` | __/ _` | '_ \ / _` / __|/ _ \
 | | \ \  __/ (_| |____) |   <| |_| | | |__| | (_| | || (_| | |_) | (_| \__ \  __/
 |_|  \_\___|\__,_|_____/|_|\_\\__, | |_____/ \__,_|\__\__,_|_.__/ \__,_|___/\___|
                                __/ |                                             
                               |___/                                              
                                                   Developed by Ata Yigit Ustundag
";

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(menu);
                Console.ResetColor();

                string options = @"
                            +--------------------------------------+
                            |       1] Create Database             |
                            |       2] Drop Database               |
                            |       3] Create Table                |
                            |       4] Drop Table                  |
                            |       5] Backup Database             |
                            |       6] Alter Database              |
                            |       7] Injection (Coming Soon)     |
                            |       8] Exit                        |
                            +--------------------------------------+

                            Option: ";

                Console.Write(options);
                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    CreateDatabase();
                }
                else if (option == 2)
                {
                    DropDatabase();
                }
                else if (option == 3)
                {
                    CreateTable();
                }
                else if(option == 4)
                {
                    DropTable();
                }
                else if(option == 5)
                {
                    BackUp();
                }
                else if(option == 6)
                {
                    AlterTable();
                }
                else if(option == 7)
                {
                    
                }
                else if (option == 8)
                {
                    break;
                }
                else
                {
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
