using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //Singleton Pattern
    public static ScoreManager instance;

    public Text ScoreText;

    public float Score = 0;
    public float BestScore = 0;

    private bool isDead = false;

    private void Awake()
    {
        //Singleton Pattern
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isDead)
        {
            return; 
        }

        Score += Time.deltaTime;
        ScoreText.text = ((int)Score).ToString();

        if (Score > PlayerPrefs.GetFloat("score"))
        {
            PlayerPrefs.SetFloat("score",Score);
        }


    }

    public void onDeath()
    {
        isDead = true;
       
    }
}
