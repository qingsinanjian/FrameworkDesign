namespace FrameworkDesign.Example
{
    public class GameModel// : Singleton<GameModel>
    {
        //private GameModel() { }
        public BindableProperty<int> KillCount = new BindableProperty<int>();
        public BindableProperty<int> Gold = new BindableProperty<int>();
        public BindableProperty<int> Score = new BindableProperty<int>();
        public BindableProperty<int> BestScore = new BindableProperty<int>();
    }
}
