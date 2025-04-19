using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    public GameObject[] statsSlots;

    private void Start()
    {
        AllUpdateStats();
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

    public void AllUpdateStats()
    {
        UpdateDamage();
        UpdateSpeed();
        UpdateCD();
        UpdateCR();

    }
}
