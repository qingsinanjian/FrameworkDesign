namespace FrameworkDesign
{
    public interface ICommand : IBelongToArchitecture, ICanSetArchitecture
    {
        void Execute();
    }

    public abstract class AbstractCommand : ICommand
    {
        private IArchitecture mArchitecture;
        void ICommand.Execute()
        {
            OnExecute();
        }

        protected virtual void OnExecute() { }

        public IArchitecture GetArchitecture()
        {
            return mArchitecture;
        }

        public void SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;           
        }
    }
}


