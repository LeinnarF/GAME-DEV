using UnityEngine;
using UnityEngine.Rendering;

public class Owl_Behaviour : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    rb = GetComponent<Rigidbody2D>();
    sr = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();
    }

    // Update is called once per frame
   
    void Update()
    {
        Animate();
    }


    
    private void Animate()
    {
        if (rb.linearVelocity.magnitude > 0.1f || rb.linearVelocity.magnitude < -0.1f)
        {
            anim.SetBool("isMoving", true);
             
        }
        else if(rb.linearVelocity.magnitude == 0)
        {
            anim.SetBool("isMoving", false);
        }  
    }

    float direction = 1;
    public float moveSpeed = 3;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    void flipDirection()
    {
        direction *= -1;
        if(direction > 0){
            transform.localScale = new (Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    
        }else if(direction < 0){
        transform.localScale = new (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.linearVelocity = new Vector2(direction * -moveSpeed, -1f);
        }
        else if (collision.gameObject.CompareTag("aura"))
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
        
    }
     private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("aura"))
        {
            Destroy(gameObject);
        }
    }
    
}
