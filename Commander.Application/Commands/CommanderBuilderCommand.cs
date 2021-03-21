using System;
using MediatR;

namespace Commander.Application.Commands
{
    public class CommanderBuilderCommand : IRequest<Unit>
    {
        public string Command { get; set; }
        public string Function { get; set; }
        public string Platform { get; set; }
        public string Application { get; set; }
        public string User { get; set; }
        public DateTime Created { get; set; }
        public bool AdminRequired { get; set; }
    }
}
