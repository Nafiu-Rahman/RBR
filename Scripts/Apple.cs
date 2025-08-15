using UnityEngine;

public class Apple : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    LevelGenerator levelGenerator;
    private void Start() {
       levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
            if(other.gameObject.tag == "Player")
        
            {
                levelGenerator.ChangeMoveSpeed(3f);
            }
    }

}
