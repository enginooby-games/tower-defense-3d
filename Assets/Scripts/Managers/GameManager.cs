using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [Header("STATS")]
    [SerializeField] int maxHeath = 20;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI healthLabel;

    private int currentHeath;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Init()
    {
        currentHeath = maxHeath;
        UpdateHealthLabel();
    }

    public void UpdateHealth(int amount)
    {
        currentHeath += amount;
        UpdateHealthLabel();
    }

    private void UpdateHealthLabel()
    {
        healthLabel.text = "Health: " + currentHeath + "/" + maxHeath;
    }
}
