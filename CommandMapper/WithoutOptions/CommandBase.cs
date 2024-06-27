using System;


namespace CommandMapper.Core.WithoutOptions
{
    public abstract class CommandBase : ICommand
    {
        public void Execute()
        {
            try
            {
                CommandScript();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected abstract void CommandScript();

    }
}
