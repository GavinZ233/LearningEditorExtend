
using UnityEngine;
using UnityEditor;

namespace Gavin
{
	[CustomEditor(typeof(Lesson26))]
	public class Lesson26_Handles: Editor
	{
		private void OnSceneGUI() {
			Debug.Log("Scene窗口开始渲染");	
		}
	}

}
