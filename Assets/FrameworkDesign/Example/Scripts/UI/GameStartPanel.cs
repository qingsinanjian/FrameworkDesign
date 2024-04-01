using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example
{
    public class GameStartPanel : MonoBehaviour
    {

        private void Start()
        {
            transform.Find("BtnStart").GetComponent<Button>().onClick
                .AddListener(() =>
                {
                    gameObject.SetActive(false);
                    GameStartEvent.Trigger();
                });
        }
    }
}

