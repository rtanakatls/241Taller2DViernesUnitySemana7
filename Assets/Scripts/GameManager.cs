using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private GameObject[] enemies;
    [SerializeField] private GameObject upgradeMenu;

    public static GameManager Instance
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

    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Update()
    {
        foreach(GameObject obj in enemies)
        {
            if (obj!=null)
            {
                return;
            }
        }

        upgradeMenu.SetActive(true);
    }

}
