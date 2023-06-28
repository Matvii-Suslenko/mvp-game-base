using MvpBaseGame.Commands.Groups.Impl;
using MvpBaseGame.Commands.Core.Impl;
using MvpBaseGame.Commands.Groups;
using MvpBaseGame.Commands.Core;
using Zenject;

namespace MvpBaseGame.Commands
{
    public class CommandInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<IGroupCommandInfo>().To<GroupCommandInfo>().AsTransient().WithArguments(CommandGroupType.Sequence);
            Container.Bind<ICommandInstantiator>().To<CommandInstantiator>().AsSingle();
            Container.Bind<ICommandFactory>().To<CommandFactory>().AsSingle();
            Container.Bind<ICommandBinder>().To<CommandBinder>().AsSingle();
            Container.BindInterfacesTo<CommandController>().AsSingle();
        }
    }
}
