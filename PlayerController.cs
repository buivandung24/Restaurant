using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator ani;
    public Joystick joystick;
    public float speed;
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
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
}
