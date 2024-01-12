using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameUIManager : MonoBehaviour
{
    public Text timerText;
    public float totalTime = 0;  // Set the total time in seconds

    public Slider expSlider;

    private float elapsedTime;

    public GameObject UpgradePanel;
    public GameObject gameOverPanel;

    public BaseWeapon weapon;

    public static GameUIManager Instance { get; set; }


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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


    public void UpdateExp()
    {
        expSlider.value += 0.2f;
        if(expSlider.value == 1)
        {
            UpgradePanel.SetActive(true);
            expSlider.value = 0;
            Time.timeScale = 0;
        }
    }


    public void Upgrade(int i)
    {

        switch(i)
        {
            case 0:

                break;

            case 1:
                weapon.rateOfFire -= 0.10f;
                break;
        }

        UpgradePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
