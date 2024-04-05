using FrameworkDesign;

namespace Counter
{
    public struct AddCountCommand : ICommand
    {
        public void Execute()
        {
            CounterApp.Get<ICounterModel>().Count.Value++;
        }
    }
}

