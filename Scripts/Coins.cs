using UnityEngine;

public class Coins : MonoBehaviour
{
    ScoreManager scoreManager;
    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    void OnTriggerEnter(Collider other)
    {
            if(other.gameObject.tag == "Player")
        
            {
                scoreManager.IncearseScore(100);
            }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        
    }
}
