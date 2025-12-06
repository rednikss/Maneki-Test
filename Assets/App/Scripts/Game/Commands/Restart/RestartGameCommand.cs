using App.Scripts.Libs.Patterns.Command.Default;
using UnityEngine;

namespace App.Scripts.Game.Commands.Restart
{
    public class RestartGameCommand : ICommand
    {
        public RestartGameCommand()
        {
            
        }
        
        public void Execute()
        {
            Debug.Log("FUCK!");
        }
    }
}