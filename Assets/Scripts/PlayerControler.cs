using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControler : MonoBehaviour
{
    float speed = 4;
    float rotationSpeed = 0.8f;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        if (!PlayerManager.levelStarted)
             return;

        if (PlayerManager.gameOver)
            return;
        transform.Translate(0, 0, speed * Time.deltaTime);
        if(Touchscreen.current != null)
        {
            Vector2 delta = Touchscreen.current.primaryTouch.delta.ReadValue();
            transform.Rotate(0, 0, delta.x * rotationSpeed);
        }


        
    }
}
