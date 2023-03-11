using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakArea : MonoBehaviour
{
    public GameObject backupSprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Breakable")
        {
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        Invoke("DisableBreakArea", 1f);
    }

    private void DisableBreakArea()
    {
        this.gameObject.SetActive(false);
    }
}