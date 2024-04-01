using UnityEngine;

namespace FrameworkDesign.Example
{
    public class Enemy : MonoBehaviour
    {
        private void OnMouseDown()
        {
            GameObject.Destroy(gameObject);
            //KilledOneEnemyEvent.Trigger();
            GameModel.KillCount.Value++;
        }
    }
}
