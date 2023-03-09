using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    private Rigidbody2D theRB;
    public float speed;

    private void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        theRB.velocity = new Vector2(0, +speed);
        transform.Rotate(0, 0, 1000 * Time.deltaTime);
        Destroy(gameObject, 4f);

    }


}
