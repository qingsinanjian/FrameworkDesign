using UnityEngine;

namespace FrameworkDesign.Example
{
    public class Enemy : MonoBehaviour
    {
        public GameObject gamePassPanel;
        private static int mKilledEnemyCount = 0;
        private void OnMouseDown()
        {
            GameObject.Destroy(gameObject);
            mKilledEnemyCount++;
            if(mKilledEnemyCount == 10)
            {
                gamePassPanel.SetActive(true);
            }
        }
    }
}
