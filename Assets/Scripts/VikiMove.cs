using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikiMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveDirection = 0;
    public float maxSpeed = 10;
    private Animator animator;
    public float jumpForce = 20;
    private bool facingRight = true;
    public bool isGrounded;
    public float radius = 0.1f;
    public LayerMask layerMask;

    //Sonidos
    [SerializeField] private GameObject sonidoSaltico;
    private AudioSource saltoAudio;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        saltoAudio = sonidoSaltico.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {     
        if(GameController.gameOn){
        animator.SetBool("jumping", Input.GetKeyDown(KeyCode.W));
        
        
        if(Physics2D.Raycast(transform.position,Vector3.down,radius,layerMask)){
            isGrounded=true;
        }else{
            isGrounded=false;
        }
        
        Attack();
        FlipCharacter();
        if(Input.GetKeyDown(KeyCode.W)&&isGrounded){
            Jump();
        }
        }
    
    }

    void FixedUpdate(){
        if(GameController.gameOn){
         rb.velocity = new Vector2(moveDirection*maxSpeed,rb.velocity.y);
         Movement(); 
        }
 
    }

    public void FlipCharacter(){
                if(moveDirection!=0){
            if(moveDirection>0 && !facingRight){
                //gira a la derecha
                transform.localScale=new Vector3(1,1,1);
                facingRight=true;
            }
            if(moveDirection<0 && facingRight){
                //gira a la izquierda
                transform.localScale=new Vector3(-1,1,1);
                facingRight=false;
            }
        }
    }

    public void Movement(){
        moveDirection = Input.GetAxisRaw("Horizontal");
        animator.SetBool("running", moveDirection != 0);
    }
    private void Jump(){
        rb.AddForce(Vector2.up*jumpForce);
        saltoAudio.Play();
    }

    private void Attack(){
        animator.SetBool("attack", Input.GetKeyDown(KeyCode.M));
    }

} 