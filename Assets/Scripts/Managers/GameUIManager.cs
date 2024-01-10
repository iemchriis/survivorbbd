using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUIManager : MonoBehaviour
{
    public Text timerText;
    public float totalTime = 0;  // Set the total time in seconds

    private float elapsedTime;

    void Start()
    {
        elapsedTime = 0f;
    }

    void Update()
    {
        
            elapsedTime += Time.deltaTime;
            UpdateTimerText();  
    }

    void UpdateTimerText()
    {
        // Format the time as minutes:seconds
        float remainingTime = totalTime + elapsedTime;
        string minutes = Mathf.Floor(remainingTime / 60).ToString("00");
        string seconds = (remainingTime % 60).ToString("00");

        // Update the Text UI element
        timerText.text = $"{minutes}:{seconds}";
    }
}
