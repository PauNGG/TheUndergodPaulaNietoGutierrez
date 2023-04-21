using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    //Variable de selección de tiempo para destruir el objeto
    public float lifeTime;
    public bool isBreaking;
    private Rigidbody2D theRB;
    public float speed;

    private void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }
        // Update is called once per frame
        void Update()
    {
        if (isBreaking)
        {
                theRB.velocity = new Vector2(0+speed, 0);
                Destroy(gameObject, lifeTime);
            }
        else
        {
            //Destruirá el objeto pasado un tiempo dado
            Destroy(gameObject, lifeTime);
        }

    }
}
