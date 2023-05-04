using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject.GetComponent<DamagePlayer>());
            collision.gameObject.GetComponent<EnemyController>().moveSpeed = 0f;
            collision.gameObject.GetComponent<EnemyController>().canTalk = true;
        }

        else if (collision.gameObject.tag == "Flying")
        {
            Destroy(collision.gameObject.GetComponent<DamagePlayer>());
            collision.gameObject.GetComponent<FlyingEnemyController>().distanceToAttackPlayer = 0;
            collision.gameObject.GetComponent<FlyingEnemyController>().canTalk = true;
        }

        else if (collision.gameObject.tag == "Spear")
        {
            collision.gameObject.GetComponent<SpearEnemyController>().canTalk = true;
            Destroy(collision.gameObject.GetComponent<DamagePlayer>());
        }

        else if (collision.gameObject.tag == "Filbrugh")
        {
            Destroy(collision.gameObject.GetComponent<DamagePlayer>());
            Destroy(collision.gameObject.GetComponent<Filbrugh>());
            collision.gameObject.GetComponent<DialogueActivator>().enabled = true;

        }
        else if (collision.gameObject.tag == "Bomber")
        {
            Destroy(collision.gameObject.GetComponent<DamagePlayer>());
            //Destroy(collision.gameObject.GetComponent<BombEnemyController>());
            collision.gameObject.GetComponent<BombEnemyController>().canTalk = true;
        }
    }
    private void Start()
    {
        PlayerController.sharedInstance.hugTrue = true;
    }

    private void Update()
    {
        Invoke("DisableHugArea", 0.5f);
    }

    private void DisableHugArea()
    {
        PlayerController.sharedInstance.hugTrue = false;
        this.gameObject.SetActive(false);
    }
}
