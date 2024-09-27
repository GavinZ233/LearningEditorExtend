using System.Collections.Generic;
using UnityEngine;

    
public class Lesson22_Inspector : MonoBehaviour,ISerializationCallbackReceiver
{
    public int atk;
    public float heath;
    public GameObject obj;
    public List<string> strs=new List<string>() { "dsad","dsadsa"};
    public int[] values;
    public PlayerInfo playerInfo;

    public Dictionary<int, string> serDic = new Dictionary<int, string>() { { 1,"张三"},{ 2,"李四"} };
    [SerializeField] private List<int> keyList = new List<int>();
    [SerializeField] private List<string> valueList = new List<string>();

    public void OnAfterDeserialize()
    {
        serDic.Clear();
        for (int i = 0; i < keyList.Count; i++)
        {
            if (!serDic.ContainsKey(keyList[i]))
                serDic.Add(keyList[i],valueList[i]);
            else
                Debug.LogWarning("已有此键："+keyList[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        keyList.Clear();
        valueList.Clear();
        foreach (var item in serDic)
        {
            keyList.Add(item.Key);
            valueList.Add(item.Value);
        }
    }
}
[System.Serializable]
public class PlayerInfo
{
    public string ID;
    public string Name;
    public int HP;
    public int Level;
}


