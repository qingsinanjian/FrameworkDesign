using System;
using UnityEngine;

namespace FrameworkDesign
{
    public class Event<T> where T : Event<T>
    {
        private static Action mOnEvent;

        public static void Register(Action onEvent)
        {
            mOnEvent += onEvent;
        }

        public static void UnRegister(Action onEvent)
        {
            mOnEvent -= onEvent;
        }

        /// <summary>
        /// �����¼�
        /// </summary>
        public static void Trigger()
        {
            mOnEvent?.Invoke();
        }
    }
}

