using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Tiempo antes de respawnear
    public float waitToRespawn;

    //Variable para el contador de gemas
    public int betrootCollected;

    //Hacemos el Singleton de este script
    public static LevelManager sharedInstance;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    //Método para respawnear al jugador cuando muere
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCo());
    }

    //Corrutina para respawnear al jugador
    public IEnumerator RespawnPlayerCo()
    {
        if (PlayerHealthController.sharedInstance.playerIsHuman == false)
        {
            //Desactivamos al jugador
            PlayerController.sharedInstance.gameObject.SetActive(false);
            //Llamamos al sonido de muerte
            //AudioManager.sharedInstance.PlaySFX(8);
            //Esperamos un tiempo determinado
            yield return new WaitForSeconds(waitToRespawn);
            //Llamamos al método que hace fundido a negro
            UIController.sharedInstance.FadeToBlack();
            //Esperamos un tiempo determinado
            yield return new WaitForSeconds(waitToRespawn);
            //Llamamos al método que hace fundido a transparente
            UIController.sharedInstance.FadeFromBlack();
            //Activamos de nuevo al jugador
            PlayerController.sharedInstance.gameObject.SetActive(true);
            //Lo ponemos en la posición de respawn
            PlayerController.sharedInstance.transform.position = CheckpointController.sharedInstance.spawnPoint;
            //Ponemos la vida del jugador al máximo
            PlayerHealthController.sharedInstance.currentHealth = PlayerHealthController.sharedInstance.maxHealth;
            //Actualizamos la UI
            UIController.sharedInstance.UpdateHealthDisplay();
        }
        else
        {
            //Desactivamos al jugador
            HumanPlayerController.sharedInstance.gameObject.SetActive(false);
            //Llamamos al sonido de muerte
            //AudioManager.sharedInstance.PlaySFX(8);
            //Esperamos un tiempo determinado
            yield return new WaitForSeconds(waitToRespawn);
            //Llamamos al método que hace fundido a negro
            UIController.sharedInstance.FadeToBlack();
            //Esperamos un tiempo determinado
            yield return new WaitForSeconds(waitToRespawn);
            //Llamamos al método que hace fundido a transparente
            UIController.sharedInstance.FadeFromBlack();
            //Activamos de nuevo al jugador
            HumanPlayerController.sharedInstance.gameObject.SetActive(true);
            //Lo ponemos en la posición de respawn
            HumanPlayerController.sharedInstance.transform.position = CheckpointController.sharedInstance.spawnPoint;
            //Ponemos la vida del jugador al máximo
            PlayerHealthController.sharedInstance.currentHealth = PlayerHealthController.sharedInstance.maxHealth;
            //Actualizamos la UI
            UIController.sharedInstance.UpdateHealthDisplay();
        }



    }
}

