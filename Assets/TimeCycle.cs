using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class LightIntensityController : MonoBehaviour
{
    public Light2D lightSource; // Reference to the Light component
    public float intensityChangeRate = 0.01f; // Amount to change intensity each second
    private float targetIntensity = 1f; // Maximum intensity
    private float minIntensity = 0f; // Minimum intensity
    private bool increasing = true; // Flag to check if we are increasing or decreasing intensity
    private bool isPaused = false; // Flag to check if the script is paused

    void Start()
    {
        if (lightSource == null)
        {
            lightSource = GetComponent<Light2D>(); // Get the Light component if not assigned
        }
    }

    void Update()
    {
        if (!isPaused)
        {
            if (increasing)
            {
                // Increase intensity
                lightSource.intensity += intensityChangeRate * Time.deltaTime;
                if (lightSource.intensity >= targetIntensity)
                {
                    lightSource.intensity = targetIntensity; // Clamp to max intensity
                    increasing = false; // Switch to decreasing
                    StartCoroutine(PauseCoroutine()); // Start pause when reaching max intensity
                }
            }
            else
            {
                // Decrease intensity
                lightSource.intensity -= intensityChangeRate * Time.deltaTime;
                if (lightSource.intensity <= minIntensity)
                {
                    lightSource.intensity = minIntensity; // Clamp to min intensity
                    increasing = true; // Switch to increasing
                    StartCoroutine(PauseCoroutine()); // Start pause when reaching min intensity
                }
            }
        }
    }

    private IEnumerator PauseCoroutine()
    {
        isPaused = true; // Set the paused flag
        yield return new WaitForSeconds(60); // Wait for 1 minute (60 seconds)
        isPaused = false; // Reset the paused flag
    }
}