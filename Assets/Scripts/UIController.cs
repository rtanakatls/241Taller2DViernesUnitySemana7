using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    private static UIController instance;

    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private Image lifeBar;

    public static UIController Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void UpdateLife(int life)
    {
        lifeText.text = $"Life: {life}";
    }

    public void UpdateLifeBar(float life, float maxLife)
    {
        lifeBar.fillAmount = life / maxLife;
    }
}
