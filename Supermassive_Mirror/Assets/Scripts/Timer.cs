using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timerStartValue;
    private TMP_Text timerText;
    private float timeRemaining;

    private void Start()
    {
        ResetCountDownTimer();
        timerText = this.GetComponent<TMP_Text>();
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
