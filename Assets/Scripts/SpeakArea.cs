using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            Debug.Log("Has hablado con el NPC");
        }
    }

    private void Update()
    {
        Invoke("DisableSpeakArea", 0.5f);
    }

    private void DisableSpeakArea()
    {
        this.gameObject.SetActive(false);
    }
}
