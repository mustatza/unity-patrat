using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public float horizontalMove = 0;
    public float runSpeed = 40f;
    bool jump = false;
    bool canJump = true;
    bool canJump1 = true;
    int vieti = 3;
    int timpViata = 0;
    public Animator animator;
    public Text livesText;
    public Button resetGame;


    // Use this for initialization
    void Start () {
        // Time.timeScale = 1;
        resetGame.gameObject.SetActive(false);
        resetGame.interactable = true;
    }

    public void decreaseTimeRemaining() {
        Debug.Log("invincibil: " + timpViata);
        timpViata--;
    }	

	// Update is called once per frame
	void Update () {
        if (timpViata <= 0) {
            CancelInvoke("decreaseTimeRemaining");
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("speed",Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump") && canJump) {
            
            jump = true;
            animator.SetBool("jumping",true);
            canJump = false;
            return;
        }
        if (canJump==false) {
            if (Input.GetButtonDown("Jump") && canJump1)
            {
                animator.SetBool("jumping", true);
                jump = true;
                canJump1 = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetBool("atack", true);
        }
        else { animator.SetBool("atack", false); }

    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void restart() {
        Time.timeScale = 1;
        resetGame.gameObject.SetActive(false);
        Camera.main.GetComponent<AudioSource>().Play();
        vieti = 3;
        livesText.text = "vieti: " + vieti.ToString();
        this.transform.position = new Vector3(16.33f, -15.38f,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Enemy" && timpViata <= 0) {
            vieti--;
            if (vieti == 0) {
                Time.timeScale = 0;
                Camera.main.GetComponent<AudioSource>().Stop();
                resetGame.gameObject.SetActive(true); 
            }
            livesText.text = "vieti: " + vieti.ToString();
            timpViata = 4;
            InvokeRepeating("decreaseTimeRemaining", 1, 1);
        } 

        if(collision.collider.tag == "Ground") {
            animator.SetBool("jumping", false);
            canJump = true;
            canJump1 = true;
        }
    }
}
