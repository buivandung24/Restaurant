using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collected : MonoBehaviour
{
    public GameObject menuPlayer;
    public GameObject stoveController;
    public Image[] imageFoodCollected;
    public int capacity;
    public int currentNumberOfFood = 0;
    void Start()
    {
        
    }

    void Update()
    {
        capacity = menuPlayer.GetComponent<MenuPlayer>().currentCapacity - 1;
        addImageFood();
    }

    private void addImageFood(){
        imageFoodCollected[capacity].gameObject.SetActive(true);
    }
}
