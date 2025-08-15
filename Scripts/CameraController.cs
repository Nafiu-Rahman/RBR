// using UnityEngine;
// using Cinemachine;
// using System.Collections;

// public class CameraController : MonoBehaviour
// {
//     [SerializeField] float minFOV = 40f;
//     [SerializeField] float maxFOV = 79f;
//     [SerializeField] float zoomDuration = 1f;

//     CinemachineCamera cinemachineCamera;

//     void Awake()
//     {
//         cinemachineCamera = GetComponent<CinemachineCamera>();
//     }
//     public void ChangeCameraFOV(float speedAmount)
//     {
//         StartCoroutine(ChangeFOVRoutine(speedAmount));
//     }

//     IEnumerator ChangeFOVRoutine(float speedAmount)
//     {
//         float startFOV = cinemachineCamera.Lens.FieldOfView;
//         float targetFOV = Mathf.Clamp(startFOV + speedAmount, minFOV, maxFOV);
//         float elapsedTime = 0f;
//         while (true)
//         {
//             elapsedTime += Time.deltaTime;
//             float t = Mathf.Clamp01(elapsedTime / zoomDuration);
//             cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, t);

//             if (t >= 1f)
//                 break;

//             yield return null;
//         }

//         cinemachineCamera.Lens.FieldOfView = targetFOV; // Ensure final value is set
//     }

//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] ParticleSystem speedupParticleSystem;
    [SerializeField] float minFOV = 20f;
    [SerializeField] float maxFOV = 120f;
    [SerializeField] float zoomDuration = 1f;
    [SerializeField] float zoomSpeedModifer = 5f;

    CinemachineCamera cinemachineCamera;

    void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();
    }

    public void ChangeCameraFOV(float speedAmount)
    {
        StopAllCoroutines(); // Stop any ongoing zoom routines
        StartCoroutine(ChangeFOVRoutine(speedAmount));
        if (speedAmount > 0)
        {
            speedupParticleSystem.Play(); 
        }

    }

    IEnumerator ChangeFOVRoutine(float speedAmount)
    {
        float startFOV = cinemachineCamera.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + speedAmount * zoomSpeedModifer, minFOV, maxFOV);

        float elapsedTime = 0f;

        while (elapsedTime < zoomDuration)
        {
            float t = elapsedTime / zoomDuration;
            elapsedTime += Time.deltaTime;

            cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, t);
            yield return null;
        }

        cinemachineCamera.Lens.FieldOfView = targetFOV;
    }
}
