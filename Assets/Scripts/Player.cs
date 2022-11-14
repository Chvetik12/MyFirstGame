using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Lives = 5;
    public float Speed = 4.0f;
    public float jump = 1.0f;
    public Rigidbody2D PlayerRigidbody;
    public Animation CharAnimation;
    public SpriteRenderer sprite;
    bool OnGround;

    void Start()
    {
        PlayerRigidbody = GetComponentInChildren<Rigidbody2D>();
        CharAnimation = GetComponentInChildren<Animation>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    void Move()
    {
        Vector3 tempvector = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempvector, Speed * Time.deltaTime);
        if (tempvector.x<0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
    void Jump()
    {
        PlayerRigidbody.AddForce(transform.up * jump, ForceMode2D.Impulse);
    }
    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        OnGround = colliders.Length > 1;
        Debug.Log(colliders.Length);
    }
    private void FixedUpdate()
    {
        CheckGround();
    }

    void Update()
    {
        if(Input.GetButton("Horizontal"))
        {
            Move();
        }
        if(OnGround && Input.GetButton("Jump"))
        {
            Jump();
        }
    }
}
