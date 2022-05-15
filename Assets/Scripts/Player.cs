using UnityEngine;
public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rigidbody;
    private Vector2 playerDirection;
    public float jumpValue = 25;
    public int MaxJumpCount = 2;


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
            multiJumpCount++;
            if (multiJumpCount <= MaxJumpCount)
            {
                rigidbody.velocity = new Vector3(0, jumpValue, 0);
            }
           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            multiJumpCount = 0;
        }
    }
}
