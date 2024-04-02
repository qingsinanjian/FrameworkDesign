
using FrameworkDesign;
using System;

namespace CounterApp
{
    public class CounterApp : Architecture<CounterApp>
    {
        protected override void Init()
        {
            Register(new CounterModel());
        }
    }
}

