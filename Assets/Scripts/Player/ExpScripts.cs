using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ExpScripts : MonoBehaviour
{
    public int level;
    public int curentEXP;
    public int expToLevel = 10;
    public float expGrow = 1.2f;

    public Slider expSlider;
    public TMP_Text currentLevelText;

    public static event Action<int> OnLevelUp;


    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GainEXP(2);
        }  
    }

    private void OnEnable()
    {
        Enemy_Heath.onMonsterdefeated += GainEXP;
    }

    private void OnDisable()
    {
        Enemy_Heath.onMonsterdefeated -= GainEXP;
    }
    public void GainEXP(int amount)
    {
        curentEXP += amount;
        if (curentEXP >= expToLevel)
        {
            LevelUp();
        }
        UpdateUI();
    }

    private void LevelUp()
    {
        level++;
        curentEXP -=expToLevel;
        expToLevel = Mathf.RoundToInt(expToLevel * expGrow);
        OnLevelUp?.Invoke(1);
    }

    public void UpdateUI()
    {
        expSlider.maxValue = expToLevel;
        expSlider.value = curentEXP;
        currentLevelText.text = "Level: " + level;
    }
}
