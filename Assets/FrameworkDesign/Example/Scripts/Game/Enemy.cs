using UnityEngine;

namespace FrameworkDesign.Example
{
    public class Enemy : MonoBehaviour, IController
    {
        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }

        private void OnMouseDown()
        {
            GameObject.Destroy(gameObject);
            //KilledOneEnemyEvent.Trigger();
            GetArchitecture().SendCommand<KillEnemyCommand>();
        }
    }
}
