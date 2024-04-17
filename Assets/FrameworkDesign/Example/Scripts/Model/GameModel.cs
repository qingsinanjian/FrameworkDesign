namespace FrameworkDesign.Example
{
    public interface IGameModel : IModel
    {
        BindableProperty<int> KillCount { get; }
        BindableProperty<int> Gold { get; }
        BindableProperty<int> Score { get; }
        BindableProperty<int> BestScore { get; }
    }

    public class GameModel : AbstractModel, IGameModel// : Singleton<GameModel>
    {
        //private GameModel() { }
        public BindableProperty<int> KillCount { get; } = new BindableProperty<int>();
        public BindableProperty<int> Gold { get; } = new BindableProperty<int>();
        public BindableProperty<int> Score { get; } = new BindableProperty<int>();
        public BindableProperty<int> BestScore { get; } = new BindableProperty<int>();

        public override void OnInit()
        {
            var storage = this.GetUtility<IStorage>();
            BestScore.Value = storage.LoadInt(nameof(BestScore), 0);
            BestScore.OnValueChanged += v => storage.SaveInt(nameof(BestScore), v);
        }
    }
}
