
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;


namespace Gavin
{

	public class Lesson45_EditorSceneManager: EditorWindow
	{
        [MenuItem("Unity编辑器拓展/Lesson45/EditorSceneManager")]
        private static void OpenLesson44()
        {
            Lesson45_EditorSceneManager win = EditorWindow.GetWindow<Lesson45_EditorSceneManager>("EditorSceneManager");
            win.Show();
        }


        private void OnGUI()
        {
            if (GUILayout.Button("EnterPlaymode"))
            {
                EditorApplication.EnterPlaymode();
            }
            if (GUILayout.Button("ExitPlaymode"))
            {
                EditorApplication.ExitPlaymode();
            }
            if (GUILayout.Button("applicationContentsPath"))
            {
                Debug.Log(EditorApplication.applicationContentsPath);
            }
            if (GUILayout.Button("applicationPath"))
            {
                Debug.Log(EditorApplication.applicationPath);
            }
            if (GUILayout.Button("Bee"))
            {
                EditorApplication.Beep();
            }
            if (GUILayout.Button("创建场景"))
            {
                EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects);
            }
            if (GUILayout.Button("保存场景"))
            {
                EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene(),"Assets/Scenes/SaveScene.unity");
            }
            if (GUILayout.Button("打开场景"))
            {
                EditorSceneManager.OpenScene("Assets/Scenes/SaveScene.unity");
            }
            if (GUILayout.Button("当前场景路径"))
            {
                Debug.Log(EditorSceneManager.GetActiveScene().path);
            } 
        }

    }

}
