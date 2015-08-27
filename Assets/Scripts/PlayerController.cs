using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    Rigidbody2D playerRigid;

    private bool grounded;
    private bool doubleJumped;

    void Awake()
    {
        playerRigid = GetComponent<Rigidbody2D>();
    }
	// Use this for initialization
	void Start () {
	
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
	
	// Update is called once per frame
	void Update () {
        if(grounded){
            doubleJumped = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) && grounded){
            Jump(jumpHeight);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !grounded && !doubleJumped)
        {
            Jump(jumpHeight);
            doubleJumped = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(moveSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(-moveSpeed);
        }
	
	}

    public void Jump(float jump)
    {
        playerRigid.velocity = new Vector2(playerRigid.velocity.x, jump);
    }

    public void Move(float speed)
    {
        playerRigid.velocity = new Vector2(speed, playerRigid.velocity.y);
    }
}
