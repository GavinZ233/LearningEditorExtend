using UnityEngine;
using UnityEditor;

public class Lesson26_Window : EditorWindow {
    [MenuItem("Unity编辑器拓展/Lesson26/SceneExtendWindow")]
    private static void ShowWindow() {
        Lesson26_Window win = EditorWindow.CreateWindow<Lesson26_Window>();
        win.Show();
      
    }

    private void OnEnable() {
        SceneView.duringSceneGui += SeceneUpdate;
    }
    private void SeceneUpdate(SceneView sceneView)
    {
        Debug.Log("Editor窗口拓展Scene Update");
    }
    private void OnDestroy() {
        SceneView.duringSceneGui -= SeceneUpdate;

    }
    private void OnGUI() {
        
    }
}