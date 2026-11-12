using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsBar : MonoBehaviour
{
    [SerializeField] private Sprite _fill, _noFill;
    [SerializeField] private Button[] _buttons;
    private void OnEnable()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            int index = i;
            _buttons[i].onClick.AddListener(() => OnClick(index));
        }
    }

    private void OnClick(int index)
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].image.sprite = i < index + 1 ? _fill : _noFill;
        }
    }
}
