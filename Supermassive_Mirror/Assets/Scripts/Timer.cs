using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timerStartValue;
    [SerializeField] TMP_Text timerText;
    private float timeRemaining;

    private void Start()
    {
        ResetCountDownTimer();
        timerStartValue = 30;
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
            //ResetCountDownTimer();
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
