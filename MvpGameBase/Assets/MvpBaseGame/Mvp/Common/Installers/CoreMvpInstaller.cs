using ProductMadness.CashmanCasino.Core.Installers;
using MvpBaseGame.Commands.Core;

namespace MvpBaseGame.Mvp.Common.Installers
{
    public class CoreMvpInstaller : MvpInstaller
    {
        public CoreMvpInstaller(ICommandBinder commandBinder) : base(commandBinder)
        {
        }
        
        protected override void BindCommon()
        {
            AddFeatureInstallers();
        }

        private void AddFeatureInstallers()
        {
            Container.Install<CommonInstaller>();
        }
    }
}
