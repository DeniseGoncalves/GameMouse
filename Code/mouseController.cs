using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseController : MonoBehaviour
{
  
    private Rigidbody2D     playerRb;
    private Animator        playerAnimator;

    public  float           velocidadeMovimento;
    public  float           forcaPulo;

    public  Transform       groundCheck;
    private bool            isGrounded;

    private int             speedX;
    private float           speedY;

    public bool             isOlhandoEsquerda;

    // Start is called before the first frame update
    void Start()
    {
    
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if(horizontal != 0) 
        { 
            speedX = 1; 
            
        } 
        else 
        { 
            speedX = 0; 

        }

        if(isOlhandoEsquerda == true && horizontal > 0)
        {
            flip();
        }
        if(isOlhandoEsquerda == false && horizontal < 0)
        {
            flip();
        }

        speedY = playerRb.velocity.y;

        playerRb.velocity = new Vector2(horizontal * velocidadeMovimento, speedY);

        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            playerRb.AddForce(new Vector2(0, forcaPulo));
        }

       
    }

    void LateUpdate()
    {
        playerAnimator.SetInteger("speedX", speedX);
        playerAnimator.SetFloat("speedY", speedY);
        playerAnimator.SetBool("Grounded", isGrounded);
    }

    void flip()
    {
        isOlhandoEsquerda = !isOlhandoEsquerda;

        float x = transform.localScale.x;
        x*=-1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
    
}
