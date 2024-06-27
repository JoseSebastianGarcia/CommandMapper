using CommandMapper.CLI.Commands;
using CommandMapper.Core.Services;

namespace CommandMapper.CLI;

public static class Program 
{
    public static void Main(params string[] args) 
    {
        ICommandManager mapper = new CommandManager();
        mapper.Register(new SayHelloCommand());
        mapper.Register(new SayHourCommand());

        mapper.Execute(args);
    }
}