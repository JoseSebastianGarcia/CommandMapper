# ConsoleApp1 - Demo

```csharp
using CommandMapper.CLI.Commands;
using CommandMapper.Core.Services;

namespace CommandMapper.CLI;

public static class Program 
{
    public static void Main(params string[] args) 
    {
        ICommandManager mapper = new CommandManager();

        //consoleapp1 sayhello -n Sebastian
        mapper.Register(new SayHelloCommand()); //CommandBaseWithOptions<T>

        //consoleapp1 sayhour 
        mapper.Register(new SayHourCommand()); //CommandBase


        //CommandName was calculated by reflection deleting 'Command' suffix.

        mapper.Execute(args);
    }
}
```

## SayHelloCommand - CommandBaseWithOptions<NameOption>
```csharp
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
```

## NameOption

```csharp
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
```


## SayHourCommand - CommandBase
```csharp
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
```
