
using System;
using System.Collections.Generic;
using System.Linq;
using CommandMapper.Core.WithOptions;
using CommandMapper.Core.WithoutOptions;

namespace CommandMapper.Core.Services
{
    public class CommandManager : ICommandManager
    {
        private readonly Dictionary<string, ICommandAbstraction> _commands = new Dictionary<string, ICommandAbstraction>();

        public void Register(ICommandAbstraction command)
        {
            string commandName = command.GetType().Name.ToUpper().Replace("COMMAND", "");
            _commands.Add(commandName, command);
        }

        /// <summary>
        /// Unregister a command
        /// </summary>
        /// <param name="commandName">The name of your command class without Command suffix.</param>
        public void Unregister(string commandName)
        {
            _commands.Remove(commandName.ToUpper().Trim());
        }
        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(ErrorMessages.CommandNotRecognized);
                return;
            }

            string commandName = args[0].ToUpper().Trim();
            string[] commandOptions = args.Skip(1).ToArray();


            if (_commands.TryGetValue(commandName, out ICommandAbstraction? command))
            {
                if (command != null)
                {
                    if (command is ICommand)
                        ((ICommand)command).Execute();

                    if (command is ICommandWithOptions)
                        ((ICommandWithOptions)command).Execute(commandOptions);
                }
                else
                    Console.WriteLine(ErrorMessages.CommandNotRecognized);
            }
            else
            {
                Console.WriteLine(ErrorMessages.CommandNotRecognized);
            }
        }

        public static ICommandManager Create() => new CommandManager();
    }
}
