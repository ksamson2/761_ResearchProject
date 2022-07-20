using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    public float jumpValue = 25;
    public int MaxJumpCount = 2;
    public Animator Animator;
    private int multiJumpCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Animator.SetTrigger("IsJumping");
            multiJumpCount++;
            if (multiJumpCount <= MaxJumpCount)
            {
                rb.AddForce(transform.up * jumpValue, ForceMode2D.Impulse);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rb.transform.localScale = new Vector3(0.3f, 0.2f, 1);
        }
        else
        {
            rb.transform.localScale = new Vector3(0.3f, 0.3f, 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground" || collision.gameObject.tag == "Cloud")
        {
            multiJumpCount = 0;
        }
        Animator.ResetTrigger("IsJumping");
    }
}
