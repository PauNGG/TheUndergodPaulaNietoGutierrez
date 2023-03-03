using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    State state;
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] Image spriteComponent;
    [SerializeField] State startingState; //Es el estado inicial



    // Start is called before the first frame update
    void Start()
    {
        //Estado actual en el start = estado inicial del juego.
        state = startingState;

        //Acceso al componente de texto en el estado actual
        textComponent.text = state.GetStateStory();

        //Acceso al componente de sprite del estado actual.
        spriteComponent.sprite = state.GetStateSprite();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }



    private void ManageState() //Método para manejar el cambio entre estados.
    {
        var nextStates = state.GetNextStates();

        for (int index = 0; index < nextStates.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                state = nextStates[index];
            }
        }
        textComponent.text = state.GetStateStory();
        spriteComponent.sprite = state.GetStateSprite();
    }




    //Método para activar los diálogos



}