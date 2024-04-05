using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FrameworkDesign
{
    public interface IArchitecture
    {
        void RegisterSystem<T>(T system) where T : ISystem;
        void RegisterModel<T>(T model) where T : IModel;
        void RegisterUtility<T>(T utility);
        T GetModel<T>() where T : class, IModel;
        T GetUtility<T>() where T : class;
    }


    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
        /// <summary>
        /// 是否初始化完成
        /// </summary>
        private bool mInited = false;
        /// <summary>
        /// 用于初始化的Systems的缓存
        /// </summary>
        private List<ISystem> mSystems = new List<ISystem>();

        private List<IModel> mModels = new List<IModel>();

        public static Action<T> OnRegisterPatch = architecture => { };

        private static T mArchitecture;

        private static void MakeSureArchitecture()
        {
            if(mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();

                OnRegisterPatch?.Invoke(mArchitecture);
                //初始化model
                foreach (var architectureModel in mArchitecture.mModels)
                {
                    architectureModel.Init();
                }
                mArchitecture.mModels.Clear();
                //初始化system
                foreach (var architectureSystem in mArchitecture.mSystems)
                {
                    architectureSystem.Init();
                }
                mArchitecture.mSystems.Clear();

                mArchitecture.mInited = true;
            }
        }

        protected abstract void Init();
        
        private IOCContainer mContainer = new IOCContainer();

        public static T Get<T>() where T : class
        {
            MakeSureArchitecture();
            return mArchitecture.mContainer.Get<T>();
        }

        public static void Register<T>(T instance)
        {
            MakeSureArchitecture();
            mArchitecture.mContainer.Register<T>(instance);
        }

        public void RegisterSystem<T>(T instance) where T : ISystem
        {
            instance.Architecture = this;
            mContainer.Register<T>(instance);
            if (!mInited)
            {
                mSystems.Add(instance);
            }
            else
            {
                instance.Init();
            }
        }

        public void RegisterModel<T>(T model) where T : IModel
        {
            model.Architecture = this;
            mContainer.Register<T>(model);
            if(!mInited)
            {
                mModels.Add(model);
            }
            else
            {
                model.Init();
            }
        }

        public void RegisterUtility<T>(T utility)
        {
            mContainer.Register<T>(utility);
        }

        public T GetModel<T>() where T : class, IModel
        {
            return mContainer.Get<T>();
        }

        public T GetUtility<T>() where T : class
        {
            return mContainer.Get<T>();
        }
    }
}


