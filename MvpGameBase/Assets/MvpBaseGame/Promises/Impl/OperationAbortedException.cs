using System;

namespace MvpBaseGame.Promises.Impl
{
    public class OperationAbortedException : Exception
    {
        internal OperationAbortedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}