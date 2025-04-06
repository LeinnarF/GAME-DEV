using UnityEngine;

public class KameraMovement : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 5f;
    private PlayerMovement player;

    void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>();
    }

    void Update()
    {
        if (player != null)
        {
            if (player.isInCameraMode)
            {
                Vector3 move = new Vector3(
                    Input.GetAxisRaw("Horizontal"),
                    Input.GetAxisRaw("Vertical"),
                    0f
                );

                transform.position += move.normalized * moveSpeed * Time.deltaTime;
            }
        }
    }

    public void SnapToPlayer()
    {
        if (player != null)
        {
            Vector3 newPos = player.transform.position;
            newPos.z = transform.position.z; // maintain camera z-position
            transform.position = newPos;
        }
    }

}
