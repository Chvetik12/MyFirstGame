using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ladder : MonoBehaviour
{
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
//}