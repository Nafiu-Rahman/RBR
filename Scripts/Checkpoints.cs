using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [SerializeField] float checkpointTimeExtension = 5f;
    TimeManager timeManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeManager = FindFirstObjectByType<TimeManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            // TimeManager timeManager = FindFirstObjectByType<TimeManager>();
            // if (timeManager != null)
            // {
                timeManager.IncreaseTime(checkpointTimeExtension);
            //}
            // gameManager.SetLastCheckpoint(transform.position);
            // gameObject.SetActive(false); // Disable the checkpoint after being activated
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
