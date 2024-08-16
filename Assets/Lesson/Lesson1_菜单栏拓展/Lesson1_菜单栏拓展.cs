

using UnityEditor;
using UnityEngine;

public class Lesson1_菜单栏拓展
	{
    [MenuItem("Unity编辑器拓展/Lesson1/CustomFun ")]
    private static void CustomFun()
    {
        Debug.Log("CustomFun");
    }

    [MenuItem("GameObject/Lesson1/HierarchyFun %#&B")]
    private static void HierarchyFun()
    {
        Debug.Log("HierarchyFun");
    }

    [MenuItem("Assets/Lesson1/AssetFun")]
    private static void AssetFun()
    {
        Debug.Log("AssetFun");
    }

    [MenuItem("CONTEXT/Lesson1_Test/Lesson1/BehaviourFun")]
    private static void BehaviourFun()
    {
        Debug.Log("BehaviourFun");
    }



}

