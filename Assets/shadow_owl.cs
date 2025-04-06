using Unity.VisualScripting;
using UnityEngine;

public class shadow : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D collision)
    {
        while(collision.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector3(-0.3f, collision.transform.position.y, collision.transform.position.z);
        }
       
    }
    

}
