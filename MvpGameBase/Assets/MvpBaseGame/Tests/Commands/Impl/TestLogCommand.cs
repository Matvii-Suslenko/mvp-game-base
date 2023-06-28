using MvpBaseGame.Commands.Core.Impl;
using UnityEngine;

namespace MvpBaseGame.Tests.Commands.Impl
{
    public class TestLogCommand : Command
    {
        protected override void Execute()
        {
            Debug.Log("Test Command is Executed!");
        }
    }
}
