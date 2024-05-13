using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StoveController : MonoBehaviour
{
    [Header("-------Menu-------")]
    public GameObject menuStove;
    public GameObject menuCook;
    public GameObject menuFood;
    public GameObject portal;
    public GameObject collected;
    [Header("-------Data-------")]
    public DataFood dataFood;
    private int currentFood;
    [Header("-------Time-------")]
    private float timeStart;
    private float timeStart2;
    private float currentTime;
    private float currentTime2;
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI textTime2;
    private bool isCooking = false;
    private bool isCooking2 = false;
    [Header("-------Image Food-------")]
    public Image imageFood1;
    public Image imageFood2;
    public Image[] foodImage;
    public GameObject icon;
    public GameObject icon2;
    private bool is1;
    private bool canUseCooking2 = false;
    [Header("-------Stove Object-------")]
    public GameObject[] stoveObject;
    private int turnOnIcon2 = 1;
    
    void Start()
    {
        menuCook.SetActive(false);
        menuFood.SetActive(false);
    }

    
    void Update()
    {
        if(currentTime > 0){
            currentTime -= Time.deltaTime;
            textTime.text = Mathf.RoundToInt(currentTime) + "s";
        }
        if(currentTime2 > 0){
            currentTime2 -= Time.deltaTime;
            textTime2.text = Mathf.RoundToInt(currentTime2) + "s";
        }
        ActiveStove();
        turnOnCooking2();
    }

    public void ExitButton(){
        menuCook.SetActive(false);
        menuFood.SetActive(false);
    }
    public void cookingFood1(){
        is1 = true;
        if(imageFood1.gameObject.activeSelf && currentTime <= 0){
            imageFood1.gameObject.SetActive(false);
            textTime.gameObject.SetActive(false);
            icon.SetActive(true);
            getFood();
        }
        else if(!imageFood1.gameObject.activeSelf && currentTime <= 0){
            icon.SetActive(false);
            menuCook.SetActive(false);
            menuFood.SetActive(true);
            isCooking = true;
        }
        
    }

    public void cookingFood2(){
        if(canUseCooking2){
            is1 = false;
            if(imageFood2.gameObject.activeSelf && currentTime2 <= 0){
                imageFood2.gameObject.SetActive(false);
                textTime2.gameObject.SetActive(false);
                icon2.SetActive(true);
                getFood();
            }
            else if(!imageFood2.gameObject.activeSelf && currentTime2 <= 0){
                icon2.SetActive(false);
                menuCook.SetActive(false);
                menuFood.SetActive(true);
                isCooking2 = true;
            }
        }
        
    }
    private void getFood(){

        int currentNumberOfFood = collected.GetComponent<Collected>().currentNumberOfFood;
        int capacity = collected.GetComponent<Collected>().capacity;
        if(is1){
            collected.GetComponent<Collected>().imageFoodCollected[currentNumberOfFood].sprite = imageFood1.sprite;
        } else {
            collected.GetComponent<Collected>().imageFoodCollected[currentNumberOfFood].sprite = imageFood2.sprite;
        }

        if(collected.GetComponent<Collected>().currentNumberOfFood < capacity){
            collected.GetComponent<Collected>().currentNumberOfFood++;
        }
    }
    public void food1(){
        currentFood = 0;
        foodController();
    }

    public void food2(){
        currentFood = 1;
        foodController();
    }

    public void food3(){
        currentFood = 2;
        foodController();
    }

    public void food4(){
        currentFood = 3;
        foodController();
    }

    public void food5(){
        currentFood = 4;
        foodController();
    }

    public void food6(){
        currentFood = 5;
        foodController();
    }

    private void foodController(){
        menuCook.SetActive(true);
        menuFood.SetActive(false);
        checkCookingFood();
    }

    private void checkCookingFood(){
        if(isCooking){
            imageFood1.gameObject.SetActive(true);
            textTime.gameObject.SetActive(true);

            //image
            imageFood1.sprite = foodImage[currentFood].sprite;

            //count down time
            timeStart = dataFood.food[currentFood].time;
            currentTime = (timeStart / menuStove.GetComponent<MenuPlayer>().currentSpeed);
            textTime.text = Mathf.RoundToInt(currentTime) + "s";
            isCooking = false;
        } else if(isCooking2){
            imageFood2.gameObject.SetActive(true);
            textTime2.gameObject.SetActive(true);

            //image
            imageFood2.sprite = foodImage[currentFood].sprite;

            //count down time
            timeStart2 = dataFood.food[currentFood].time;
            currentTime2 = (timeStart2/ menuStove.GetComponent<MenuPlayer>().currentSpeed);
            textTime2.text = Mathf.RoundToInt(currentTime2) + "s";
            isCooking2 = false;
        }
    }

    private void turnOnCooking2(){
        if(menuStove.GetComponent<MenuPlayer>().currentCapacity == 2){
            canUseCooking2 = true;
            if(turnOnIcon2 == 1){
                icon2.gameObject.SetActive(true);
                turnOnIcon2--;
            }
            
        } else {
            imageFood2.gameObject.SetActive(false);
            icon2.gameObject.SetActive(false);
            canUseCooking2 = false;
        }
    }

    private void ActiveStove(){
        int currentQuantity = (int) menuStove.GetComponent<MenuPlayer>().currentProfitsUp;
        stoveObject[currentQuantity - 1].SetActive(true);
    }
}
