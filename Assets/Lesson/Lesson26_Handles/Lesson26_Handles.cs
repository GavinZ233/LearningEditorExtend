
using UnityEngine;
using UnityEditor;

namespace Gavin
{
	/// <summary>
	/// 为脚本面板做拓展逻辑
	/// </summary>
	[CustomEditor(typeof(Lesson26))]
	public class Lesson26_Handles: Editor
	{
		private Lesson26 obj;

		private void OnEnable()
        {
			obj = target as Lesson26;
        }

		private void OnSceneGUI() {
			Debug.Log("Handle窗口OnSceneGUI");

			//Debug.Log(obj.transform.position);
			Handles.color = Color.red;
			GUI.color = Color.red;
			if(obj.Label)	Handles.Label(obj.transform.position+Vector3.up,"handle的文本");
            if (Handles.Button(obj.transform.position+ Vector3.down, obj.transform.rotation,1,3, Handles.CubeHandleCap))
            {
				Debug.Log("BtnClick");
            }
			//划线

			if (obj.DrawLine)	Handles.DrawLine(obj.transform.position, obj.transform.position+obj.transform.forward * -15, 3) ;
			Handles.color = Color.blue;

			if (obj.DrawDottedLine) Handles.DrawDottedLine(obj.transform.position, obj.transform.position + obj.transform.up * -15, 3);

			//其他形状
			Handles.color = Color.white;
			if (obj.DrawWireArc) Handles.DrawWireArc(obj.transform.position,obj.transform.up,Quaternion.Euler(0,-30,0)* obj.transform.forward, 60,-15);

			Handles.color = Color.black;
			if (obj.DrawSolidArc) Handles.DrawSolidArc(obj.transform.position, obj.transform.up, Quaternion.Euler(0, -30, 0) * obj.transform.forward, 60, -15);

			Handles.color = Color.gray;
			if (obj.DrawSolidDisc) Handles.DrawSolidDisc(obj.transform.position,obj.transform.up,5);
			if (obj.DrawWireDisc) Handles.DrawWireDisc(obj.transform.position, obj.transform.up, 6);

			Handles.color = Color.green;
			if (obj.DrawWireCube) Handles.DrawWireCube(obj.transform.position, new Vector3(3, 4, 5));


			Handles.color = Color.yellow;

			if (obj.DrawPolyLine) Handles.DrawPolyLine(obj.transform.position, obj.transform.position + obj.transform.right * -15, obj.transform.position + obj.transform.right * -15 + obj.transform.up * -15, obj.transform.position);


			if (obj.DrawAAConvexPolygon) Handles.DrawAAConvexPolygon(Vector3.zero,Vector3.right,Vector3.right+Vector3.forward,Vector3.forward);

			//辅助Transform
			if (obj.DoPositionHandle) obj.transform.position = Handles.DoPositionHandle(obj.transform.position,obj.transform.rotation);
			if (obj.RotationHandle) obj.transform.rotation = Handles.RotationHandle( obj.transform.rotation, obj.transform.position);
			//最后GetHandleSize是根据目标坐标与摄像机的距离设置缩放图标的比例，
			//obj.transform.localScale = Handles.DoScaleHandle(obj.transform.localScale, obj.transform.position,obj.transform.rotation,HandleUtility.GetHandleSize(obj.transform.position));

			if (obj.ScaleHandle) obj.transform.localScale = Handles.ScaleHandle(obj.transform.localScale, obj.transform.position, obj.transform.rotation, HandleUtility.GetHandleSize(Vector3.zero));

			//DoScaleHandle与ScaleHandle同理，不带Do的方法是新方法

			if (obj.FreeMoveHandle) obj.transform.position = Handles.FreeMoveHandle(obj.transform.position,obj.transform.rotation,HandleUtility.GetHandleSize(obj.transform.position),Vector3.one*5,Handles.RectangleHandleCap);

			if (obj.FreeRotateHandle) obj.transform.rotation = Handles.FreeRotateHandle(obj.transform.rotation, obj.transform.position, HandleUtility.GetHandleSize(obj.transform.position));

            if (obj.DrawGUI)
            {
				Handles.BeginGUI();

				float w = SceneView.currentDrawingSceneView.position.width;
				float h = SceneView.currentDrawingSceneView.position.height;
				//GUI的高度需要向上偏移25
                if (GUI.Button(new Rect(w-100,h-75,100,50),"Handles的Btn"))
                {
					Debug.Log("Handles的Btn被点击");
                }
				GUILayout.BeginArea(new Rect(w-100,h-100,100,50));

				GUILayout.Label("悬浮文字");

				GUILayout.EndArea();
				Handles.EndGUI();

				float dis = HandleUtility.DistanceToLine(Vector3.zero,Vector3.right);
				Debug.Log(dis);

				

            }

			Handles.matrix = Matrix4x4.TRS(obj.transform.position, obj.transform.rotation, obj.transform.localScale);
		}


	}

}
