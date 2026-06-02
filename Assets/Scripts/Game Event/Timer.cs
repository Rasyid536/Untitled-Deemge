using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float timeRemaining = 10f;

    private bool timerIsRunning = false;
    private bool timerStarted = false;

    void Start()
    {
        // Tampilkan nilai awal, timer belum berjalan sampai player mulai bergerak
        DisplayTime(timeRemaining);
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (timeRemaining > 0)
        {
            if (!timerStarted && PlayerMovement.instance != null && PlayerMovement.instance.IsMoving())
            {
                timerStarted = true;
                timerIsRunning = true;
            }

            if (timerIsRunning)
            {
                timeRemaining -= Time.deltaTime;
            }

            timeRemaining = Mathf.Max(timeRemaining, 0f);
            DisplayTime(timeRemaining);
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