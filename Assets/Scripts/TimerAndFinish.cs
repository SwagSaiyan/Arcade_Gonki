using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class TimerAndFinish : MonoBehaviour
{
    int circels = -1;
    bool gameStarted = false;
    public TMPro.TMP_Text circelsText;
    private float startTime;
    private bool isRunning;
    public TMPro.TMP_Text timerText;
    bool firstTrigger = false;
    bool secondTrigger = false;
    bool thirdTrigger = false;
    bool haveCircels = false;

    void Start()
    {

    }
    void Update()
    {
        if (isRunning)
        {
            // ��������� ��������� �����
            float elapsedTime = Time.time - startTime;

            // ����������� ����� � ������:�������.������������
            string minutes = ((int)elapsedTime / 60).ToString("00");
            string seconds = (elapsedTime % 60).ToString("00");
            string milliseconds = ((elapsedTime * 1000) % 1000).ToString("000");

            // ��������� �����
            timerText.text = $"{minutes}:{seconds}.{milliseconds}";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("finish") && (firstTrigger = false) && (secondTrigger = false) && (thirdTrigger = false) && (haveCircels = false) && (gameStarted = false))
        {
            gameStarted = true;
        }

        if(other.gameObject.CompareTag("trigger1"))
        {
            firstTrigger = true;
        }

        if(other.gameObject.CompareTag("trigger2"))
        {
            secondTrigger = true;
        }

        if(other.gameObject.CompareTag("trigger3"))
        {
            thirdTrigger = true;
        }

        if(other.gameObject.CompareTag("finish") && (firstTrigger = true) && (secondTrigger = true) && (thirdTrigger = true))
        {
            // ������������� ������� ��� ������ �������
            startTime = Time.time;
            isRunning = true;
            circels++;
            haveCircels = true;
            firstTrigger = false;
            secondTrigger = false;
            thirdTrigger = false;
            circels.ToString();
            circelsText.text = $"{circels}";
        }

    }

    // ������������ ������ ��� ���������� ��������
    public void PauseTimer()
    {
        isRunning = false;
    }

    public void ResumeTimer()
    {
        isRunning = true;
        startTime = Time.time - (Time.time - startTime); // ������������ startTime ��� �����������
    }

    public void ResetTimer()
    {
        startTime = Time.time;
    }
}
