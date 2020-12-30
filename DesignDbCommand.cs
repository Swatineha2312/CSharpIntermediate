/*Exercise 2: Design a database commandNow that we have the concept of a DbConnection, let’s work out how to represent 
a DbCommand. Design a class called DbCommand for executing an instruction against the database. A DbCommand cannot 
be in a valid state without having a connection. So in the constructor of this class, pass a DbConnection. 
Don’t forget to cater for the null.Each DbCommand should also have the instruction to be sent to the database. 
In case of SQL Server, this instruction is expressed in T-SQL language. Use a string to represent this instruction. 
Again, a command cannot be in a valid state without this instruction. So make sure to receive it in the constructor 
and cater for the null reference or an empty string. Each command should be executable. So we need to create a method 
called Execute(). In this method, we need a simple implementation as follows: 
Open the connection
Run the instruction 
Close the connection
Note that here, inside the DbCommand, we have a reference to DbConnection. 
Depending on the type of DbConnection sent at runtime, opening and closing a connection will be different. 
For example, if we initialize this DbCommand with a SqlConnection, we will open and close a connection to a 
Sql Server database. This is polymorphism. Interestingly, DbCommand doesn’t care about how a connection is opened 
or closed. It’s not the responsibility of the DbCommand. All it cares about is to send an instruction to a database. 
For running the instruction, simply output it to the Console. In the real-world, SQL Server (or any other DBMS) 
provides an API for running an instruction against the database. We don’t need to worry about it for this exercise. 
In the main method, initialize a DbCommand with some string as the instruction and a SqlConnection. Execute the command 
and see the result on the console.Then, swap the SqlConnection with an OracleConnection and see polymorphism in action
*/

//DbConnection.cs
using System;
namespace CSharpIntermediate
{
    public abstract class DbConnection
    {
        private readonly string _connectionString;
        public virtual TimeSpan _timeout { get; set; }

        public abstract void DbOpen();

        protected DbConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("Conection string can't be null or empty");

            _connectionString = connectionString;           
        }

        public abstract void DbClose();
    }
}


//OracleConnection.cs
using System;
namespace CSharpIntermediate
{
   public class OracleConnection:DbConnection
    {
        public OracleConnection(string connectionString) : base(connectionString)
        {
            base._timeout = TimeSpan.FromSeconds(120);
        }
        public override void DbOpen()
        {
            Console.WriteLine("Oracle Connection is open.");
        }
        public override void DbClose()
        {
            Console.WriteLine("Oracle Connection is closed.");
            Console.WriteLine($"Timeout is set to {base._timeout}");
        }        
    }
}


//SqlConnections.cs
using System;
namespace CSharpIntermediate
{
    class SqlConnection:DbConnection
    {
       
        public SqlConnection(string connectionString) : base(connectionString)
        {
            base._timeout = TimeSpan.FromSeconds(60);
        }
        public override void DbOpen()
        {
            Console.WriteLine("Sql Connection is open.");
            Console.WriteLine($"Timeout is set to {base._timeout}");
        }
        public override void DbClose()
        {
            Console.WriteLine("Sql Connection is closed.");
        }
    }
}

//DbCommand.cs
using System;
namespace CSharpIntermediate
{
    public class DbCommand
    {
        private readonly DbConnection _dbConnection;
        private readonly string _instructions;

        public DbCommand(DbConnection dbConnection, string instructions)
        {
            if (dbConnection == null)
                throw new ArgumentNullException();
            if (string.IsNullOrEmpty(instructions))
                throw new ArgumentNullException();

            _dbConnection = dbConnection;
            _instructions = instructions;
        }
        public void Execute()
        {
            _dbConnection.DbOpen();
            Console.WriteLine("Executing the instructions"+_instructions);
            _dbConnection.DbClose();
        }
    }
}

//Program.cs
using System;
namespace CSharpIntermediate
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqlConnection = new SqlConnection("My.SQL.ConnectionString");
            var sqlCommand = new DbCommand(sqlConnection, "DROP TABLE tblUsers -- On SQL Server");
            sqlCommand.Execute();

            var oracleConnection = new OracleConnection("My.Oracle.ConnectionString");
            var oracleCommand = new DbCommand(oracleConnection, "DROP TABLE tblUsers -- On Oracle");
            oracleCommand.Execute();

            try
            {
                var emptyConnectionString = new SqlConnection(string.Empty);
                var emptyCommand = new DbCommand(emptyConnectionString, "DROP TABLE tblUsers;");
                emptyCommand.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                var whitespaceConnectionString = new SqlConnection(" ");
                var whitespaceCommand = new DbCommand(whitespaceConnectionString, "DROP TABLE tblUsers;");
                whitespaceCommand.Execute();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            try
            {
                var fakeSQLConnection = new SqlConnection("fasdf");
                var fakeSQLCommand = new DbCommand(fakeSQLConnection, null);
                fakeSQLCommand.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}


//Console Output:
Sql Connection is open.
Timeout is set to 00:01:00
Executing the instructionsDROP TABLE tblUsers -- On SQL Server
Sql Connection is closed.
Oracle Connection is open.
Executing the instructionsDROP TABLE tblUsers -- On Oracle
Oracle Connection is closed.
Timeout is set to 00:02:00
Value cannot be null.
Parameter name: Conection string can't be null or empty
Sql Connection is open.
Timeout is set to 00:01:00
Executing the instructionsDROP TABLE tblUsers;
Sql Connection is closed.
Value cannot be null.
Press any key to continue . . .

