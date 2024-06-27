using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandMapper.Core.Services
{
    public interface ICommandManager
    {
        void Register(ICommandAbstraction command);
        void Unregister(string commandName);
        void Execute(string[] args);
    }
}
