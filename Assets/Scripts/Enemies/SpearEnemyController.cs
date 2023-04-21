using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearEnemyController : MonoBehaviour
{
    public bool isFacingLeft;
    public bool isScared = false;
    public bool canTalk;
    public GameObject SpearHitBox;

    //Referencia al SpriteRenderer del enemigo
    private SpriteRenderer theSR;



    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos el SpriteRenderer del enemigo teniendo en cuenta que está en el GO hijos
        theSR = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        //EFECTO DEL RUGIDO

        if (isScared == true)
        {
            if (isFacingLeft)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }

        //ACTIVAR EL DIÁLOGO

        if (canTalk == true)
        {
            gameObject.GetComponent<DialogueActivator>().enabled = true;
            Destroy(SpearHitBox);
        }

        else
        {
            gameObject.GetComponent<DialogueActivator>().enabled = false;
        }

        //DIRECCIÓN  A LA QUE MIRA

        if (!isFacingLeft)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
