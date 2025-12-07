using App.Scripts.Libs.Patterns.Command.Default;

namespace App.Scripts.Game.Installers.Level
{
    public class DelayedCommandProvider<TCommand> : ICommand where TCommand : ICommand
    {
        private TCommand _command;

        public void Set(TCommand command) => _command = command;

        public void Execute() => _command.Execute();
    }
}