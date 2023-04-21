using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpArea : MonoBehaviour
{
    public float chanclaJumpForce;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Chancla")
        {
            Debug.Log("Detectado");
            PlayerController.sharedInstance.theRB.velocity = new Vector2(PlayerController.sharedInstance.theRB.velocity.x, chanclaJumpForce);
        }
    }

    private void Update()
    {
        Invoke("DisableJumpArea", 0.5f);
    }

    private void DisableJumpArea()
    {
        this.gameObject.SetActive(false);
    }
}