using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewArea : MonoBehaviour
{
    public GameObject newObject;
    public GameObject money;
    public TextMeshProUGUI textCost;
    public int cost;
    private bool canOpen;
    
    void Start()
    {
        newObject.SetActive(false);
        textCost.text = cost.ToString();
    }

    
    void Update()
    {
        if(money.GetComponent<Money>().currentMoney >= cost){
            canOpen = true;
        } else {
            canOpen = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && canOpen){
            money.GetComponent<Money>().currentMoney -= cost;
            newObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
