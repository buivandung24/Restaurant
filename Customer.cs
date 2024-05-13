
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Customer : MonoBehaviour
{
    public GameObject queueObject;
    private int queueNumber = 10;
    public GameObject[] queuePosition;
    public GameObject[] customer;
    public GameObject[] customerInScene = new GameObject[10];
    private bool isChange = false;
    private int speed = 3;

    void Start()
    {
        for(int i = 0; i < queueNumber; i++){
            int randomCustomer = Random.Range(0, 3);
            queuePosition[i].transform.position = new Vector3(queueObject.transform.position.x + (1.5f * i), queueObject.transform.position.y + 0.25f, -0.1f);
            customerInScene[i] = Instantiate(customer[randomCustomer], queuePosition[i].transform.position, Quaternion.identity);
        }
    }

    
    void Update()
    {
        checkCustomer();
    }

    private void checkCustomer(){
        for(int i = 0; i < queueNumber; i++){
            if(customerInScene[i].transform.position != queuePosition[i].transform.position){
                if(customerInScene[i+1] != null){
                    customerInScene[i+1].transform.position = queuePosition[i].transform.position;
                }
                customerInScene[i] = customerInScene[i+1];
                isChange = true;
            }
        }
        if(isChange){
            GameObject newCustomer = Instantiate(customer[Random.Range(0, 3)], queuePosition[queueNumber - 1].transform.position, Quaternion.identity);
            customerInScene[queueNumber - 1] = newCustomer;
            isChange = false;
        }
    }
}
