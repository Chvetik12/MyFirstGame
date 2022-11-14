using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class AstroMan : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jump = 20;
    [SerializeField] private Transform sensorGround;
    [SerializeField] private int Crystal = 0;
    Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private bool isRight = true;
    private bool isGround;
    public int lives;
    private float inputVertical;

    public int crystal
    {
        get => Crystal;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(move * speed, rb.velocity.y, 0);
        anim.SetFloat("SpeedX", Mathf.Abs(move));
        Flip(move);
    }

    void Update()
    {
        Jump();
    }
    void Jump()
    {
        isGround = Physics2D.OverlapCircleAll(sensorGround.position, 0.3f).Length > 1;
        if (Input.GetButtonDown("Jump") && isGround)
        {
            rb.AddForce(Vector2.up * jump);
        }
        //anim.SetFloat("speedY", rb.velocity.y);
        anim.SetBool("isGround", isGround);
    }
    void Flip(float move)
    {
        if (move < 0 && isRight)
        {
            isRight = false;
            sr.flipX = true;
        }
        else if (move > 0 && !isRight)
        {
            isRight = true;
            sr.flipX = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Crystal")
        {
            Crystal += 100;

            //print("Crystal: " + Crystal);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "spikes")
        {
            lives -= 1;
            //print("CollisionEnter");


            if (lives == 0)
            {
                var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex);

            }
        }
    }
        private void OnTriggerStay2D(Collider2D other)
        {

            if (other.tag == "Ladder")
            {
            rb.gravityScale = 0;
            //rb.velocity = Vector2.zero; //щоб не стрибав високо персонаж
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.position.x, inputVertical * speed);
           
            anim.SetFloat("LadderUp", inputVertical);
            
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {

        if (other.tag == "Ladder")
           {
            anim.SetBool("LadderUp", false);
           }
        }
    
}
