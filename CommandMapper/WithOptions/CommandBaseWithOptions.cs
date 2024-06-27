using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandMapper.Core.WithOptions
{
    public abstract class CommandBaseWithOptions<TOptions> : ICommandWithOptions where TOptions : class
    {
        public void Execute(string[] commandOptions)
        {
            ParserResult<TOptions> parserResult = Parser.Default.ParseArguments<TOptions>(commandOptions);

            try
            {
                if (parserResult.Value != null)
                    CommandScript(parserResult.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected abstract void CommandScript(TOptions options);

    }
}
