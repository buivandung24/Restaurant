using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject joystick;
    [Header("-------Menu-------")]
    public GameObject menuPlayer;
    public GameObject menuStove;
    [Header("-------Portal-----")]
    public GameObject portalMenuPlayer;
    public GameObject portalMenuStove;
    
    void Start()
    {
        joystick.SetActive(true);
        menuPlayer.SetActive(false);
        menuStove.SetActive(false);
    }

    void Update() {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject == portalMenuPlayer){
            menuPlayer.SetActive(true);
            joystick.GetComponent<Joystick>().PointerUp();
        }
        if(other.gameObject == portalMenuStove){
            menuStove.SetActive(true);
            joystick.GetComponent<Joystick>().PointerUp();
        }
    }
}
