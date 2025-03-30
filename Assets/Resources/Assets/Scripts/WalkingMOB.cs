using System.Numerics;
using UnityEngine;
public class WalkingMOB : MonoBehaviour
{


    float direction = 1;
    public float moveSpeed = 3;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        UnityEngine.Vector3 origin = new UnityEngine.Vector3(transform.position.x + (0.8f * direction), transform.position.y + 0.725f, transform.position.z);
        RaycastHit2D hit = Physics2D.Raycast(origin, UnityEngine.Vector2.right * direction, 0.15f);
        Debug.DrawRay(origin,(UnityEngine.Vector2.right * 0.15f) * direction, Color.red);
        
        
        if(hit.collider != null)
        {
            if(hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Tree") || hit.collider.CompareTag("Player"))
            {
                flipDirection();
            }
        }
        
        
        rb.linearVelocity = new (direction * moveSpeed, rb.linearVelocity.y);
    }

    void flipDirection()
    {
        direction *= -1;
        if(direction > 0){
            transform.localScale = new (Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    
        }else if(direction < 0){
        transform.localScale = new (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground") || collision.CompareTag("Tree"))
        {
            flipDirection();
        }
        
    }
}

internal class hP
{
}