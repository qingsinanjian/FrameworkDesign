using FrameworkDesign;
using FrameworkDesign.Example;
using System;

namespace Counter
{
    public class CounterApp : Architecture<CounterApp>
    {
        protected override void Init()
        {
            RegisterSystem<IAchievementSystem>(new AchievementSystem());
            RegisterModel<ICounterModel>(new CounterModel());
            RegisterUtility<IStorage>(new PlayerPrefsStorage());
        }
    }
}

