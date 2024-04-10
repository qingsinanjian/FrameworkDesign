using Counter;
using System.Runtime.InteropServices;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public interface IAchievementSystem : ISystem
    {
        
    }

    public class AchievementSystem : AbstractSystem, IAchievementSystem
    {
        public override void OnInit()
        {
            var counterModel = GetArchitecture().GetModel<ICounterModel>();
            var previousCount = counterModel.Count.Value;
            counterModel.Count.OnValueChanged += newCount =>
            {
                if (previousCount < 10 && newCount >= 10)
                {
                    Debug.Log("�������10�γɾ�");
                }
                else if (previousCount < 20 && newCount >= 20)
                {
                    Debug.Log("�������20�γɾ�");
                }
                previousCount = newCount;
            };
        }
    }
}
