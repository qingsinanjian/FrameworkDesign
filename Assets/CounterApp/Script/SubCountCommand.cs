using FrameworkDesign;

namespace Counter
{
    public struct SubCountCommand : ICommand
    {
        public void Execute()
        {
            CounterApp.Get<ICounterModel>().Count.Value--;
        }
    }
}
