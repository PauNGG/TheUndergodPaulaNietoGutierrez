using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoarArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().isScared = true;
            Debug.Log("Has rugido al Enemigo");
        }
    }

    private void Update()
    {
        Invoke("DisableRoarArea", 0.5f);
    }

    private void DisableRoarArea()
    {
        this.gameObject.SetActive(false);
    }
}
