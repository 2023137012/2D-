using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 10f; // 점프 힘
    public float fallMultiplier = 2.5f; // 낙하 중일 때 중력 가속도 배율
    public float lowJumpMultiplier = 2f; // 적게 점프할 때 중력 가속도 배율
    public bool isJumping = false; // 점프 중인지 여부

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 스페이스바를 누르고 점프 중이지 않은 경우
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            JumpAction();
        }

        // 낙하 중인 경우
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        // 적게 점프한 경우
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void JumpAction()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isJumping = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // 땅에 닿았을 때
        if (other.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }
}

