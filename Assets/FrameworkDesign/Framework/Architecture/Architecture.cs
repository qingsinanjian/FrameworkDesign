namespace FrameworkDesign
{
    public abstract class Architecture<T> where T : Architecture<T>, new()
    {
        private static T mArcgitecture;

        private static void MakeSureArchitecture()
        {
            if(mArcgitecture == null)
            {
                mArcgitecture = new T();
                mArcgitecture.Init();
            }
        }

        protected abstract void Init();
        
        private IOCContainer mContainer = new IOCContainer();

        public static T Get<T>() where T : class
        {
            MakeSureArchitecture();
            return mArcgitecture.mContainer.Get<T>();
        }

        public void Register<T>(T instance)
        {
            MakeSureArchitecture();
            mArcgitecture.mContainer.Register<T>(instance);
        }
    }
}


