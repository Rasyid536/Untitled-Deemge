using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public static PlayerMovement instance;
    private bool isDead = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (isDead) return;

        horizontal = Input.GetAxisRaw("Horizontal");


        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && IsGrounded())
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

        if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space)) && rb.velocity.y > 0f)
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        animator.SetBool("IsGrounded", IsGrounded());

        Flip();
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spike"))
        {
            DeadAnim();
        }
    }

    public void DeadAnim()
    {
        if (isDead) return;

        isDead = true;

        horizontal = 0f;
        rb.velocity = Vector2.zero;
        StartCoroutine(WaitAnimationDone());
    }

    private IEnumerator WaitAnimationDone()
    {
        animator.Play("dead");

        yield return null;

        // 1. Tunggu sampai animasi jalan setengah (0.5f = 50%)
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.5f)
        {
            yield return null;
        }

        // Matikan script player tepat di tengah-tengah animasi
        this.enabled = false;

        // 2. Lanjut tunggu sisa animasinya sampai benar-benar selesai (1.0f = 100%)
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        GameManager.instance.LoseUI.SetActive(true);
    }
}
