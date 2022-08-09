using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    public float jumpValue = 25;
    public Vector2 velocity;
    public int MaxJumpCount = 2;
    public Animator Animator;
    private int multiJumpCount = 0;
    [SerializeField]
    private AudioSource JumpSound;
    [SerializeField]
    private AudioSource RunOnCloudSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Animator.SetFloat("Velocity", velocity.y);
        velocity = rb.velocity;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            JumpSound.Play();
            Animator.SetTrigger("IsJumping");
            multiJumpCount++;
            if (multiJumpCount <= MaxJumpCount)
            {
                rb.AddForce(transform.up * jumpValue, ForceMode2D.Impulse);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rb.transform.localScale = new Vector3(0.2f, 0.2f, 1);
        }
        else
        {
            rb.transform.localScale = new Vector3(0.3f, 0.3f, 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cloud")
        {
            RunOnCloudSound.Play();
            multiJumpCount = 1;
            Animator.ResetTrigger("IsJumping");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            multiJumpCount = 0;
            Animator.ResetTrigger("IsJumping");
        }
    }
}
