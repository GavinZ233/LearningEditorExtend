using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Lesson22_Inspector))]
public class Lesson22_InspectorEditor : Editor
{
    //将需要自定义的属性做声明
    private SerializedProperty atk;
    private SerializedProperty hp;
    private SerializedProperty obj;
    private bool foldout;

    private SerializedProperty strs;
    private SerializedProperty values;

    private int count;
    private bool infoisClose;

    private SerializedProperty playerInfo;
    private SerializedProperty infoID;
    private SerializedProperty infoName;
    private SerializedProperty infoHP;
    private SerializedProperty infoLevel;

    private int dicCount;
    private SerializedProperty dicKeys;
    private SerializedProperty dicValues;
    private void OnEnable()
    {
        //初始化，找到双方属性做关联
        //serializedObject就是自定义的目标脚本
        atk = serializedObject.FindProperty("atk");
        hp = serializedObject.FindProperty("heath");
        obj = serializedObject.FindProperty("obj");
        strs = serializedObject.FindProperty("strs");
        values = serializedObject.FindProperty("values");
        playerInfo = serializedObject.FindProperty("playerInfo");

        infoID = playerInfo.FindPropertyRelative("ID");
        infoName = playerInfo.FindPropertyRelative("Name");
        infoHP = playerInfo.FindPropertyRelative("HP");
        infoLevel = playerInfo.FindPropertyRelative("Level");

        dicKeys = serializedObject.FindProperty("keyList");
        dicValues = serializedObject.FindProperty("valueList");
        dicCount = dicKeys.arraySize;
    }
    //  该函数控制了Inspector窗口中显示的内容
    //  只需要在其中重写内容便可以自定义窗口
    public override void OnInspectorGUI()
    {
         // base.OnInspectorGUI();
        serializedObject.Update();
        foldout = EditorGUILayout.BeginFoldoutHeaderGroup(foldout,"基础属性");
        if (foldout)
        {
            EditorGUILayout.IntSlider(atk,0,15, "攻击");
            //EditorGUILayout.Slider(hp, 0, 100, "血量");
            hp.floatValue = EditorGUILayout.FloatField("血量",hp.floatValue);

            EditorGUILayout.ObjectField(obj,new GUIContent("对象"));

            if (GUILayout.Button("打印目标名称"))
            {
                Debug.Log(target.ToString());
            }

            GUILayout.Space(15);

            count = EditorGUILayout.IntField("value容量", count);
            for (int i = values.arraySize - 1; i >= count; i--)
            {
                values.DeleteArrayElementAtIndex(i);
            }
            for (int i = 0; i < count; i++)
            {
                if (i >= values.arraySize)
                {
                    values.InsertArrayElementAtIndex(i);
                    values.GetArrayElementAtIndex(i).intValue=0;
                }
                SerializedProperty indexPro = values.GetArrayElementAtIndex(i);
                indexPro.intValue = EditorGUILayout.IntField(($"索引{i}"), indexPro.intValue);
            }
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        EditorGUILayout.PropertyField(strs, new GUIContent("字符串组"));
        //EditorGUILayout.PropertyField(values, new GUIContent("values"));

        EditorGUILayout.PropertyField(playerInfo, new GUIContent("API显示"));

        infoisClose = EditorGUILayout.BeginFoldoutHeaderGroup(infoisClose, "玩家属性");
        if (infoisClose)
            DrawCustomData();
        EditorGUILayout.EndFoldoutHeaderGroup();



        dicCount = EditorGUILayout.IntField("字典数量", dicCount);

        for (int i = dicKeys.arraySize-1; i >=dicCount; i--)
        {
            dicKeys.DeleteArrayElementAtIndex(i);
            dicValues.DeleteArrayElementAtIndex(i);
        }

        for (int i = 0; i < dicCount; i++)
        {
            if (dicKeys.arraySize<=i)
            {
                dicKeys.InsertArrayElementAtIndex(i);
                dicValues.InsertArrayElementAtIndex(i);
            }

            SerializedProperty indexKey = dicKeys.GetArrayElementAtIndex(i);
            SerializedProperty indexValue = dicValues.GetArrayElementAtIndex(i);
            EditorGUILayout.BeginHorizontal();
            indexKey.intValue = EditorGUILayout.IntField("学号：", indexKey.intValue);
            indexValue.stringValue = EditorGUILayout.TextField("姓名：", indexValue.stringValue);
            EditorGUILayout.EndHorizontal();


        }
        //应用序列化
        serializedObject.ApplyModifiedProperties();

    }
    private void DrawCustomData()
    {
        EditorGUILayout.LabelField("自定义显示");

        infoID .stringValue= EditorGUILayout.TextField("ID",infoID.stringValue);
        infoName.stringValue = EditorGUILayout.TextField("Name", infoName.stringValue);
        infoHP.intValue = EditorGUILayout.IntField("HP", infoHP.intValue);
        infoLevel.intValue = EditorGUILayout.IntField("Level", infoLevel.intValue);

    }
}
