using System;

namespace MvpBaseGame.Commands.Core
{
    public interface IAbortable
    {
        /// <summary>
        /// Aborts
        /// </summary>
        /// <param name="exception">Exception</param>
        void Abort(Exception exception = null);
    }
}