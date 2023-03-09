using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Para poder trabajar con elementos de la UI
using TMPro;

public class UIController : MonoBehaviour
{
    public Image HealthBar;
    public Sprite FullBar, HalfBar, LowBar, EmptyBar;
    public TextMeshProUGUI betrootCountText;
    public Image betrootCountImage;

    public static UIController sharedInstance;
    
    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Inicializar el contador de gemas
        UpdateBetrootCount();
    }

    //Método para actualizar la vida en la UI
    public void UpdateHealthDisplay()
    {
        //Dependiendo del valor de la vida actual del jugador
        switch (PlayerHealthController.sharedInstance.currentHealth)
        {
            //En el caso en el que la vida actual valga 3
            case 3:
                HealthBar.sprite = FullBar;
                //Cerramos el caso
                break;
            //En el caso en el que la vida actual valga 2
            case 2:
                HealthBar.sprite = HalfBar;
                //Cerramos el caso
                break;
            //En el caso en el que la vida actual valga 1
            case 1:
                HealthBar.sprite = LowBar;
                //Cerramos el caso
                break;
            //En el caso en el que la vida actual valga 0
            case 0:
                HealthBar.sprite = EmptyBar;
                //Cerramos el caso
                break;
            //En el caso por defecto, el jugador estará muerto
            default:
                HealthBar.sprite = EmptyBar;
                //Cerramos el caso
                break;
        }
    }

    //Método para actualizar el contador de gemas
    public void UpdateBetrootCount()
    {
        //Actualizar el número de gemas recogidas                                  /////////////NOMBRE DE LA VARIABLE
        betrootCountText.text = LevelManager.sharedInstance.betrootCollected.ToString();//Cast -> convertimos el número entero en texto para que pueda ser representado en la UI
    }
}
