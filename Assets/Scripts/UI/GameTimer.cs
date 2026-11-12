using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Игровой верхний таймер
/// </summary>
public class GameTimer : MonoBehaviour
{
    public event Action TimerEnd;
    [SerializeField] private float _seconds = 40;
    [SerializeField] private TextMeshProUGUI _timerTMP;
    [SerializeField] private Image _timerFill;
    private float _currentTime;
    private bool _running;
    private Coroutine _tick;
    private void Start()
    {
        Restart();
    }
    /// <summary>
    /// Перезапуск таймера
    /// </summary>
    public void Restart()
    {
        _currentTime = _seconds;
        _timerTMP.text = _currentTime.ToString();
        _timerFill.fillAmount = _currentTime / _seconds;
        _running = true;
        _tick = StartCoroutine(StartTimer());
    }
    /// <summary>
    /// Остановка таймера при приогрише
    /// </summary>
    public void OnLose()
    {
        _currentTime = 0;
        _timerTMP.text = _currentTime.ToString();
        _timerFill.fillAmount = _currentTime / _seconds;
        _running = false;
    }
    public void Stop()
    {
        StopCoroutine(_tick);
        _running = false;
    }
    private IEnumerator StartTimer()
    {
        while (_running)
        {
            yield return new WaitForSeconds(1f);
            _currentTime -= 1;
            _timerTMP.text = _currentTime.ToString();
            _timerFill.fillAmount = _currentTime / _seconds;
            if (_currentTime == 0)
            {
                TimerEnd?.Invoke();
                _running = false;
            }
        }
    }
}
