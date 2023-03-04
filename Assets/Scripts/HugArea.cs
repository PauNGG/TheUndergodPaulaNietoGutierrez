using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Has dado un abrazo");
            Destroy(collision.gameObject.GetComponent<DamagePlayer>());
            collision.gameObject.GetComponent<EnemyController>().moveSpeed = 0f;
            collision.gameObject.GetComponent<EnemyController>().npc = true;
        }
    }

    private void Update()
    {
        Invoke("DisableHugArea", 0.5f);
    }

    private void DisableHugArea()
    {
        this.gameObject.SetActive(false);
    }
}
