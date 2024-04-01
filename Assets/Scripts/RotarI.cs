using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotarI : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!PlayerManager.levelStarted)
            return;

        if (PlayerManager.gameOver)
            return;
        if (Touchscreen.current != null)
        {
            transform.Rotate(new Vector3(0f, 0f, 360f) * Time.deltaTime);

        }
    }
}
