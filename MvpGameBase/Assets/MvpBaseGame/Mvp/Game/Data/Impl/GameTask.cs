namespace MvpBaseGame.Mvp.Game.Data.Impl
{
    public class GameTask : IGameTask
    {
        public string Question { get; }
        public string[] Options { get; }
        public int Answer { get; }

        public GameTask(string question, string[] options, int answer)
        {
            Question = question;
            Options = options;
            Answer = answer;
        }
    }
}
