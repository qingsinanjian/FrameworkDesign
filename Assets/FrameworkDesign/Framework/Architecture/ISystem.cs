using UnityEngine;

namespace FrameworkDesign
{
    public interface ISystem : IBelongToArchitecture
    {
        void Init();
    }
}

