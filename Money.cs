using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public TextMeshProUGUI textMoney;
    public float currentMoney;
    void Start()
    {
        
    }

    
    void Update()
    {
        textMoney.text = "x " + currentMoney;
    }
}
