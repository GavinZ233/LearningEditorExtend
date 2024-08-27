using UnityEditor;
using UnityEngine;

    
public class Lesson13_EditorGUIUtility : EditorWindow
{
    [MenuItem("Unity编辑器拓展/Lesson13/EditorGUIUtility学习面板")]
    private static void OpenLesson12()
    {
        Lesson13_EditorGUIUtility win = EditorWindow.GetWindow<Lesson13_EditorGUIUtility>("EditorGUIUtility学习面板");
        win.Show();
    }

    Texture img;

    private void OnGUI()
    {
        if (GUILayout.Button("图片"))
        {
            img = EditorGUIUtility.Load("Pdf.jpg") as Texture;
        }
        if (img!=null)
        {
            GUI.DrawTexture(new Rect(0, 20, 50, 50),img);
        }
    }

}

