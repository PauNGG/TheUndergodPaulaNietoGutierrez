using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public Image dialoguePortrait;
    public TextMeshProUGUI dialogueText;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Funciona");
            dialogueText.enabled = true;
            dialoguePortrait.enabled = true;
        }
    }
}
