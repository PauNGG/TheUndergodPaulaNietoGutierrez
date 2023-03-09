using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerTetris : MonoBehaviour
{
    public int points, linecounter;
    public static GameManagerTetris sharedInstance;
    public AudioClip destroy;
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    public void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    public IEnumerator DestroyLine()
    {
        sound.Play();
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator EndGame()
    {
        sound.Play();
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("TetrisScene");
    }
}
