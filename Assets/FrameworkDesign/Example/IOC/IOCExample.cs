using UnityEngine;

namespace FrameworkDesign.Example
{
    public class IOCExample : MonoBehaviour
    {
        private void Start()
        {
            var container = new IOCContainer();
            container.Register(new BluetoothManager());
            var bluetoothManager = container.Get<BluetoothManager>();
            bluetoothManager.Connect();
        }
    }

    public class BluetoothManager
    {
        public void Connect()
        {
            Debug.Log("¿∂—¿¡¥Ω”≥…π¶");
        }
    }
}

