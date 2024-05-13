using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    public GameObject[] chair;
    public GameObject table;

    public GameObject chairCanSit;
    void Start() {
        chairCanSit = null;
    }

    public void checkChairCanSit(){
        for(int i = 0; i < chair.Length; i++){
            if(chair[i].GetComponent<Table>().canSit == true){
                chairCanSit = chair[i];
                table = chair[i].GetComponent<Table>().table;
                chair[i].GetComponent<Table>().canSit = false;
                break;
            }
        }
    }
}
