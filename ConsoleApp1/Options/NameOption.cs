using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandMapper.CLI.Options
{
    public class NameOption
    {
        [Option('n', "name", Required = true, HelpText = "El nombre del mono")]
        public string Name { get; set; } = null!;

        [Option('o', "onor", Required = false, HelpText = "Algo que no quiero pasar parametros")]
        public bool OptionX { get; set; }
    }
}
