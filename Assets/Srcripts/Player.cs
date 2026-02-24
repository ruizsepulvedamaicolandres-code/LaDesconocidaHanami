using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float dashForce; 
    [SerializeField] private float dashDuration;
    private float dashTimer;
    private bool isDashing = false;

  

    private Rigidbody2D myRigidbody2D;
    private Vector2 movement;

    


    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Dash(); 

    }
    private void FixedUpdate()
    {
        if (isDashing == false)
        {
            myRigidbody2D.linearVelocity = movement * speed;        
        }
    }

    private void Move ()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
    }
    
    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDashing = true;
            dashTimer = dashDuration;
            myRigidbody2D.linearVelocity = movement * dashForce;
        }

        if(isDashing == true)
        {
            dashTimer -= Time.deltaTime;

            if (dashTimer <= 0)
            {
                isDashing=false;
            }
        }



    }

}


