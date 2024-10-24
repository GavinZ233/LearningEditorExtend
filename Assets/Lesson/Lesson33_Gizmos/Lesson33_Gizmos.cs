
using UnityEngine;


namespace Gavin
{

	public class Lesson33_Gizmos: MonoBehaviour
	{
        public bool DrawCube;
        public bool DrawWireCube;
        public bool DrawFrustum;

        public bool DrawGUITexture;
        public bool DrawIcon;


        public Texture pic;
        public Mesh mesh;

        public bool DrawLine;
        public bool DrawRay;

        public bool DrawMesh;
        public bool DrawWireMesh;
        public bool DrawSphere;
        public bool DrawWireSphere;




        [Header("FrustumValue")]
        public float fov=30;
        public float maxRange=30;
        public float minRange=1;
        public float aspect=2;

        private void OnDrawGizmos()
        {
            Gizmos.matrix = Matrix4x4.identity;
            Gizmos.color = Color.red;
            if(DrawCube)    Gizmos.DrawCube(transform.position+Vector3.left,Vector3.one);
            Gizmos.color = Color.green;
            // Gizmos.DrawWireCube(transform.position+Vector3.right, Vector3.one);

            Gizmos.color = new Color(1,1,1,0.6f);

            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
            if (DrawFrustum) Gizmos.DrawFrustum(Vector3.zero , fov, maxRange, minRange, aspect);

            Gizmos.matrix = transform.localToWorldMatrix;
            if (DrawWireCube) Gizmos.DrawWireCube(Vector3.zero, new Vector3(1,2, 3));
        }

        private void OnDrawGizmosSelected()
        {
            if(DrawGUITexture)    if (pic!=null) Gizmos.DrawGUITexture(new Rect(2,2,5,5),pic);

            if (DrawIcon) Gizmos.DrawIcon(transform.position+Vector3.up, "Erro",false);


            Gizmos.color = Color.red;
            if(DrawLine) Gizmos.DrawLine(transform.position, transform.position + Vector3.one*3);
            Gizmos.color = Color.green;

            //第二个是方向
            if (DrawRay) Gizmos.DrawRay(transform.position, transform.right* 5);

           // Gizmos.matrix = transform.localToWorldMatrix;

            Gizmos.color = Color.gray;

            if (DrawMesh)   if (mesh != null) Gizmos.DrawMesh(mesh,transform.position,transform.rotation,transform.localScale);
            Gizmos.color = Color.white;

            if (DrawWireMesh) if (mesh != null) Gizmos.DrawWireMesh(mesh, transform.position, transform.rotation);

            Gizmos.color = Color.black;
            if (DrawSphere) Gizmos.DrawSphere(transform.position,3);

            Gizmos.color = Color.yellow;
            if (DrawWireSphere) Gizmos.DrawWireSphere(transform.position, 3);

        }

    }

}
