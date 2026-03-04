using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float dashForce; 
    [SerializeField] private float dashDuration;
    private float dashTimer;
    private bool isDashing = false;
    public Animator animator;

  

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
        float velocidadX = Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        float velocidadY = Input.GetAxis("Vertical")*Time.deltaTime*speed;
        animator.SetFloat("Movement", velocidadX*speed);//Las condiciones del movimiento 
        Vector2 posicion = transform.position;
        transform.position = new Vector2(velocidadX + posicion.x,velocidadY + posicion.y);
       /* movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized; */
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


