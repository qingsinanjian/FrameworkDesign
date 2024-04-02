using CounterApp;
using UnityEditor;
using UnityEngine;

public class EditorCounterApp : EditorWindow
{
    [MenuItem("EditorCounterApp/Open")]
    static void Open()
    {
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

        //GUILayout.Label(CounterModel.Instance.Count.Value.ToString());

        if(GUILayout.Button("-"))
        {
            new SubCountCommand().Execute();
        }
    }
}
