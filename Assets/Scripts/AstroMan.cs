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
    [SerializeField] private TextMeshProUGUI textCrystal;
    [SerializeField] private Ui_Life Uilife;
    Rigidbody2D rb;
    private int Crystal = 0;
    private Animator anim;
    private SpriteRenderer sr;
    private bool isRight = true;
    private bool isGround;
    private float inputVertical;
    private int life = 5;
    
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
            textCrystal.text = Crystal.ToString();
            //print("Crystal: " + Crystal);
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "floor" || collision.tag == "spikes")
        {
            Damage();
            anim.SetTrigger("AnimationAstroRed");

        }
    }
    private void Damage()
    {
        life--;
        Uilife.RemuveLife();
        if (life == 0)
        {
            Time.timeScale = 0;
            Uilife.GameOver();
        }
    }
    
}



