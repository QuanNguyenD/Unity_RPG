using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    public GameObject[] statsSlots;
    public CanvasGroup ststsCanvas;

    public static StatsUI Instance;

    private bool statsOpen = false;

    private void Start()
    {
        AllUpdateStats();
    }



    private void Update()
    {
        if (Input.GetButtonDown("ToggleStats"))
        {
            if (statsOpen)
            {
                Time.timeScale = 1;
                ststsCanvas.alpha = 0;
                statsOpen = false;
            }


            else 
            {
                Time.timeScale = 0;
                ststsCanvas.alpha = 1;
                statsOpen = true;
            }
            
        }

        if (statsOpen) 
        {
            AllUpdateStats();
        }

    }

    public void UpdateDamage()
    {
        statsSlots[0].GetComponentInChildren<TMP_Text>().text = "Damege: " + StatsManagerment.Instance.damage;
    }
    public void UpdateSpeed()
    {
        statsSlots[1].GetComponentInChildren<TMP_Text>().text = "Speed: " + StatsManagerment.Instance.speed;
    }

    public void UpdateCD()
    {
        statsSlots[2].GetComponentInChildren<TMP_Text>().text = "CRIT DMG: " + StatsManagerment.Instance.CD;
    }

    public void UpdateCR()
    {
        statsSlots[3].GetComponentInChildren<TMP_Text>().text = "CRIT RATE: " + StatsManagerment.Instance.CR;
    }

    public void UpdateDEF()
    {
        statsSlots[4].GetComponentInChildren<TMP_Text>().text = "DEF: " + StatsManagerment.Instance.DEF;
    }
    public void UpdateAPen()
    {
        statsSlots[5].GetComponentInChildren<TMP_Text>().text = "Flat Pen: " + StatsManagerment.Instance.Flat_Pen;
    }

    public void UpdatePercPen()
    {
        statsSlots[6].GetComponentInChildren<TMP_Text>().text = "%Armor Pen: " + StatsManagerment.Instance.Perc;
    }

    public void AllUpdateStats()
    {
        UpdateDamage();
        UpdateSpeed();
        UpdateCD();
        UpdateCR();
        UpdateDEF();    
        UpdateAPen();
        UpdatePercPen();

    }
}
