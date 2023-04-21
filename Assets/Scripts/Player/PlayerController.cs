using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private bool isGrounded;
    public LayerMask whatIsGround;

    public bool canMove = true;

    public Rigidbody2D theRB;
    private SpriteRenderer theSR;
    public Transform groundCheckPoint;

    public float knockBackLength, knockBackForce; //Valor que tendrá el contador de KnockBack, y la fuerza de KnockBack
    private float knockBackCounter; //Contador de KnockBack

    //Variables para el abrazo y el rugido.
    public GameObject hugArea;
    public GameObject roarArea;
    public GameObject breakArea;
    public GameObject jumpArea;

    public GameObject pieceSpawner;

    //Nombre del área a la que vamos
    public string areaTransitionName;

    private Animator anim;
    public bool isLeft;



    public Sprite BhalgroghPortrait;

//SINGLETON//
    public static PlayerController sharedInstance;

    private void Awake()
    {
        //Inicializamos el Singleton si está vacío
        if (sharedInstance == null) sharedInstance = this;
        //Si no lo está
        else
        {
            //Si hay otro objeto que no sea este, es destruido (evitamos la duplicación del jugador en el cambio entre escenas)
            if (sharedInstance != this) Destroy(gameObject);
        }
        //Hace que el jugador no se destruido al cambiar entre escenas
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //INICIALIZACIÓN DE VARIABLES//
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();


    }



    void Update()
    {
        //DETENER EL MOVIMIENTO

        if (canMove == true)
        {
            moveSpeed = 10;
            jumpForce = 30;
        }
        else
        {
            moveSpeed = 0;
            jumpForce = 0;
        }

        //INPUTS PARA SABER SI ABRAZA

        if (Input.GetButtonDown("Fire1"))
        {
            hugArea.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            roarArea.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            breakArea.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            jumpArea.SetActive(true);
        }

        //Si el contador de KnockBack se ha vaciado, el jugador recupera el control del movimiento
        if (knockBackCounter <= 0)
        {
            //El jugador se mueve 8 en X, y la velocidad que ya tuviera en Y
            theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

            //La variable isGrounded se hará true siempre que el círculo físico que hemos creado detecte suelo
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);//OverlapCircle(punto donde se genera el círculo, radio del círculo, layer a detectar)


            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    //El jugador salta, manteniendo su velocidad en X, y aplicamos la fuerza de salto
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                }
            }

            //Girar el sprite del jugador según su dirección de movimiento
            if (theRB.velocity.x < 0)
            {
                //No cambiamos la dirección del sprite
                theSR.flipX = true;
                //El jugador mira a la izquierda
                isLeft = false;
            }
            //Si el jugador por el contrario se está moviendo hacia la derecha
            else if (theRB.velocity.x > 0)
            {
                //Cambiamos la dirección del sprite
                theSR.flipX = false;
                //El jugador mira a la derecha
                isLeft = true;
            }
        }
        //Si el contador de KnockBack todavía no está vacío
        else
        {
            //Hacemos decrecer el contador en 1 cada segundo
            knockBackCounter -= Time.deltaTime;
            //Si el jugador mira a la izquierda
            if (!theSR.flipX)
            {
                //Aplicamos un pequeño empuje a la derecha
                theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
            }
            //Si el jugador mira a la derecha
            else
            {
                //Aplicamos un pequeño empuje a la izquierda
                theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
            }
        }
    }

    //Método para gestionar el KnockBack producido al jugador al hacerse daño
    public void KnockBack()
    {
        //Inicializar el contador de KnockBack
        knockBackCounter = knockBackLength;
        //Paralizamos en X al jugador y hacemos que salte en Y
        theRB.velocity = new Vector2(0f, knockBackForce);

        //Activamos el trigger del animator
        //anim.SetTrigger("hurt");
    }

    //Método para conocer cuando un objeto entra entra en colisión con el jugador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si el que colisiona contra el jugador es una plataforma
        if (collision.gameObject.tag == "Platform")
        {
            //El jugador pasa a ser hijo de la plataforma
            transform.parent = collision.transform;
        }
    }

    //Método para conocer cuando dejamos de colisionar contra un objeto
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Si el objeto con el que dejamos de colisionar es una plataforma
        if (collision.gameObject.tag == "Platform")
        {
            //El jugador deja de tener padre
            transform.parent = null;
        }
    }
}
