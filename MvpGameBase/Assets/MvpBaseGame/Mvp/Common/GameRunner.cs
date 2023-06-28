using MvpBaseGame.Mvp.Common.Commands.Startup.Impl;
using MvpBaseGame.Commands.Core;
using System.Globalization;
using Zenject;

namespace MvpBaseGame.Mvp.Common
{
    public class GameRunner : IInitializable
    {
        readonly ICommandController _commandController;

        public GameRunner(
            ICommandController commandController
        )
        {
            _commandController = commandController;
        }
        
        public void Initialize()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-GB");
            _commandController.Execute<IStartupCommand>();
        }
    }
}
