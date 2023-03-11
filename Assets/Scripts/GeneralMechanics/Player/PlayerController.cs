using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    private bool isGrounded;
    public LayerMask whatIsGround;

    private Rigidbody2D theRB;
    private SpriteRenderer theSR;
    public Transform groundCheckPoint;

    public float knockBackLength, knockBackForce; //Valor que tendr� el contador de KnockBack, y la fuerza de KnockBack
    private float knockBackCounter; //Contador de KnockBack



    //Variables para el abrazo y el rugido.
    public GameObject hugArea;
    public GameObject speakArea;
    public GameObject roarArea;
    public GameObject breakArea;

    public GameObject backupBreakSprite;
    public GameObject backupJumpSprite;


    private Animator anim;
    public bool isLeft;

//SINGLETON//
    public static PlayerController sharedInstance;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    void Start()
    {
        //INICIALIZACI�N DE VARIABLES//
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();



    }



    void Update()
    {

        //INPUTS PARA SABER SI ABRAZA

        if (Input.GetKeyDown(KeyCode.E))
        {
            hugArea.SetActive(true);
            speakArea.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            roarArea.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(backupBreakSprite, theRB.position, Quaternion.identity);
            breakArea.SetActive(true);
        }


        //Si el contador de KnockBack se ha vaciado, el jugador recupera el control del movimiento
        if (knockBackCounter <= 0)
        {
            //El jugador se mueve 8 en X, y la velocidad que ya tuviera en Y
            theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

            //La variable isGrounded se har� true siempre que el c�rculo f�sico que hemos creado detecte suelo
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);//OverlapCircle(punto donde se genera el c�rculo, radio del c�rculo, layer a detectar)


            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    //El jugador salta, manteniendo su velocidad en X, y aplicamos la fuerza de salto
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                }
            }

            //Girar el sprite del jugador seg�n su direcci�n de movimiento
            if (theRB.velocity.x < 0)
            {
                //No cambiamos la direcci�n del sprite
                theSR.flipX = true;
                //El jugador mira a la izquierda
                isLeft = false;
            }
            //Si el jugador por el contrario se est� moviendo hacia la derecha
            else if (theRB.velocity.x > 0)
            {
                //Cambiamos la direcci�n del sprite
                theSR.flipX = false;
                //El jugador mira a la derecha
                isLeft = true;
            }
        }
        //Si el contador de KnockBack todav�a no est� vac�o
        else
        {
            //Hacemos decrecer el contador en 1 cada segundo
            knockBackCounter -= Time.deltaTime;
            //Si el jugador mira a la izquierda
            if (!theSR.flipX)
            {
                //Aplicamos un peque�o empuje a la derecha
                theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
            }
            //Si el jugador mira a la derecha
            else
            {
                //Aplicamos un peque�o empuje a la izquierda
                theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
            }
        }
    }

    //M�todo para gestionar el KnockBack producido al jugador al hacerse da�o
    public void KnockBack()
    {
        //Inicializar el contador de KnockBack
        knockBackCounter = knockBackLength;
        //Paralizamos en X al jugador y hacemos que salte en Y
        theRB.velocity = new Vector2(0f, knockBackForce);

        //Activamos el trigger del animator
        //anim.SetTrigger("hurt");
    }
}
