using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magiclab.InputHandler;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

    public static PlayerControl instance;

    public Text BestScoreText;


    private CharacterController characterController;
    private Vector3 moveVector;
   
  

    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    public float speed;

    private float animationDuration = 1.3f;

    private bool isDead = false;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        
        characterController = GetComponent<CharacterController>();
        speed = 2.5f;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }

        if (Time.time < animationDuration)
        {
            characterController.Move(Vector3.forward * speed * Time.deltaTime);

            return;
        }
        moveVector = Vector3.zero;

        if (characterController.isGrounded)
        {
            verticalVelocity = -0.5f;
        }

        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        // X - Left and Right
        moveVector.x = InputHandler.GetHorizontal() *speed*1.5f;
        // Y - Up and Down
        moveVector.y = verticalVelocity;/* Input.GetAxisRaw("Vertical") * speed;*/
        // Z- Forward and Backward
        moveVector.z = speed;

        characterController.Move((moveVector * speed) * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Barrier")
        {
            Death();
        }

      

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            instance.speed = 5f;
        }
    }


    private void Death()
    {
        isDead = true;
        ScoreManager.instance.onDeath();
        GameManager.instance.AudioSoruce.Pause();
        Time.timeScale = 0;
        GameManager.instance.GameOverPanel.SetActive(true);
        GameManager.instance.ScorePanel.SetActive(false);

        ScoreManager.instance.BestScore = PlayerPrefs.GetFloat("score");
        BestScoreText.text = "Best Score : " + ((int)ScoreManager.instance.BestScore).ToString();
        
       
     
        
    }


} 
