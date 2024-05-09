using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoneyArea : MonoBehaviour
{
    public GameObject money;
    private float x;
    private float y;
    
    public void createMoney(){
        x = Random.Range(gameObject.transform.position.x - 1, gameObject.transform.position.x + 1);
        y = Random.Range(gameObject.transform.position.y - 1, gameObject.transform.position.y + 1);
        Instantiate(money, new Vector3(x, y, -1), Quaternion.identity);
    }
}
