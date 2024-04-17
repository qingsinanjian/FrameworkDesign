using UnityEngine;

namespace FrameworkDesign.Example
{
    public class Enemy : MonoBehaviour, IController
    {
        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return PointGame.Interface;
        }

        private void OnMouseDown()
        {
            GameObject.Destroy(gameObject);
            //KilledOneEnemyEvent.Trigger();
            this.SendCommand<KillEnemyCommand>();
        }
    }
}
