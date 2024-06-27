using CommandMapper.CLI.Options;
using CommandMapper.Core.WithOptions;
using System;


namespace CommandMapper.CLI.Commands
{
    public class SayHelloCommand : CommandBaseWithOptions<NameOption>
    {
        protected override void CommandScript(NameOption options)
        {
            Console.WriteLine("Hello {0}!", options.Name);
        }
    }
}
