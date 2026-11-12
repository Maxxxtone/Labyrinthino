using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Панель победы
/// </summary>
public class WinPanel : MonoBehaviour
{
    [SerializeField] private Image[] _stars;
    [SerializeField] private Sprite _goldStar;
    public void Show(int stars)
    {
        for (int i = 0; i < stars; i++)
        {
            _stars[i].sprite = _goldStar;
        }
    }
}
