using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cheeseText;
    [SerializeField] private GameObject[] healthBars;
    [SerializeField] private GameObject infoText;

    private int _totalCheese;

    public static UIManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }
    public void UpdateCheeseText()
    {
        _totalCheese++;
        cheeseText.text = _totalCheese.ToString();
    }

    public void UpdateHealth(int health)
    {
        if (health >= 0 && health < healthBars.Length)
        {
            healthBars[health].SetActive(false);
        }
    }

    public void StartGame()
    {
        infoText.SetActive(false);
    }

}
