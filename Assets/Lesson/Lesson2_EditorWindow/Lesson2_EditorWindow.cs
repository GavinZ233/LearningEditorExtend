using UnityEditor;
using UnityEngine;

    
public class Lesson2_EditorWindow : EditorWindow
{
    static Lesson2_EditorWindow window;
    string testStr;
    bool bo;
    [MenuItem("Unity编辑器拓展/Lesson2/显示自定义面板")]
    private static void ShowWindow()
    {
        window = EditorWindow.CreateWindow<Lesson2_EditorWindow>();
        //window.titleContent = new GUIContent("我的窗口");
        window.ShowUtility();
        window.hasUnsavedChanges = true;
        window.saveChangesMessage = "saveChangesMessage";
      
        //window.position = new Rect(432,345,465,432);
        window.minSize=Vector2.one*500;
    }


    public override void SaveChanges()
    {
        base.SaveChanges();
    }

    public override void DiscardChanges()
    {
        base.DiscardChanges(); 
    }

    private void OnHierarchyChange()
    {
        Debug.Log("当Hierarchy窗口内容发生变化时");

    }

    private void OnFocus()
    {
        Debug.Log("获取焦点");
    }

    private void OnLostFocus()
    {
        Debug.Log("失去焦点");
    }

    private void OnProjectChange()
    {
        Debug.Log("当Project窗口内容发生变化时");
    }

    private void OnInspectorUpdate()
    {
      
    }
    private void OnEnable()
    {
        Debug.Log("OnEnable");

    }
    private void OnDisable()
    {
        Debug.Log("OnDisable");

    }
    private void Update()
    {
        if (window == null) return;
        if (window.docked)
        {
           // Debug.Log("docked");
        }
    }

    

    private void OnSelectionChange()
    {
        Debug.Log("当选中对象发生变化时");
        
    }

    private void OnGUI()
    {
        GUILayout.Label("测试文本");
        testStr=GUILayout.TextField(testStr);
        bo = GUILayout.Toggle(bo,"asdsaf");
        if (GUILayout.Button("测试按钮"))
        {
            Debug.Log("Test");
        }
    }

}

