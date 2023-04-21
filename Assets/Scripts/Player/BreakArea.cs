using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Breakable")
        {
            Destroy(collision.gameObject, 0.35f);
        }
    }
    private void Start()
    {

    }
    private void Update()
    {
        Invoke("DisableBreakArea", 0.5f);
    }

    private void DisableBreakArea()
    {
        this.gameObject.SetActive(false);
    }
}