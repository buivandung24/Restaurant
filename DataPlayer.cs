using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MenuData", menuName = "ScriptableOjects/Player")]

public class DataPlayer : ScriptableObject
{
    public Speed[] speeds;

    [System.Serializable]
    public class Speed{
        public int lv;
        public float speed;
        public int cost;
    }

    public Capacity[] capacititys;
    [System.Serializable]
    public class Capacity{
        public int lv;
        public int capacity;
        public int cost;
    }

    public ProfitsUp[] profitsUps;
    [System.Serializable]
    public class ProfitsUp{
        public int lv;
        public float profitsUp;
        public int cost;
    }
}
