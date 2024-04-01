using System;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class Game : MonoBehaviour
    {
        private void Awake()
        {
            GameStartEvent.Register(OnGameStart);
            //KilledOneEnemyEvent.Register(OnEnemyKilled);
            GameModel.KillCount.OnValueChanged += OnEnemyKilled;
        }

        private void OnEnemyKilled(int killCount)
        {
            if (killCount == 10)
            {
                GamePassEvent.Trigger();
            }
        }

        private void OnGameStart()
        {
            transform.Find("Enemies").gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            GameStartEvent.UnRegister(OnGameStart);
            //KilledOneEnemyEvent.UnRegister(OnEnemyKilled);
            GameModel.KillCount.OnValueChanged -= OnEnemyKilled;
        }
    }
}

