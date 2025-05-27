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
        // Инициализация времени при старте скрипта
        startTime = Time.time;
        isRunning = true;
    }
    void Update()
    {
        if (isRunning)
        {
            // Вычисляем прошедшее время
            float elapsedTime = Time.time - startTime;

            // Форматируем время в минуты:секунды.миллисекунды
            string minutes = ((int)elapsedTime / 60).ToString("00");
            string seconds = (elapsedTime % 60).ToString("00");
            string milliseconds = ((elapsedTime * 1000) % 1000).ToString("000");

            // Обновляем текст
            timerText.text = $"{minutes}:{seconds}.{milliseconds}";
        }
    }

    // Опциональные методы для управления таймером
    public void PauseTimer()
    {
        isRunning = false;
    }

    public void ResumeTimer()
    {
        isRunning = true;
        startTime = Time.time - (Time.time - startTime); // Корректируем startTime для продолжения
    }

    public void ResetTimer()
    {
        startTime = Time.time;
    }
}
