using Counter;
using FrameworkDesign;
using UnityEditor;
using UnityEngine;

public class EditorCounterApp : EditorWindow, IController
{
    [MenuItem("EditorCounterApp/Open")]
    static void Open()
    {
        CounterApp.OnRegisterPatch += app =>
        {
            app.RegisterUtility<IStorage>(new EditorPrefsStorage());
        };

        var window = GetWindow<EditorCounterApp>();
        window.position = new Rect(100, 100, 400, 600);
        window.titleContent = new GUIContent(nameof(EditorCounterApp));
        window.Show();
    }

    IArchitecture IBelongToArchitecture.GetArchitecture()
    {
        return CounterApp.Interface;
    }

    private void OnGUI()
    {
        if (GUILayout.Button("+"))
        {
            this.SendCommand<AddCountCommand>();
        }

        GUILayout.Label(CounterApp.Get<ICounterModel>().Count.Value.ToString());

        if(GUILayout.Button("-"))
        {
            this.SendCommand<SubCountCommand>();
        }
    }
}
