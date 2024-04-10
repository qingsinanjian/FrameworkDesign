namespace FrameworkDesign
{
    public interface IModel : IBelongToArchitecture, ICanSetArchitecture
    {
        void Init();
    }

    public abstract class AbstractModel : IModel
    {
        private IArchitecture mArchitecture;
        public IArchitecture GetArchitecture()
        {
            return mArchitecture;
        }

        public void SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }
        void IModel.Init()
        {
            OnInit();
        }

        public abstract void OnInit();
    }
}