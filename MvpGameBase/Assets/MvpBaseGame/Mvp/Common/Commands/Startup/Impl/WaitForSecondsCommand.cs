using MvpBaseGame.Mvp.Common.Commands.Startup.Payloads;
using MvpBaseGame.Utils.CoroutineRunner;
using MvpBaseGame.Commands.Core.Impl;
using System.Collections;
using UnityEngine;

namespace MvpBaseGame.Mvp.Common.Commands.Startup.Impl
{
    public class WaitForSecondsCommand : AsyncCommand
    {
        private readonly IWaitForSecondsCommandPayload _payload;
        private readonly ICoroutineRunner _coroutineRunner;

        public WaitForSecondsCommand(
            IWaitForSecondsCommandPayload payload,
            ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _payload = payload;
        }

        protected override void Execute()
        {
            _coroutineRunner.StartCoroutine(WaitForSecondsInternal());
        }

        private IEnumerator WaitForSecondsInternal()
        {
            yield return new WaitForSeconds(_payload.Seconds);
            Release();
        }
    }
}
