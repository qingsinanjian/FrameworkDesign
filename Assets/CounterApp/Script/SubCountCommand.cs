using FrameworkDesign;

namespace Counter
{
    public class SubCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            GetArchitecture().GetModel<ICounterModel>().Count.Value--;
        }
    }
}
