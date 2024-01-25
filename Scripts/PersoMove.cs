using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouvementPersonnage : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 m_Position;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start(){

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update(){

        ProcessInputs();
    }
    void FixedUpdate(){

        MovePlayer();
        Flip(rb.velocity.x);
        Animate();
    }

    private void ProcessInputs(){

        float deplacementHorizontal = Input.GetAxis("Horizontal");
        float deplacementVertical = Input.GetAxis("Vertical");

        m_Position = new Vector2(deplacementHorizontal, deplacementVertical);
    }

    void MovePlayer(){

        m_Position.Normalize();
        rb.velocity = new Vector2(m_Position.x * moveSpeed, m_Position.y * moveSpeed);
        
    }

    void Animate()
    {
        animator.SetFloat("SpeedVertical", rb.velocity.y);
        animator.SetFloat("SpeedHorizontal", rb.velocity.x);
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f) {
            spriteRenderer.flipX = false;
        }else if( _velocity < 0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

}
