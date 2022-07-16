using UnityEngine;
public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rigidbody;
    private Vector2 playerDirection;
    public float jumpValue = 25;
    public int MaxJumpCount = 2;
    public Animator Animator;

    private int multiJumpCount;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Animator.SetBool("IsJumping", true);
            multiJumpCount++;
            if (multiJumpCount <= MaxJumpCount)
            {
                rigidbody.velocity = new Vector3(0, jumpValue, 0);
            }
           
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rigidbody.transform.localScale = new Vector3(0.3f, 0.2f, 1);
        }
        else
        {
            rigidbody.transform.localScale = new Vector3(0.3f, 0.3f, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground" || collision.gameObject.tag == "Cloud")
        {
            multiJumpCount = 0;
        }
    }
}
