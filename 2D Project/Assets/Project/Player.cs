using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    RaycastHit2D hit;
    public float moveSpeed = 5;
    public float jumpForce;
    public LayerMask groundCheck;
    public LayerMask monsterLayer;
    public bool isPlayerWatchingRight;
    public SpriteRenderer IMG;
    bool lookingR;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        IMG = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 15;
        }
        else
        {
            moveSpeed = 5;
        }

        // 플레이어 이동

        rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rb.velocity.y);

        if (Physics2D.Raycast(transform.position, Vector2.down, 1.38f, groundCheck) && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // 땅판정 확인선 그리기

        Debug.DrawRay(transform.position, Vector2.down * 1.38f);
        if (Input.GetAxis("Horizontal") > 0)
        // 축이 양수 일때 (오른쪽을 바라보고 있을때)
        {
            lookingR = true;
            IMG.flipX = false;
        }
        if (Input.GetAxis("Horizontal") < 0)
        // 축이 음수일때 (왼쪽을 바라보고 있을때)
        {
            lookingR = false;
            IMG.flipX = true;
        }
    }
}

