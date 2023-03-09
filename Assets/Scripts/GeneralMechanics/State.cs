using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]

public class State : ScriptableObject
{
    [TextArea(14, 10)] [SerializeField] string storyText;

    [SerializeField] Sprite storySprite;

    //Array para navegar estados.
    [SerializeField] State[] nextStates;




    public string GetStateStory()
    {
        return storyText;
    }
    public State[] GetNextStates()
    {
        return nextStates;
    }
    public Sprite GetStateSprite()
    {
        return storySprite;
    }
}