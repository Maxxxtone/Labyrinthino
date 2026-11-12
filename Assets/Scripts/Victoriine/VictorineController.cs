using System.Collections;
using UnityEngine;
/// <summary>
/// Класс для управления панелями викторин
/// </summary>
public class VictorineController : MonoBehaviour
{
    [SerializeField] private VictorinePanel[] _panels;
    [SerializeField] private GameTimer _timer;
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private SceneSwitcher _sceneSwitcher;
    private int _currentPanel, _winCount;

    private void Start()
    {
        _timer.TimerEnd += _panels[_currentPanel].Lose;
        foreach (var item in _panels)
        {
            item.Init(this);
        }
    }
    public void Next(bool win)
    {
        if (win)
            _winCount++;
        StartCoroutine(SwitchLevel(win));
    }
    private IEnumerator SwitchLevel(bool win)
    {
        _timer.Stop();
        yield return new WaitForSeconds(4f);
        _timer.TimerEnd -= _panels[_currentPanel].Lose;
        _panels[_currentPanel].gameObject.SetActive(false);
        _currentPanel++;
        if (_currentPanel == _panels.Length)
        {
            if (win)
            {
                _winPanel.gameObject.SetActive(true);
                _winPanel.Show(_winCount);
            }
            else
            {
                _sceneSwitcher.ToMainMenu();
            }
        }
        else
        {
            _timer.Restart();
            _timer.TimerEnd += _panels[_currentPanel].Lose;
            _panels[_currentPanel].gameObject.SetActive(true);
        }
    }
}
