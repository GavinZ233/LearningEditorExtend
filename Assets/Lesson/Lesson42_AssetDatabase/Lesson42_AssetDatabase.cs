
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Gavin
{

	public class Lesson42_AssetDatabase: EditorWindow
	{
		[MenuItem("Unity编辑器拓展/Lesson42/AssetDatabase")]
		private static void OpenLesson42()
        {
			Lesson42_AssetDatabase win = EditorWindow.GetWindow<Lesson42_AssetDatabase>("AssetDatabase方法");
			win.Show();
		}

        private void OnGUI()
        {
            //1.创建资源,我们可以通过代码动态创建一些资源
            //  路径从 Assets/...开始
            //  AssetDatabase.CreateAsset(资源,路径);
            //  注意：
            //  不能在StreamingAssets中创建资源，
            //  不能创建预设体（预设体创建之后会讲），
            //  只能创建资源相关，例如材质球等
            //  路径需要写后缀
            if (GUILayout.Button("创建资源"))
            {
                Material mat = new Material(Shader.Find("Specular"));
                AssetDatabase.CreateAsset(mat, "Assets/Resources/MyMaterial.mat");
            }

            //2.创建文件夹，路径从 Assets/...开始
            //  AssetDatabase.CreateFolder(父文件夹，新文件夹名)
            if (GUILayout.Button("创建文件夹"))
            {
                AssetDatabase.CreateFolder("Assets/Resources", "MyTestFolder");
            }

            //3.拷贝资源，路径从 Assets/...开始
            //  AssetDatabase.CopyAsset(源资源，目标路径)
            //  注意：
            //  需要写后缀名
            if (GUILayout.Button("拷贝资源"))
            {
                AssetDatabase.CopyAsset("Assets/Editor Default Resources/pdf.png", "Assets/Resources/MyTestFolder/pdf.png");
            }

            //4.移动资源，路径从 Assets/...开始
            //  AssetDatabase.MoveAsset(老路径, 新路径);
            if (GUILayout.Button("移动资源"))
            {
                AssetDatabase.MoveAsset("Assets/Resources/MyTestFolder/pdf.png", "Assets/Resources/pdf.png");
            }

            //5.删除资源，路径从 Assets/...开始
            //  AssetDatabase.DeleteAsset(资源路径)
            if (GUILayout.Button("删除资源"))
            {
                AssetDatabase.DeleteAsset("Assets/Resources/pdf.png");
            }

            //6.批量删除资源，路径从 Assets/...开始
            //  AssetDatabase.DeleteAssets(string[] 路径们, List<string> 用于存储删除失败的路径)
            if (GUILayout.Button("批量删除资源"))
            {
                List<string> failList = new List<string>();
                AssetDatabase.DeleteAssets(new string[] { "Assets/Resources/pdf.png", "Assets/Resources/pdf2.png" }, failList);
                for (int i = 0; i < failList.Count; i++)
                {
                    Debug.Log(failList[i]);
                }
            }

            //7.获取资源路径 可以配合Selection选中资源一起使用
            //  AssetDatabase.GetAssetPath(资源)
            if (GUILayout.Button("获取资源路径"))
            {
                Debug.Log(AssetDatabase.GetAssetPath(Selection.activeObject));
            }

            //8.根据路径加载资源，路径从Assets/开始
            //  AssetDatabase.LoadAssetAtPath(资源路径)
            if (GUILayout.Button("加载资源"))
            {
                Texture txt = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Resources/pdf.png");
                Debug.Log(txt.name);
            }

            //9.根据路径加载所有资源，路径从Assets/开始
            //  AssetDatabase.LoadAllAssetsAtPath(资源路径);
            //  一般可以用来加载图集资源，返回值为Object数据
            //  如果是图集，第一个为图集本身，之后的便是图集中的所有Sprite
            //if (GUILayout.Button(""))
            //{
            //    //AssetDatabase.LoadAllAssetsAtPath(资源路径);
            //}

            //10.刷新，当对资源进行移动、导入、删除等操作后，需要执行刷新
            //  AssetDatabase.Refresh()
            if (GUILayout.Button("测试刷新"))
            {
                File.WriteAllText(Application.dataPath + "/Resources/test2.txt", "123123123");
                AssetDatabase.Refresh();
            }

            //11.返回资源所属的AB包名，路径从Assets/开始
            //  GetImplicitAssetBundleName（资源路径);
            //if (GUILayout.Button(""))
            //{

            //}
        }

    }

}
