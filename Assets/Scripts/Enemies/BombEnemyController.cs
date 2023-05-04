using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombEnemyController : MonoBehaviour
{
    public Sprite hidden;
    public Sprite notHidden;
    public GameObject Hitbox;
    public GameObject Bomb;

    private Rigidbody2D theRB;
    //Referencia al SpriteRenderer del enemigo
    private SpriteRenderer theSR;

    //Distancia del jugador para ser atacado, velocidad de persecución
    public float distanceToAttackPlayer;

    //Objetivo del enemigo
    private Vector3 attackTarget;

    //Tiempo entre ataques
    public float waitAfterAttack;
    //Contador de tiempo entre ataques
    private float attackCounter;


    public bool isAttacking;
    public bool canTalk;

    void Start()
    {
        //Inicializamos el Rigidbody del enemigo
        theRB = GetComponent<Rigidbody2D>();
        //Inicializamos el SpriteRenderer del enemigo teniendo en cuenta que está en el GO hijo
        theSR = GetComponentInChildren<SpriteRenderer>();
        //Inicializamos el Animator del enemigo
        //anim = GetComponent<Animator>();

    }

    private void Update()
    {

        //Lo que sucede cuando ataca

        //if (isAttacking)
        //{
        //    Hitbox.SetActive(true);
        //    theSR.sprite = notHidden;
        //    //Instantiate(Bomb, this.transform.position, Quaternion.identity);
        //}
        //else
        //{
        //    Hitbox.SetActive(false);
        //    theSR.sprite = hidden;
        //}


        if (canTalk == true)
        {
            gameObject.GetComponent<DialogueActivator>().enabled = true;
        }

        else
        {
            gameObject.GetComponent<DialogueActivator>().enabled = false;
        }

        //Si el contador de tiempo entre ataques aún está lleno
        //if (attackCounter > 0)
        //{
        //    //Hacemos que se vacíe el contador
        //    //attackCounter -= Time.deltaTime;
        //    isAttacking = false;
        //}
        ////Si el contador de tiempo entre ataques ya está vacío
        //else
        //{
        //    //Si la distancia entre el jugador y el enemigo es la suficiente grande
        //    if (Vector3.Distance(transform.position, PlayerController.sharedInstance.transform.position) > distanceToAttackPlayer)
        //    {

        //        //Reiniciamos el objetivo del ataque
        //        attackTarget = Vector3.zero;

        //    }
        //    //Si por el contrario el jugador está lo suficientemente cerca como para ser atacado
        //    else
        //    {
        //        isAttacking = true;
        //        //Inicializamos el contador de tiempo entre ataques
        //        //attackCounter = waitAfterAttack;
        //        //Reiniciamos el objetivo del ataque
        //        attackTarget = Vector3.zero;
        //    }
        //}
    }
}
