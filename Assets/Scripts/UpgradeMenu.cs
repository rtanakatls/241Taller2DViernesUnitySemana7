using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private Button lifeButton;
    [SerializeField] private Button shootDelayButton;
    [SerializeField] private Button damageButton;

    private void Awake()
    {
        lifeButton.onClick.AddListener(UpgradeLife);
        shootDelayButton.onClick.AddListener(UpgradeShootDelay);
        damageButton.onClick.AddListener(UpgradeDamage);
    }

    void UpgradeLife()
    {
        PlayerStats.life += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void UpgradeShootDelay()
    {
        PlayerStats.shootDelay -=0.1f;
        if (PlayerStats.shootDelay < 0.1f)
        {
            PlayerStats.shootDelay = 0.1f;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void UpgradeDamage()
    {
        PlayerStats.damage += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
