
using System.IO;
using UnityEditor;
using UnityEngine;


namespace Gavin
{

	public class Lesson38_EditorUtility: EditorWindow
	{
        private float value;
        private GameObject objTest1;
		[MenuItem("Unity编辑器拓展/Lesson38/EditorUtility")]
		private static void OpenLesson38()
        {
			Lesson38_EditorUtility ew = GetWindow<Lesson38_EditorUtility>("EditorUtility");
			ew.Show();
        }


        private void OnGUI()
        {
            if (GUILayout.Button("提示窗口"))
            {
                if (EditorUtility.DisplayDialog("确认窗口","确定吗？","确定"))
                {
                    Debug.Log("提示窗口被确定");
                }
                else
                {
                    Debug.Log("提示窗口被取消");
                }

            }

            if (GUILayout.Button("显示三键提示窗口"))
            {
                int result = EditorUtility.DisplayDialogComplex("三键提示", "显示信息", "选项1", "关闭", "选项2");
                switch (result)
                {
                    case 0:
                        Debug.Log("选项1按下了");
                        break;
                    case 1:
                        Debug.Log("关闭键按下了");
                        break;
                    case 2:
                        Debug.Log("选项2按下了");
                        break;
                    default:
                        break;
                }

                Debug.Log("三键窗口显示完毕");
            }

            if (GUILayout.Button("显示更新进度条"))
            {
                value += 0.1f;
                EditorUtility.DisplayProgressBar("进度条标题", "进度条窗口显示内容", value);
                Debug.Log("进度条窗口显示完毕");
            }

            if (GUILayout.Button("关闭进度条"))
            {
                value = 0;
                EditorUtility.ClearProgressBar();
            }

            //1.显示文件存储面板
            if (GUILayout.Button("打开文件存储面板"))
            {
                string str = EditorUtility.SaveFilePanel("保存我的文件", Application.dataPath, "Test", "txt");
                Debug.Log(str);
                if (str != "")
                    File.WriteAllText(str, "123123123123123");
            }
            //2.显示文件存储面板（默认为工程目录中）
            if (GUILayout.Button("打开文件存储面板（仅限工程文件夹下）"))
            {
                string str2 = EditorUtility.SaveFilePanelInProject("保存项目内的文件", "Test2", "png", "自定义文件");
                Debug.Log(str2);
            }
            //3.显示文件夹存储面板
            if (GUILayout.Button("显示文件夹存储面板"))
            {
                string str3 = EditorUtility.SaveFolderPanel("得到一个存储路径（文件夹）", Application.dataPath, "");
                Debug.Log(str3);
            }

            //4.显示打开文件面板
            if (GUILayout.Button("显示打开文件面板"))
            {
                string str4 = EditorUtility.OpenFilePanel("得到一个文件路径", Application.dataPath, "txt");
                if (str4 != "")
                {
                    string txt = File.ReadAllText(str4);
                    Debug.Log(txt);
                }
            }

            //5.显示打开文件夹面板
            if (GUILayout.Button("显示打开文件夹面板"))
            {
                string str4 = EditorUtility.OpenFolderPanel("得到一个文件路径", Application.dataPath, "");
                if (str4 != "")
                {
                    Debug.Log(str4);
                }
            }

            objTest1 = EditorGUILayout.ObjectField("想要查找关联资源的对象", objTest1, typeof(GameObject), true) as GameObject;
            if (GUILayout.Button("检索依赖资源"))
            {
                Object[] objs = EditorUtility.CollectDependencies(new Object[] { objTest1 });
                Selection.objects = objs;
            }

        }

    }

}
