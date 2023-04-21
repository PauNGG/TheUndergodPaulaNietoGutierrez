using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProyectile : MonoBehaviour
{
    private Rigidbody2D theRB;
    public float speed;

    private void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        this.gameObject.SetActive(true);
    }

    private void Update()
    {
        theRB.velocity = new Vector2(speed, 0);
        Destroy(gameObject, 5f);

    }
}
