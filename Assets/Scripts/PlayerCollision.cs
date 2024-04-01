using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            //Game over
            PlayerManager.gameOver = true;
            audioManager.Play("gameOver");
            

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            audioManager.Play("coin");
            PlayerManager.gems++;
            PlayerManager.score++;
            Destroy(other.gameObject);
        }
    }
}
