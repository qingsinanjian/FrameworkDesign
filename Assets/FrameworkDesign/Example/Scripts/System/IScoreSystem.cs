using UnityEngine;

namespace FrameworkDesign.Example
{
    public interface IScoreSystem : ISystem
    {

    }

    public class ScoreSystem : AbstractSystem, IScoreSystem
    {
        public override void OnInit()
        {
            var gameModel = this.GetModel<IGameModel>();
            this.RegisterEvent<GamePassEvent>(e =>
            {
                Debug.Log("Score:" + gameModel.Score.Value);
                Debug.Log("BestScore:" + gameModel.BestScore.Value);

                if(gameModel.Score.Value > gameModel.BestScore.Value)
                {
                    gameModel.BestScore.Value = gameModel.Score.Value;
                    Debug.Log("新纪录");
                }
            });

            this.RegisterEvent<OnEnemyKillEvent>(e =>
            {
                gameModel.Score.Value += 10;
            });

            this.RegisterEvent<OnMissEvent>(e =>
            {
                gameModel.Score.Value -= 5;
            });
        }
    }
}

