using UnityEditor;
using UnityEngine;

 public enum E_TestType
{
    One=1,
    Two=2,
    Three=4,
    OneAndTwo=1|2,

}   
public class Lesson3_EditorGUI : EditorWindow
{
    int layer;
    string tag;
    Color color;
    E_TestType testType;
    E_TestType mulType;

    string[] strs = { "德玛西亚","祖安","诺克萨斯"};

    int[] ints = { 3, 4, 1 };
    int selectInt;

    GameObject obj;

    int inputInt;
    string inputStr;
    Vector2 inputV2;
    Vector3 inputV3;
    Vector4 inputV4;
    Vector2Int v2Int;

    Rect rect;
    Bounds bound;

    bool isHide;
    bool isHideGroup;

    bool toggle;
    bool toggleGroup;

    float sliderFloat;
    int sliderInt;

    float leftSlider;
    float rightSlider;

    Vector2 scrollView;

    AnimationCurve curve = new AnimationCurve();

    [MenuItem("Unity编辑器拓展/Lesson3/EditorGUI")]
    private static void OpenLesson3()
    {
        Lesson3_EditorGUI win = EditorWindow.GetWindow<Lesson3_EditorGUI>("EditorGUI");
        
        win.Show();
    }
    private void OnGUI()
    {
        //GUILayoutOption 布局选项
        //控件的固定宽高
        //GUILayout.Width(300);
        //GUILayout.Height(200);
        //允许控件的最小宽高
        //GUILayout.MinWidth(50);
        //GUILayout.MinHeight(50);
        //允许控件的最大宽高
        //GUILayout.MaxWidth(100);
        //GUILayout.MaxHeight(100);
        //允许或禁止水平拓展
        //GUILayout.ExpandWidth(true);//允许
        //GUILayout.ExpandHeight(false);//禁止
        //GUILayout.ExpandHeight(true);//允许
        //GUILayout.ExpandHeight(false);//禁止

        isHide = EditorGUILayout.Foldout(isHide, "折叠：", true);
        if (isHide)
        {
            EditorGUILayout.LabelField("111","22222");

            layer=EditorGUILayout.LayerField("这是层级",layer,GUILayout.MaxWidth(321),GUILayout.MinHeight(15));

            tag=EditorGUILayout.TagField("tag:",tag,GUILayout.ExpandWidth(false));

            color = EditorGUILayout.ColorField(new GUIContent("颜色："),color, GUILayout.MinHeight(15));

            testType = (E_TestType)EditorGUILayout.EnumPopup("枚举：",testType);

            mulType = (E_TestType)EditorGUILayout.EnumFlagsField("枚举多选：", mulType);

            selectInt = EditorGUILayout.IntPopup("整数单选：", selectInt, strs,ints);

            EditorGUILayout.LabelField("数组选中", selectInt.ToString());

            if (EditorGUILayout.DropdownButton(new GUIContent("按钮"),FocusType.Keyboard))
            {
                Debug.Log("DropdownButton点击");
            }
            if (EditorGUILayout.LinkButton("按钮"))
            {
                Debug.Log("LinkButton");
            }
            // allowSceneObjects  是否关联当前场景目标
            obj = EditorGUILayout.ObjectField("关联Obj：",obj,typeof(GameObject),true) as GameObject;

            scrollView = EditorGUILayout.BeginScrollView(scrollView);


            inputInt = EditorGUILayout.IntField("Int输入：", inputInt);
            //Float、long、double
            inputStr = EditorGUILayout.TextField("字符串输入：", inputStr);

            inputV2 = EditorGUILayout.Vector2Field("V2输入：", inputV2);

            inputV3 = EditorGUILayout.Vector3Field("V3输入：", inputV3);

            inputV4 = EditorGUILayout.Vector4Field("V4输入：", inputV4);

            v2Int = EditorGUILayout.Vector2IntField("IntV2", v2Int);

            rect = EditorGUILayout.RectField("rect:", rect);
            //3D范围
            bound = EditorGUILayout.BoundsField("bound", bound);
            //Vector rect  bound  都有Int版本



            inputInt = EditorGUILayout.DelayedIntField("延迟Int：", inputInt);
            //double float int string   四种输入框可以delay。delay的等到焦点离开本控件才会保存数据，避免频繁写入
            EditorGUILayout.EndScrollView();


        }

        isHideGroup = EditorGUILayout.BeginFoldoutHeaderGroup(isHideGroup, "折叠组：");
        if (isHideGroup)
        {
            inputStr = EditorGUILayout.TextArea(inputStr);

            sliderFloat = EditorGUILayout.Slider("slider:", sliderFloat, 0, 55);

            sliderInt = EditorGUILayout.IntSlider("intSlider:", sliderInt, 0, 6);
            EditorGUILayout.MinMaxSlider("双块", ref rightSlider, ref leftSlider, 0, 12);

        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        //折叠组会高亮加粗

        //被toggle组包裹的代码会被置灰
        toggleGroup = EditorGUILayout.BeginToggleGroup("togGroup:",toggleGroup);

        toggle =EditorGUILayout.Toggle("Toggle：",toggle);
        toggle = EditorGUILayout.ToggleLeft("TogLeft", toggle);

        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.Space(31);//空行

        curve = EditorGUILayout.CurveField("曲线：", curve);

        if (GUILayout.Button("点击按钮"))
        {
            Debug.Log("点击按钮");
        }

        EditorGUILayout.HelpBox("tishi", MessageType.None);
        EditorGUILayout.HelpBox("tishi", MessageType.Info);


        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.HelpBox("tishi", MessageType.Warning);
        EditorGUILayout.HelpBox("tishi", MessageType.Error);


        EditorGUILayout.EndHorizontal();




    }

}

