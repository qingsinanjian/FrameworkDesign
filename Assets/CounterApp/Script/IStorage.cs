#if UNITY_EDITOR
using FrameworkDesign;
using UnityEditor;
#endif
using UnityEngine;

namespace Counter
{
    public interface IStorage : IUtility
    {
        void SaveInt(string key, int value);
        int LoadInt(string key, int defaultValue);
    }

    public class PlayerPrefsStorage : IStorage
    {
        public int LoadInt(string key, int defaultValue)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public void SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }
    }

    public class EditorPrefsStorage : IStorage
    {
        public int LoadInt(string key, int defaultValue)
        {
#if UNITY_EDITOR
            return EditorPrefs.GetInt(key, defaultValue);
#else
            return 0;
#endif
        }

        public void SaveInt(string key, int value)
        {
#if UNITY_EDITOR
            EditorPrefs.SetInt(key, value);
#endif
        }
    }
}