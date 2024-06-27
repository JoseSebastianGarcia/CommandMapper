using CommandMapper.Core.WithoutOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandMapper.CLI.Commands
{
    public class SayHourCommand : CommandBase
    {
        protected override void CommandScript()
        {
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        }
    }
}
