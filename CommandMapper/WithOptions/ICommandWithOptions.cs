using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandMapper.Core.WithOptions
{
    public interface ICommandWithOptions : ICommandAbstraction
    {
        void Execute(string[] commandOptions);
    }
}
