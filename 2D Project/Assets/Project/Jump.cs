using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 10f; // ���� ��
    public float fallMultiplier = 2.5f; // ���� ���� �� �߷� ���ӵ� ����
    public float lowJumpMultiplier = 2f; // ���� ������ �� �߷� ���ӵ� ����
    public bool isJumping = false; // ���� ������ ����

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �����̽��ٸ� ������ ���� ������ ���� ���
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            JumpAction();
        }

        // ���� ���� ���
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        // ���� ������ ���
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
        // ���� ����� ��
        if (other.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }
}

