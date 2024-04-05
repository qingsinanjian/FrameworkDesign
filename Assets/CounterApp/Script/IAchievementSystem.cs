using Counter;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public interface IAchievementSystem : ISystem
    {
        
    }

    public class AchievementSystem : IAchievementSystem
    {
        public IArchitecture Architecture { get; set; }

        public void Init()
        {
            var counterModel = Architecture.GetModel<ICounterModel>();
            var previousCount = counterModel.Count.Value;
            counterModel.Count.OnValueChanged += newCount =>
            {
                if(previousCount < 10 && newCount >= 10)
                {
                    Debug.Log("�������10�γɾ�");
                }
                else if(previousCount < 20 && newCount >= 20)
                {
                    Debug.Log("�������20�γɾ�");
                }
                previousCount = newCount;
            };
        }
    }
}
