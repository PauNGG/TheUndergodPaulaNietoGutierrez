using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoarArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spear")
        {
            collision.gameObject.GetComponent<SpearEnemyController>().isScared = true;

            if (collision.gameObject.GetComponent<SpearEnemyController>().isFacingLeft == true)
            {
                collision.gameObject.GetComponent<SpearEnemyController>().isFacingLeft = false;
            }
            else if (collision.gameObject.GetComponent<SpearEnemyController>().isFacingLeft == false)
            {
                collision.gameObject.GetComponent<SpearEnemyController>().isFacingLeft = true;
            }

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
        PlayerController.sharedInstance.roarTrue = false;
    }
}
