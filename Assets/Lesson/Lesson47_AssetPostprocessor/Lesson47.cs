
using UnityEditor;
using UnityEngine;


namespace Gavin
{

	public class Lesson47: AssetPostprocessor
	{
		bool isTargetPath = false;


		//导入资源之前调用
		void OnPreprocessTexture()
        {
            if (assetPath.Contains("Material"))
            {
				isTargetPath = true;
                Debug.Log("纹理处理：" + assetPath);
                TextureImporter textureImporter=assetImporter as TextureImporter;
                textureImporter.sRGBTexture = false;
            }
        }

		void OnPostprocessTexture(Texture2D texture)
        {
			if (isTargetPath)
			{
                Debug.Log("纹理后处理：" + texture.name);
                EditorUtility.CompressTexture(texture, TextureFormat.ETC_RGB4, TextureCompressionQuality.Fast);
                Debug.Log(isTargetPath);
                isTargetPath = false;

            }
        }

	}

}
