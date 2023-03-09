using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si es el jugador el que ha entrado en la zona
        if (collision.CompareTag("Player"))
        {
            //Ponemos la vida del jugador a 0
            PlayerHealthController.sharedInstance.currentHealth = 0;
            //Actualizamos la UI
            UIController.sharedInstance.UpdateHealthDisplay();
            //Hacemos el respawn
            LevelManager.sharedInstance.RespawnPlayer();
        }
    }
}

