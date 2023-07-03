using MvpBaseGame.Promises;
using MvpBaseGame.Promises.Impl;

namespace MvpBaseGame.Mvp.ViewManagement.Data.Impl
{
    public class ViewListener : IViewListener
    {
        public IPromise ViewOpened { get; }
        public IPromise ViewClosed { get; }

        public ViewListener()
        {
            ViewOpened = new Promise();
            ViewClosed = new Promise();
        }
    }
}
