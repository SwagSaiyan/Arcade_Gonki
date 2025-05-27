using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class TimerAndFinish : MonoBehaviour
{
    private float startTime;
    private bool isRunning;
    public TMPro.TMP_Text timerText;

    void Start()
    {
        // ������������� ������� ��� ������ �������
        startTime = Time.time;
        isRunning = true;
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
