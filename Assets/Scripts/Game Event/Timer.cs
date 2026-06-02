using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float timeRemaining = 10f;
    
    private bool timerIsRunning = false;

    void Start()
    {
        // Mulai timer saat game dimulai
        timerIsRunning = true;
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (timerIsRunning && timeRemaining > 0)
        {
            // Update teks setiap frame
            DisplayTime(timeRemaining);
            
            // Kurangi waktu berdasarkan waktu nyata (detik)
            timeRemaining -= Time.deltaTime;
            yield return null;
        }

        // Ketika waktu habis
        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            DisplayTime(timeRemaining);
            timerIsRunning = false;
            
            // Panggil fungsi mati dari PlayerMovement
            if (PlayerMovement.instance != null)
            {
                PlayerMovement.instance.DeadAnim();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timerText.text = timeToDisplay.ToString("0");
    }
}