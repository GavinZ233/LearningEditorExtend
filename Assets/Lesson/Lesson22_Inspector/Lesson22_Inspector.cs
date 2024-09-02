using System.Collections.Generic;
using UnityEngine;

    
public class Lesson22_Inspector : MonoBehaviour
{
    public int atk;
    public float heath;
    public GameObject obj;
    public List<string> strs=new List<string>() { "dsad","dsadsa"};
    public int[] values;
    public PlayerInfo playerInfo;
}
[System.Serializable]
public class PlayerInfo
{
    public string ID;
    public string Name;
    public int HP;
    public int Level;
}


