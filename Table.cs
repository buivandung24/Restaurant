using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public bool canSit = false;
    private bool checkTable = true;
    public GameObject table;
    public bool isFacingRight;
    void Start() {
        canSit = false;
    }
    private void Update() {
        if(checkTable){
            if(table.activeSelf){
                canSit = true;
                checkTable = false;
            }
        }
    }
}
