using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    //Referencias a los objetos del diálogo

    public TextMeshProUGUI dialogueText;
    public Image dialoguePortrait;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Funciona");
            dialogueText.enabled = true;
            dialoguePortrait.enabled = true;
        }

    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //Si es el jugador el que ha entrado en la zona de acción
    //    if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
    //    {
    //        Debug.Log("Funciona");
    //        dialogueText.enabled = true;
    //        dialoguePortrait.enabled = true;
    //    }
    //}
}
