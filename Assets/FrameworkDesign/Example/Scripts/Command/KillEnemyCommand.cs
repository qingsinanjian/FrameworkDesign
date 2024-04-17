using UnityEngine;

namespace FrameworkDesign.Example
{
    public class KillEnemyCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = PointGame.Get<IGameModel>();
            gameModel.KillCount.Value++;
            if (gameModel.KillCount.Value == 10)
            {
                this.SendEvent<GamePassEvent>();
            }
        }
    }
}
