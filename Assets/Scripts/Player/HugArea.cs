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
            collision.gameObject.GetComponent<EnemyController>().canTalk = true;
        }

        else if (collision.gameObject.tag == "Flying")
        {
            Debug.Log("Has dado un abrazo a un volador");
            Destroy(collision.gameObject.GetComponent<DamagePlayer>());
            collision.gameObject.GetComponent<FlyingEnemyController>().distanceToAttackPlayer = 0;
            collision.gameObject.GetComponent<FlyingEnemyController>().canTalk = true;
        }

        else if (collision.gameObject.tag == "Spear")
        {
            collision.gameObject.GetComponent<SpearEnemyController>().canTalk = true;
            Destroy(collision.gameObject.GetComponent<DamagePlayer>());
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
