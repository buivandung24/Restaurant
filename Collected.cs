using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collected : MonoBehaviour
{
    public GameObject menuPlayer;
    public GameObject stoveController;
    public GameObject portalCounter;
    public GameObject customer;
    private GameObject customerController;
    public Image[] imageFoodCollected;
    public int capacity;
    public int currentNumberOfFood = 0;
    public Image imageNone;

    void Update()
    {
        capacity = menuPlayer.GetComponent<MenuPlayer>().currentCapacity - 1;
        addImageFood();
        customerController = customer.GetComponent<Customer>().customerInScene[0];
        resetImageFood();
    }

    private void addImageFood(){
        imageFoodCollected[capacity].gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject == portalCounter){
            for(int i = 0; i < imageFoodCollected.Length; i++){
                if(customerController.GetComponent<CustomerController>().imageOrderFood.sprite == imageFoodCollected[i].sprite){
                    imageFoodCollected[i].sprite = imageNone.sprite;
                    customerController.GetComponent<CustomerController>().IsCorrectFood();
                }
            }
        }
    }

    private void resetImageFood(){
        for(int i = 0; i < imageFoodCollected.Length; i++){
            if(imageFoodCollected[i].sprite == imageNone.sprite && imageFoodCollected[i+1].sprite != imageNone.sprite){
                imageFoodCollected[i].sprite = imageFoodCollected[i+1].sprite;
                imageFoodCollected[i+1].sprite = imageNone.sprite;
                currentNumberOfFood--;
            }
        }
    }
}
