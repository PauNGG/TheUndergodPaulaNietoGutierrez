using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //Variable para saber si este objeto es una gema o una cura
    public bool isBetroot;

    //Variable para conocer si un objeto ya ha sido recogido
    public bool isCollected;

    //Referencia al objeto que aparecerá para representar el efecto de coger un item
    //public GameObject pickupEffect;

    //Método para interactuar con los objetos al entrar en su zona
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el jugador es el que entra en la zona del objeto y este no había sido recogido con anterioridad
        if (collision.CompareTag("Player") && !isCollected)
        {
            //Si el objeto en este caso es una gema
            if (isBetroot)
            {
                //Sumo uno al contador de gemas
                LevelManager.sharedInstance.betrootCollected++;
                //El objeto ha sido recogido
                isCollected = true;
                //Actualizamos el contador de gemas
                UIController.sharedInstance.UpdateBetrootCount();
                //Instanciamos el efecto de recoger el item
                //Instantiate(pickupEffect, transform.position, transform.rotation);//Le pasamos el objeto a instanciar, su posición, su rotación

                if (PlayerHealthController.sharedInstance.currentHealth != PlayerHealthController.sharedInstance.maxHealth)
                {
                    //Hacemos el método que cura vida al jugador
                    PlayerHealthController.sharedInstance.HealPlayer();
                    //El objeto ha sido recogido
                    isCollected = true;
                    //Instanciamos el efecto de recoger el item
                    //Instantiate(pickupEffect, transform.position, transform.rotation);//Le pasamos el objeto a instanciar, su posición, su rotación
                    //Destruimos el objeto
                    Destroy(gameObject);
                }

                //Destruimos el Game Object
                Destroy(gameObject);
            }
        }
    }
}
