using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class VictorinePanel : MonoBehaviour
{
    [SerializeField] private List<string> _allLetters;
    [SerializeField] private string _finalAnswer, _correctAnswer;
    [SerializeField] private TextMeshProUGUI _answerField;
    [SerializeField] private LetterButton[] _allButtons;
    [SerializeField] Animator[] _fragments;
    [SerializeField] private TextMeshProUGUI _errorText;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _loseSound;
    private int _attempts = 0;
    private string _currentAnswer;
    private List<LetterButton> _selectedButtons = new();
    private VictorineController _controller;
    private bool _gameEnd;
    private void OnEnable()
    {
        _allLetters = _allLetters.OrderBy(x => Random.value).ToList();
        for (int i = 0; i < _allButtons.Length; i++)
        {
            _allButtons[i].Init(_allLetters[i], this);
        }
    }
    public void Init(VictorineController controller)
    {
        _controller = controller;
    }
    public void AddLetter(LetterButton button)
    {
        _selectedButtons.Add(button);
        _currentAnswer += button.Letter;
        _answerField.text = _currentAnswer;
    }
    public void RemoveLetter()
    {
        if (_gameEnd)
            return;
        if (_selectedButtons.Count == 0)
            return;
        _selectedButtons.Last().Clear();
        _selectedButtons.Remove(_selectedButtons.Last());
        _currentAnswer = _currentAnswer.Remove(_currentAnswer.Length - 1);
        _answerField.text = _currentAnswer;
    }
    public void Check()
    {
        if (_gameEnd)
            return;
        if (_currentAnswer == _correctAnswer)
        {
            _gameEnd = true;
            Deactivate();
            _errorText.gameObject.SetActive(false);
            // звук победы
            foreach (var item in _fragments)
            {
                item.SetTrigger("Hide");
            }
            _controller.Next(true);
        }
        else
        {
            _audioSource.PlayOneShot(_loseSound);
            _fragments[_attempts].SetTrigger("Hide");
            _attempts++;
            _errorText.gameObject.SetActive(true);
            if (_attempts == 3)
            {
                Lose();
            }
        }
    }
    public void Lose()
    {
        _gameEnd = true;
        Deactivate();
        _answerField.text = _finalAnswer;
        _controller.Next(false);
    }
    private void Deactivate()
    {
        foreach (var item in _allButtons)
        {
            item.Deactivate();
        }
    }
}
