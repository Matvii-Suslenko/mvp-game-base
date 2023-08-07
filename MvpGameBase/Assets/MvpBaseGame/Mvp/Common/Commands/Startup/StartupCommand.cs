using MvpBaseGame.Mvp.Common.Commands.Startup.Payloads.Impl;
using MvpBaseGame.Mvp.Common.Commands.Startup.Impl;
using MvpBaseGame.Commands.Groups.Impl;
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
            mainFlow.Add<ShowPreloaderCommand>();
            mainFlow.Add<WaitForSecondsCommand>(new WaitForSecondsCommandPayload(1.5f));
            mainFlow.Add<ShowFirstViewCommand>();
            
            groupCommandInfo.Add(mainFlow);
        }
    }
}
