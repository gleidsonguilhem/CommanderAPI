using Commander.Data.Interfaces;
using Commander.Domain;
using System;
using System.Collections.Generic;

namespace Commander.Data.Repositories
{
    public class MemoryRepository : IRepository
    {
        private Dictionary<Guid, CommandBuilder> database;
        public MemoryRepository()
        {
            database = new Dictionary<Guid, CommandBuilder>();
        }
        public void Add(CommandBuilder commandBuilder)
        {
            if(!database.TryGetValue(commandBuilder.Id, out var command))
            {
                database.Add(commandBuilder.Id, commandBuilder);
            }
        }
        public Dictionary<Guid, CommandBuilder> GetAll()
        {
            return database;
        }
        public void Delete(Guid id)
        {
            database.Remove(id);
        }
        public CommandBuilder GetCommandsById(Guid id)
        {
            CommandBuilder command;
            //Update to use TryGetValue
            database.TryGetValue(id, out command);
            return command;
        }
        public void Update(CommandBuilder commandBuilder)
        {
            if (database.TryGetValue(commandBuilder.Id, out var command))
            {
                database[commandBuilder.Id] = commandBuilder;
            }
        }

    }
}
