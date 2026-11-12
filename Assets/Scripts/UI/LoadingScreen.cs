using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _percentsTMP;
    [SerializeField] private Image _fill;
    private IEnumerator Start()
    {
        float timer = 0f;
        while (timer < 2f)
        {
            yield return new WaitForSeconds(0.1f);
            timer += 0.1f;
            _fill.fillAmount = timer / 2f;
            _percentsTMP.text = $"{Mathf.Round((timer / 2f)*100)}%";
        }
        _fill.fillAmount = 1;
        _percentsTMP.text = "100%";
        SceneManager.LoadScene(1);
    }
}
