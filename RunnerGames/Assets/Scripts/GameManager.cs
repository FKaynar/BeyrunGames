using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject GameOverPanel;
    public GameObject ScorePanel;

    public AudioSource AudioSoruce;

    


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {


        GameOverPanel.SetActive(false);
        ScorePanel.SetActive(true);
        AudioSoruce = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Games");
        AudioSoruce.Play();
    }

    public void OnApplicationQuit()
    {
        Debug.Log("This application on exit");
    }


}
