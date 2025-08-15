using UnityEngine;

public class Pickup : MonoBehaviour
{
    const string playerTag = "Player";
    [SerializeField] float rotationspeed = 100f;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == playerTag)
        {
            Debug.Log("Pickup collected by: " + other.gameObject.name);
            // Add logic to handle the pickup, e.g., increase score, destroy the pickup, etc.
            Destroy(gameObject); // Destroys the pickup object
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    



    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotationspeed * Time.deltaTime, 0f);
    }
}
