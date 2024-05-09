using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator ani;
    public Joystick joystick;
    public GameObject money;
    public float speed = 3;
    Rigidbody2D rb;
    public GameObject menuPlayer;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        speed = menuPlayer.GetComponent<MenuPlayer>().currentSpeed;
        if(joystick.joystickVec.y != 0){
            rb.velocity = new Vector2(joystick.joystickVec.x * speed, joystick.joystickVec.y * speed);
            ani.SetFloat("LastHorizontal", joystick.joystickVec.x);
            ani.SetFloat("LastVertical", joystick.joystickVec.y);
        } else {
            rb.velocity = Vector2.zero;
        }
        ani.SetFloat("Horizontal", joystick.joystickVec.x);
        ani.SetFloat("Vertical", joystick.joystickVec.y);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Money")){
            Destroy(other.gameObject);
            money.GetComponent<Money>().currentMoney += (10 * menuPlayer.GetComponent<MenuPlayer>().currentProfitsUp);
        }
    }
}
