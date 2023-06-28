using MvpBaseGame.Promises;

namespace MvpBaseGame.Commands.Core
{
    public interface ICommandController
    {
        /// <summary>
        /// Executes command
        /// </summary>
        /// <typeparam name="TTrigger"></typeparam>
        IPromise Execute<TTrigger>() where TTrigger : ICommand;
        
        /// <summary>
        /// Executes command with payload
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="TTrigger">Payload which will passed to command</typeparam>
        IPromise Execute<TTrigger>(ICommandPayload data) where TTrigger : ICommand<ICommandPayload>;
    }
}