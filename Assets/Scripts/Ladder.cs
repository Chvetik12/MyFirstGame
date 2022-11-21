using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ladder : MonoBehaviour
{
    private float inputHorizontal;
    private float inputVertical;
    private Animator anim;
    public float distance;
    public LayerMask WhatIsLadder;
    private bool LadderUp;
    Rigidbody2D rb;

    [SerializeField] private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, WhatIsLadder);
        anim.SetBool("LadderUp", LadderUp);
        if (hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                LadderUp = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                LadderUp = false;
            }
        }
        if (LadderUp == true && hitInfo.collider != null)
        {
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 2;
        }
    }
}
//    private Animator anim;
//    Rigidbody2D rb;
//    private bool LadderUp;
//    [SerializeField] private float speed = 5;
//    private float inputVertical;

//    private void Awake()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        anim = GetComponent<Animator>();
//    }
//    void FixedUpdate()
//    {
//        if (LadderUp == true)
//        {
//            inputVertical = Input.GetAxisRaw("Vertical");
//            rb.velocity = new Vector2(rb.position.x, inputVertical * speed);
//            rb.gravityScale = 0;
//            anim.SetFloat("LadderUp", inputVertical);
//        }
//        else
//        {
//            rb.gravityScale = 5;
//        }

//    }
//}


//    private void OnTriggerStay2D(Collider2D other)//при пересичении с чем то сталкиваеться

//    {
//        other.GetComponent<Rigidbody2D>().gravityScale = 0;

//        if (other.gameObject.CompareTag("Player"))
//        {
//            if (Input.GetKey(KeyCode.W))
//            {
//                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
//            }
//            else if (Input.GetKey(KeyCode.S))
//            {
//                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed); ;
//            }
//            else
//            {
//                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
//            }
//        }

//    }
//    private void OnTriggerExit2D(Collider2D other)
//    {
//        other.GetComponent<Rigidbody2D>().gravityScale = 1;

//    }
//}
//private void OnTriggerStay2D(Collider2D other)
//{

//    if (other.tag == "Ladder")
//    {
//        anim.SetBool("LadderUp",true);
//        float value = Input.GetAxis("Vertical");
//        //rb.velocity = Vector2.zero; //щоб не стрибав високо персонаж
//        rb.velocity = new Vector2(value * speed, rb.velocity.y);
//    }
//}
//private void OnTriggerExit2D(Collider2D other)
//{

//    if (other.tag == "Ladder")
//    {
//        anim.SetBool("LadderUp", false);
//    }
//private float inputHorizontal;
//    private float inputVertical;
//    public float distance;
//    public LayerMask WhatIsLadder;
//    private bool LadderUp;

//    [SerializeField] private float speed;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    // Update is called once per frame
//    void FixedUpdate()
//    {
//        inputHorizontal = Input.GetAxisRaw("Horizontal");
//        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
//        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, WhatIsLadder);
//        if (hitInfo.collider != null)
//        {
//            if (input.GetKeyDown(KeyCode.UpArrow))
//            {
//                LadderUp == true;
//            }
//        }
//        else
//        {
//            if (input.GetKeyDown(KeyCode.LeftArrow) || input.GetKeyDown(KeyCode.RightArrow))
//            {
//                LadderUp == false;
//            }
//        }
//        if (LadderUp == true && hitInfo.collider != null)
//        {
//            inputVertical = Input.GetAxisRaw("Vertical");
//            rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
//            rb.gravityScale = 0;
//        }
//        else
//        {
//            rb.gravityScale = 5;
//        }


//    }
//}