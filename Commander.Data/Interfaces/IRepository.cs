using Commander.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commander.Data.Interfaces
{
    public interface IRepository
    {
        void Add(CommandBuilder commandBuilder);
        void Delete(Guid id);
        void Update(CommandBuilder commandBuilder);
        CommandBuilder GetCommandsById(Guid id);
        public Dictionary<Guid, CommandBuilder> GetAll();
    }
}
