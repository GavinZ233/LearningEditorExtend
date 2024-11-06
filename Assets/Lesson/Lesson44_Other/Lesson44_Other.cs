
using UnityEditor;
using UnityEngine;


namespace Gavin
{

	public class Lesson44_Other: EditorWindow
	{
		[MenuItem("Unity编辑器拓展/Lesson44/Other")]
		private static void OpenLesson44()
        {
			Lesson44_Other win = EditorWindow.GetWindow<Lesson44_Other>("Other");
			win.Show();
        }

        private void OnGUI()
        {
            //1.动态创建预设体 路径从Assets/...开始
            //  PrefabUtility.SaveAsPrefabAsset(GameObject对象, 路径);
            if (GUILayout.Button("动态创建预设体"))
            {
                GameObject obj = new GameObject();
                obj.AddComponent<Rigidbody>();
                obj.AddComponent<BoxCollider>();
                PrefabUtility.SaveAsPrefabAsset(obj, "Assets/Lesson/Lesson44_Other/TestObj.prefab");
                DestroyImmediate(obj);
            }

            //2.加载预制体对象（不能用于创建，一般用于修改，会把预设体加载到内存中）
            //  路径从Assets/...开始
            //  PrefabUtility.LoadPrefabContents(路径)
            //  释放加载的预设体对象
            //  PrefabUtility.UnloadPrefabContents(GameObject对象)
            //  注意：这两个方法需要配对使用，加载了就要释放

            //这里的加载 本质上其实已经把预设体进行了实例化了 只不过该实例化对象并不是在传统的Scene窗口中（是在一个看不见的独立的场景中）
            if (GUILayout.Button("加载预制体对象"))
            {
                //加载 到内存中 不能用来实例化 一般加载出来是进行修改的
                GameObject testObj = PrefabUtility.LoadPrefabContents("Assets/Lesson/Lesson44_Other/TestObj.prefab");
                testObj.AddComponent<MeshRenderer>();
                //这种加载方式 是可以进行脚本移除 子对象创建的
               // DestroyImmediate(testObj.GetComponent<MeshRenderer>());
               // GameObject obj = new GameObject("新建子对象");
               // obj.transform.parent = testObj.transform;
                PrefabUtility.SaveAsPrefabAsset(testObj, "Assets/Lesson/Lesson44_Other/TestObj.prefab");
                //释放 一定要配合使用
                PrefabUtility.UnloadPrefabContents(testObj);
            }

            //3.修改已有预设体 
            //  PrefabUtility.SavePrefabAsset(预设体对象, out bool 是否保存成功);
            //  可以配合AssetDatabase.LoadAssetAtPath使用
            if (GUILayout.Button("修改已有预设体 "))
            {
                GameObject testObj = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Lesson/Lesson44_Other/TestObj.prefab");
                testObj.AddComponent<BoxCollider>();
                //这个方法不能存储实例化后的内容 只能存储对应的预设体对象
                PrefabUtility.SavePrefabAsset(testObj);
            }

            //4.实例化预设体
            //  PrefabUtility.InstantiatePrefab(Object对象)
            if (GUILayout.Button("实例化预设体"))
            {
                GameObject testObj = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Lesson/Lesson44_Other/TestObj.prefab");
                PrefabUtility.InstantiatePrefab(testObj);

            }
        }
    }

}
