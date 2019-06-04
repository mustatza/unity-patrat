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
    public Animator animator;
    public Text livesText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("speed",Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump") && canJump) {
            Debug.Log("Jump1");
            jump = true;
            animator.SetBool("jumping",true);
            canJump = false;
            return;
        }
        if (canJump==false) {
            if (Input.GetButtonDown("Jump") && canJump1)
            {
                Debug.Log("Jump2");
                animator.SetBool("jumping", true);
                jump = true;
                canJump1 = false;
            }
        }

    }
    public void OnLanding() {
        Debug.Log("Jump landing");
        //animator.SetBool("jumping", false);
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Enemy") {
            vieti--;
            Debug.Log("Mort:" + vieti);
            livesText.text = vieti.ToString();
        } 

        if(collision.collider.tag == "Ground") {
            animator.SetBool("jumping", false);
            canJump = true;
            canJump1 = true;
        }
    }
}
