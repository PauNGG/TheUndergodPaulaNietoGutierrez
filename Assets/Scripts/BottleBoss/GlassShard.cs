using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassShard : MonoBehaviour
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
        theRB.velocity = new Vector2(0, -speed);
        Destroy(gameObject, 2f);

    }


}