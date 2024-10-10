
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
			Handles.color = new Color(1,0,0,0.5f);

			Handles.Label(obj.transform.position+Vector3.up,"handle的文本");
			//划线

			Handles.DrawLine(obj.transform.position, obj.transform.position+obj.transform.forward * -15, 3) ;
			Handles.color = Color.blue;

			Handles.DrawDottedLine(obj.transform.position, obj.transform.position + obj.transform.up * -15, 3);

			//其他形状
			Handles.color = Color.white;
			Handles.DrawWireArc(obj.transform.position,obj.transform.up,Quaternion.Euler(0,-30,0)* obj.transform.forward, 60,-15);

			Handles.color = Color.black;
			Handles.DrawSolidArc(obj.transform.position, obj.transform.up, Quaternion.Euler(0, -30, 0) * obj.transform.forward, 60, -15);

			Handles.color = Color.gray;
			Handles.DrawSolidDisc(obj.transform.position,obj.transform.up,5);
			Handles.DrawWireDisc(obj.transform.position, obj.transform.up, 6);

			Handles.color = Color.green;
			Handles.DrawWireCube(obj.transform.position, new Vector3(3, 4, 5));


			Handles.color = Color.yellow;

			Handles.DrawPolyLine(obj.transform.position, obj.transform.position + obj.transform.right * -15, obj.transform.position + obj.transform.right * -15 + obj.transform.up * -15, obj.transform.position);


			Handles.DrawAAConvexPolygon(Vector3.zero,Vector3.right,Vector3.right+Vector3.forward,Vector3.forward);

			//辅助Transform
			obj.transform.position = Handles.DoPositionHandle(obj.transform.position,obj.transform.rotation);
			obj.transform.rotation = Handles.RotationHandle( obj.transform.rotation, obj.transform.position);
			//最后GetHandleSize是根据目标坐标与摄像机的距离设置缩放图标的比例，
			//obj.transform.localScale = Handles.DoScaleHandle(obj.transform.localScale, obj.transform.position,obj.transform.rotation,HandleUtility.GetHandleSize(obj.transform.position));

			obj.transform.localScale = Handles.ScaleHandle(obj.transform.localScale, obj.transform.position, obj.transform.rotation, HandleUtility.GetHandleSize(Vector3.zero));

			//DoScaleHandle与ScaleHandle同理，不带Do的方法是新方法


		}


	}

}
