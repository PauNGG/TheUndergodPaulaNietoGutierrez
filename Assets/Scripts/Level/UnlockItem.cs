using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockItem : MonoBehaviour
{
    //Referencia al panel de informaci�n
    public GameObject infoPanel;


    // Update is called once per frame
    void Update()
    {
        //Si pulsamos el bot�n E y el jugador puede interactuar
        if (Input.GetKeyDown(KeyCode.E) && HumanPlayerController.sharedInstance.canInteract)
        {
            HumanPlayerController.sharedInstance.itemCount = HumanPlayerController.sharedInstance.itemCount++;
            SceneManager.LoadScene("Overworld");
            Destroy(this.gameObject);



        }
    }

    //M�todo para conocer cuando un objeto entra en la zona de Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si es el jugador el que entra en la zona del interruptor
        if (collision.CompareTag("Player"))
        {
            //Mostramos el panel de informaci�n
            infoPanel.SetActive(true);
            //Permitimos al jugador que pueda interactuar con el objeto
            HumanPlayerController.sharedInstance.canInteract = true;
        }
    }

    //M�todo para conocer cuando un objeto sale de la zona de Trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Ocultamos el panel de informaci�n
        infoPanel.SetActive(false);
        //No permitimos al jugador que pueda interactuar con el objeto
        HumanPlayerController.sharedInstance.canInteract = false;
    }
}
