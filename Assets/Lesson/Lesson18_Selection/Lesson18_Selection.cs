using UnityEditor;
using UnityEngine;

    
public class Lesson18_Selection : EditorWindow
{
    [MenuItem("Unity编辑器拓展/Lesson18/Selection学习面板")]
    public static void OpenSelection()
    {
        Lesson18_Selection win = EditorWindow.GetWindow<Lesson18_Selection>("Selection");
        win.Show();
    }


    string str = "";
    string str2 = "";
    Texture pdf;
    private void OnGUI()
    {
        if (GUILayout.Button("打印获取内容"))
        {
            if (Selection.activeObject!=null)
            {
                str = Selection.activeObject.name;
            }
            else
            {
                str = "空";
            }
            if (Selection.activeObject is GameObject)
            {
                str = "物体";
            }
            if (Selection.activeObject is Texture)
            {
                str = "纹理";
            }
        }
        EditorGUILayout.LabelField("当前获取内容："+str);
        if (GUILayout.Button("打印获取内容"))
        {
            str2 = "";
            if (Selection.gameObjects != null)
            {
                for (int i = 0; i < Selection.gameObjects.Length; i++)
                {
                    str2 += "    "+Selection.gameObjects[i];
                }

            }
            else
            {
                str2 = "空";
            }
            pdf= EditorGUIUtility.Load("Pdf.jpg") as Texture;
        }
        EditorGUILayout.LabelField("当前获取所有内容：" + str2);
        EditorGUILayout.LabelField("当前选中数量：" + Selection.count);
        if (GUILayout.Button("选择pdf"))
        {
            Selection.activeObject = pdf;
        }

    }

}

