using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CustomerController : MonoBehaviour
{
    public Image[] imageFood;
    private GameObject player;
    public Image orderFoodBG;
    public Image imageOrderFood;
    public Image imageFoodCollected;
    private GameObject chair;
    public bool hasFood = false;
    private float speed = 0.1f;
    private GameObject moneyArea;
    private GameObject chairObject;
    private GameObject table;
    private bool isCheckChairCanSit = true;

    void Start()
    {
        OrderFood();
        player = GameObject.FindWithTag("Player");
        chair = GameObject.FindWithTag("Table");
        moneyArea = GameObject.FindWithTag("Money Area");
    }

    // Update is called once per frame
    void Update()
    {
        goToTheChair();
    }

    private void OrderFood(){
        imageOrderFood.sprite = imageFood[Random.Range(0, imageFood.Length)].sprite;
    }
    public void IsCorrectFood(){
        for(int i = 0; i<3; i++){
            moneyArea.GetComponent<MoneyArea>().createMoney();
        }
        imageFoodCollected.sprite = imageOrderFood.sprite;
        hasFood = true;
        imageOrderFood.sprite = null;
        Destroy(imageOrderFood);
        Destroy(orderFoodBG);
    }

    private void goToTheChair(){
        if(hasFood){
            findTheChair();
            if(!isCheckChairCanSit){
                Vector3 moveVector = chairObject.transform.position - gameObject.transform.position;
                gameObject.transform.Translate(moveVector * speed * Time.deltaTime);
                float distance = Vector3.Distance(gameObject.transform.position, chairObject.transform.position);
                if (distance < 0.5)
                {
                    gameObject.transform.Translate(Vector3.zero);
                    hasFood = false;
                    StartCoroutine(eat());
                }
            }   
        }
    }

    private void findTheChair(){
        if(isCheckChairCanSit){
            chair.GetComponent<TableController>().checkChairCanSit();
            if(chair.GetComponent<TableController>().chairCanSit != null){
                chairObject = chair.GetComponent<TableController>().chairCanSit;
                table = chair.GetComponent<TableController>().table;
                gameObject.transform.SetParent(table.transform);
                isCheckChairCanSit = false;
            }
        }   
    }

    IEnumerator eat(){
        yield return new WaitForSeconds(Random.Range(5, 10));
        for(int i = 0; i<3; i++){
            moneyArea.GetComponent<MoneyArea>().createMoney();
        }
        Destroy(gameObject);
    }
}
