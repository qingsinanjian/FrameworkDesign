using FrameworkDesign;

namespace Counter
{
    public class AddCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            GetArchitecture().GetModel<ICounterModel>().Count.Value++;
        }
    }
}

