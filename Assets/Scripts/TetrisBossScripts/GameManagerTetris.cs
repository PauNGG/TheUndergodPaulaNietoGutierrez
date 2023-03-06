using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerTetris : MonoBehaviour
{
    public TextMeshProUGUI Score, GameOver, Lines;
    public int points, linecounter;
    public static GameManagerTetris sharedInstance;
    public AudioClip gameover;
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

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator DestroyLine()
    {
        sound.Play();
        yield return new WaitForSeconds(0.0f);
    }

    public IEnumerator EndGame()
    {
        sound.clip = gameover;
        sound.Play();
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("TetrisScene");
    }
}
