using MvpBaseGame.Mvp.Common.Commands.Startup.Impl;
using MvpBaseGame.Commands.Groups.Impl;
using MvpBaseGame.Tests.Commands.Impl;
using MvpBaseGame.Commands.Core.Impl;
using MvpBaseGame.Commands.Groups;
using MvpBaseGame.Commands.Core;

namespace MvpBaseGame.Mvp.Common.Commands.Startup
{
    public class StartupCommand : SequenceGroupCommand, IStartupCommand
    {
        public StartupCommand(IGroupCommandInfo groupCommandInfo, ICommandFactory commandFactory)
            : base(groupCommandInfo, commandFactory)
        {
            var mainFlow = new GroupCommandInfo(CommandGroupType.Sequence);
            //mainFlow.Add<LoadPreloaderCommand>();
            mainFlow.Add<ShowPreloaderCommand>();
            
            //mainFlow.Add<LoadLobbyAssetsCommand>();

            var parallelGroup = new GroupCommandInfo(CommandGroupType.Parallel);
            parallelGroup.Add(mainFlow);
            
            //groupCommandInfo.Add<InitializeUnityLoggingCommand>();
            //groupCommandInfo.Add<InitialiseApplicationCommand>();
            //groupCommandInfo.Add<SetLanguageCommand>();
            //groupCommandInfo.Add<UnloadAllScenesCommand>();
            groupCommandInfo.Add(parallelGroup);
            //groupCommandInfo.Add<ShowFirstViewCommand>();

            groupCommandInfo.Add<TestLogCommand>(); // TODO: remove
        }
    }
}
