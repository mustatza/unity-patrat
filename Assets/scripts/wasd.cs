using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasd : MonoBehaviour {
    bool canJump =true;
    Rigidbody2D patrat;
    Vector3 jump;
    Vector3 d;
    Vector3 s;
    Vector3 a;
    // Use this for initialization
    void Start () {

        patrat = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        d = new Vector3(2.0f, 0.0f, 0.0f);
        a = new Vector3(-2.0f, 0.0f, 0.0f);
        s = new Vector3(0.0f, -2.0f, 0.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.Space) && canJump) {
            canJump = false;
            patrat.AddForce(jump * 3.7f, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
         
            patrat.AddForce(d * 3.7f, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {

            patrat.AddForce(a * 3.7f, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {

            patrat.AddForce(s * 3.7f, ForceMode2D.Impulse);
        }
    }
}
