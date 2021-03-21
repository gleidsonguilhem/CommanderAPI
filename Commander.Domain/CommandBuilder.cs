using Commander.Domain.Enums;
using System;

namespace Commander.Domain
{
    public class CommandBuilder 
    {
        /*TODO
         * 
         * DONE
         * improve class name -OK
         * criar validacoes no metodo create -OK
         * criar projeto de teste Unitario para testar o create -OK
         * Create test to check exceptions -OK
         * Create repository -OK
         * Create Memory database - Dictionary(key = id,value = object CommandBuilder) - Tip: declare as a private -OK
         * 
         * ONGOING
         * 
         * Create Unit tests
         * Fluents Validation
         * 
         * Implementar update - ok
         * 
         * Create testCases
         * 1
         * - Add CommandBuilder no repositorio
         * - Test Delete Method (Check the data was deleted) - ok
         * 
         * 2
         * - Inserir 2x o mesmo CommandBuilder - Exe metodo Add 2x apos criar commandBuilder
         *
         *Testar Update
         *- Add um command , alterar e recuperar de novo pra ver se foi alterado
         */
        private CommandBuilder(string command, string function, PlatformType platform, string application, string user, DateTime created, bool adminRequired, string id)
        {
            Command = command;
            Function = function;
            Platform = platform;
            Application = application;
            User = user;
            Created = created;
            AdminRequired = adminRequired;
            Id = id == string.Empty ? Guid.NewGuid() : Guid.Parse(id); 
        }
        public static CommandBuilder Create(string command, string function, string platform, string application, string user, DateTime created, bool adminRequired)
        {
            //Check string fields
            if (string.IsNullOrEmpty(command) || string.IsNullOrEmpty(function) || string.IsNullOrEmpty(application) || string.IsNullOrEmpty(user))
            {
                throw new ArgumentException();
            }
            //Check date field
            else if (created == DateTime.MinValue)
            {
                throw new Exception("Date must be filled");
            }
            //Check out of range Enum
            else if (!Enum.TryParse(platform, true, out PlatformType type))
            {
                throw new Exception("Platform must be 1 - (WINDOWS), 2 - (MAC) or 3 - (LINUX)");
            }else
            {
                return new CommandBuilder(command, function, type, application, user, created, adminRequired, id : string.Empty );
            }
            //tratar casos que o usuario passa um tipo de plataforma que nao existe no enum (Try Cast type/enum)
        }
        public void UpdateCommand(string command)
        {
            Command = command;
        }


        public string Command { get; private set; }
        public string Function { get; }
        public PlatformType Platform { get;  }
        public string Application { get;  }
        public string User { get;  }
        public DateTime Created { get;  }
        public bool AdminRequired{ get;  }
        public Guid Id { get; }
    }
}
