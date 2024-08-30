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
    Texture getTexture;
    Color color;
    AnimationCurve curve=new AnimationCurve();
    private void OnGUI()
    {
        if (GUILayout.Button("图片"))
        {
            img = EditorGUIUtility.Load("Pdf.jpg") as Texture;
        }
        if (img!=null)
        {
            GUI.DrawTexture(new Rect(0, 150, 100, 100),img);
        }
        if (GUILayout.Button("搜索"))
        {
            EditorGUIUtility.ShowObjectPicker<Texture>(null,true,"pdf",0);
        }
        if (Event.current.commandName=="ObjectSelectorUpdated")
        {
            getTexture = EditorGUIUtility.GetObjectPickerObject() as Texture;
            if(getTexture!=null) Debug.Log(getTexture.name);
        }
        else if(Event.current.commandName== "ObjectSelectorCLosed")
        {
            getTexture = EditorGUIUtility.GetObjectPickerObject() as Texture;
            if (getTexture != null)
                Debug.Log("窗口关闭：" + getTexture.name);
        }

        if (GUILayout.Button("高亮选中对象"))
        {
            if (getTexture!=null)
            {
                EditorGUIUtility.PingObject(getTexture);
            }
        }

        if (GUILayout.Button("发送事件"))
        {
            Event e = EditorGUIUtility.CommandEvent("事件发送");
            Lesson3_EditorGUI lesson3 = EditorWindow.GetWindow<Lesson3_EditorGUI>();
            lesson3.SendEvent(e);
        }


        if (GUILayout.Button("坐标转换"))
        {
            Vector2 v = new Vector2(0, 0);
            Vector2 screenPos = EditorGUIUtility.GUIToScreenPoint(v);
            Debug.Log(screenPos);
        }

        EditorGUIUtility.AddCursorRect(new Rect(0, 150, 100, 100),MouseCursor.Pan);

        color=EditorGUILayout.ColorField(new GUIContent("颜色"),color,true,true,true);
        EditorGUIUtility.DrawColorSwatch(new Rect(150, 150, 100, 100),color);

        curve = EditorGUILayout.CurveField("曲线",curve);
        EditorGUIUtility.DrawCurveSwatch(new Rect(300, 150, 100, 100), curve, null, Color.red, Color.white);
    }

}

