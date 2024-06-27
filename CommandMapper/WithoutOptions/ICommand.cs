using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandMapper.Core.WithoutOptions
{
    public interface ICommand : ICommandAbstraction
    {
        void Execute();
    }
}
