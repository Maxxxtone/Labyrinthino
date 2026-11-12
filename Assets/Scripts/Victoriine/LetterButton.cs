using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LetterButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _letterTMP;
    private Button _button;
    private string _letter;
    private VictorinePanel _victorinePanel;
    public string Letter => _letter;
    public void Init(string letter, VictorinePanel panel)
    {
        _button = GetComponent<Button>();
        _victorinePanel = panel;
        _letter = letter;
        _letterTMP.text = letter;
    }
    public void Select()
    {
        _button.interactable = false;
        _victorinePanel.AddLetter(this);
    }
    public void Clear()
    {
        _button.interactable = true;
    }
    public void Deactivate()
    {
        _button.interactable = false;
    }
}
