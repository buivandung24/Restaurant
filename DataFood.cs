using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

[CreateAssetMenu(fileName = "MenuData", menuName = "ScriptableOjects/Food")]
public class DataFood : ScriptableObject
{
    public Food[] food;
    [System.Serializable]
    public class Food{
        public string name;
        public float time;
        public float cost;
    }
}
