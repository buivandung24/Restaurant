using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] InvisibleWall;
    public GameObject[] newArea;
    public GameObject[] upgradeArea;
    private int currentArea;
    public GameObject[] upgradeArea2;
    [Header("-------Stove-------")]
    public GameObject[] capacity;
    public GameObject[] quantity;
    void Update()
    {
        TurnOffInvisibleWall();
        TurnOnUpgradeArea();
    }

    private void TurnOffInvisibleWall(){
        for(int i = 0; i < newArea.Length; i++){
            if(newArea[i].activeSelf){
                InvisibleWall[i].SetActive(false);
            }
        }
    }

    private void TurnOnUpgradeArea(){
        if(upgradeArea[currentArea] != null){
            upgradeArea[currentArea].SetActive(true);
            if(upgradeArea[6] == null){
                upgradeArea2[0].SetActive(true);
                upgradeArea2[1].SetActive(true);
            }
            if(upgradeArea[7] == null){
                upgradeArea2[2].SetActive(true);
                upgradeArea2[3].SetActive(true);
            }
        } else {
            currentArea++;
        }
    }
}
