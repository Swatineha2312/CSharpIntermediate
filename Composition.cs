/*Composition simple e.g.*/

//=====Installer.cs=============

using System;

namespace CSharpIntermediate
{
    class Installer
    {
        private readonly Logger _logger;

        public Installer(Logger logger)
        {
            _logger = logger;
        }
        public void Install()
        {
            _logger.Log("Installer");
        }
    }
}


//=======DbMigrator.cs===========

using System;

namespace CSharpIntermediate
{
    class DbMigrator
    {
        private readonly Logger _logger;

        public DbMigrator(Logger logger)
        {
            _logger = logger;
        }

        public void Migrate()
        {
            _logger.Log("Dbmigration");
        }
    }
}


//=========Logger.cs===========

using System;

namespace CSharpIntermediate
{
    class Logger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}

//=======Program.cs========

using System;

namespace CSharpIntermediate
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbMig = new DbMigrator(new Logger());
            var logger = new Logger();
            var instal = new Installer(logger);
            dbMig.Migrate();
            instal.Install();
        }
    }
}
