// using UnityEngine;
// using TMPro;
// using UnityEngine.SceneManagement;
// using System.Collections;

// public class TimeManager : MonoBehaviour
// {
//     [SerializeField] PlayerController playerController;
//     [SerializeField] TMP_Text timeText;
//     [SerializeField] GameObject gameOverText;
//     [SerializeField] float startTime = 5f;
//     float timeleft;
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         timeleft = startTime;
//         //UpdateTimeText();    
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         timeleft -= Time.deltaTime;
//         timeText.text = timeleft.ToString("F1");
//         if (timeleft <= 0)
//         {
//             GameOver();
//             ReloadScene();
//         }
//     }

//     public void IncreaseTime(float amount)
//     {
//         timeleft += amount;
//         if (timeleft > startTime) // Prevent time from exceeding the initial value
//         {
//             timeleft = startTime;
//         }
//         //UpdateTimeText();
//     }

//     void GameOver()
//     {
//         playerController.enabled = false; // Disable player controls
//         timeText.enabled = false; // Hide the time text
//         gameOverText.SetActive(true);
//         Time.timeScale = .1f; // Stop the game
//     }

//     void ReloadScene()
//     {
//         int currentScene = SceneManager.GetActiveScene().buildIndex;
//         SceneManager.LoadScene(currentScene); // Reload the current scene
//     }
// }
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimeManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime = 5f;
    // New serialized field to control the delay before the scene reloads
    [SerializeField] float reloadDelay = 2f;
    float timeleft;
    AudioSource audioSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        timeleft = startTime;
        // Make sure time scale is normal when the scene starts
        Time.timeScale = 1f;
        //UpdateTimeText();    
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        timeText.text = timeleft.ToString("F1");
        if (timeleft <= 0)
        {
            GameOver();
            // We are no longer calling ReloadScene() directly here
        }
    }

    public void IncreaseTime(float amount)
    {
        timeleft += amount;
        if (timeleft > startTime) // Prevent time from exceeding the initial value
        {
            timeleft = startTime;
        }
        //UpdateTimeText();
    }

    void GameOver()
    {
        playerController.enabled = false; // Disable player controls
        timeText.enabled = false; // Hide the time text
        gameOverText.SetActive(true);
        Time.timeScale = .1f; // Slow down the game to create a dramatic effect

        // Start the coroutine to handle the delay and scene reload
        StartCoroutine(ReloadWithDelay());
    }

    void ReloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene); // Reload the current scene
    }

    // New coroutine to handle the delay before reloading the scene
    IEnumerator ReloadWithDelay()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(reloadDelay);

        // Reset time scale to normal before reloading the scene
        Time.timeScale = 1f;
        
        // Now call the function to reload the scene
        ReloadScene();
    }
}
