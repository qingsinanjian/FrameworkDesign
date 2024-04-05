using Counter;
using UnityEditor;
using UnityEngine;

public class EditorCounterApp : EditorWindow
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

    private void OnGUI()
    {
        if (GUILayout.Button("+"))
        {
            new AddCountCommand().Execute();
        }

        GUILayout.Label(CounterApp.Get<ICounterModel>().Count.Value.ToString());

        if(GUILayout.Button("-"))
        {
            new SubCountCommand().Execute();
        }
    }
}
