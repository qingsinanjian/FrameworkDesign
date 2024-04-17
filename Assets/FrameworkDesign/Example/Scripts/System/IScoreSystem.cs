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
                gameModel.Score.Value = Random.Range(0, 50);

                Debug.Log("Score:" + gameModel.Score.Value);
                Debug.Log("BestScore:" + gameModel.BestScore.Value);

                if(gameModel.Score.Value > gameModel.BestScore.Value)
                {
                    gameModel.BestScore.Value = gameModel.Score.Value;
                    Debug.Log("新纪录");
                }
            });
        }
    }
}

