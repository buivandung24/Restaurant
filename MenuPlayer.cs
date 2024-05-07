using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuPlayer : MonoBehaviour
{
    [Header("------Data Player-------")]
    public DataPlayer dataPlayer;
    [Header("------Level-------")]
    public TextMeshProUGUI levelSpeedText;
    public TextMeshProUGUI levelCapacityText;
    public TextMeshProUGUI levelProfitsUpText;
    [Header("------Cost-------")]
    public TextMeshProUGUI costSpeedText;
    public TextMeshProUGUI costCapacityText;
    public TextMeshProUGUI costProfitsUpText;

    private int currentLvSpeed = 0;
    private int currentLvCapacity = 0;
    private int currentLvProfitsUp = 0;

    [Header("------Joystick-------")]
    public GameObject joystick;
    [Header("------Current-------")]
    public float currentSpeed;
    public float currentCapacity;
    public float currentProfitsUp;
    
    void Start()
    {
        updateText();
        currentSpeed = dataPlayer.speeds[currentLvSpeed].speed;
        currentCapacity = dataPlayer.capacititys[currentLvCapacity].capacity;
        currentProfitsUp = dataPlayer.profitsUps[currentLvProfitsUp].profitsUp;
    }

    void Update()
    {
        
    }

    private void updateText(){
        levelSpeedText.text = "Level: " + dataPlayer.speeds[currentLvSpeed].lv;
        levelCapacityText.text = "Level: " + dataPlayer.capacititys[currentLvCapacity].lv;
        levelProfitsUpText.text = "Level: " + dataPlayer.profitsUps[currentLvProfitsUp].lv;

        costSpeedText.text = "Upgrade Cost: " + dataPlayer.speeds[currentLvSpeed].cost;
        costCapacityText.text = "Upgrade Cost: " + dataPlayer.capacititys[currentLvCapacity].cost;
        costProfitsUpText.text = "Upgrade Cost: " + dataPlayer.profitsUps[currentLvProfitsUp].cost;
    }


    public void UpgradeSpeed(){
        currentLvSpeed++;
        currentSpeed = dataPlayer.speeds[currentLvSpeed].speed;
        levelSpeedText.text = "Level: " + dataPlayer.speeds[currentLvSpeed].lv;
        costSpeedText.text = "Upgrade Cost: " + dataPlayer.speeds[currentLvSpeed].cost;
        if(dataPlayer.speeds[currentLvSpeed].cost == 0){
            levelSpeedText.text = "Level: MAX";
            costSpeedText.text = "MAX";
        }
        
    }

    public void UpgradeCapacity(){
        currentLvCapacity++;
        currentCapacity = dataPlayer.capacititys[currentLvCapacity].capacity;
        levelCapacityText.text = "Level: " + dataPlayer.capacititys[currentLvCapacity].lv;
        costCapacityText.text = "Upgrade Cost: " + dataPlayer.capacititys[currentLvCapacity].cost;
        if(dataPlayer.capacititys[currentLvCapacity].cost == 0){
            levelCapacityText.text = "Level: MAX";
            costCapacityText.text = "MAX";
        }
    }

    public void UpgradeProfitsUp(){
        currentLvProfitsUp++;
        currentProfitsUp = dataPlayer.profitsUps[currentLvProfitsUp].profitsUp;
        levelProfitsUpText.text = "Level: " + dataPlayer.profitsUps[currentLvProfitsUp].lv;
        costProfitsUpText.text = "Upgrade Cost: " + dataPlayer.profitsUps[currentLvProfitsUp].cost;
        if(dataPlayer.profitsUps[currentLvProfitsUp].cost == 0){
            levelProfitsUpText.text = "Level: MAX";
            costProfitsUpText.text = "MAX";
        }
    }

    public void ExitButton(){
        joystick.SetActive(true);
        gameObject.SetActive(false);
    }
}
