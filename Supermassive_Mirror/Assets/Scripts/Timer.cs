using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timerStartValue;
    [SerializeField] Text timerText;
    private float timeRemaining;

    private void Start()
    {
        ResetCountDownTimer();
    }

    private void Update()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = ((int)timeRemaining).ToString();
        }
        else
        {
            ResetCountDownTimer();
        }
    }
    public void ResetCountDownTimer()
    {
        timeRemaining = timerStartValue;
    }

    public float GetRemainingCountDownTime()
    {
        return timeRemaining;
    }
}
