using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject AnimalPrefab;
    public float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("aura"))
        {
            if (AnimalPrefab != null && GameObject.Find(AnimalPrefab.name + "(Clone)") == null)
            {
                SpawnAnimal();
            }
        }
    }
   
    void SpawnAnimal()
    {
        Instantiate(AnimalPrefab, transform.position,Quaternion.identity);
    }
}

