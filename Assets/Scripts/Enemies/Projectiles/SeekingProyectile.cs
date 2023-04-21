using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingProyectile : MonoBehaviour
{
    public float speed;

    //Objetivo del enemigo
    private Vector3 attackTarget;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2f);
    }

    private void Update()
    {
        attackTarget = PlayerController.sharedInstance.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, attackTarget, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}

