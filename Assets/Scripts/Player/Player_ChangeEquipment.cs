using UnityEngine;

public class Player_ChangeEquipment : MonoBehaviour
{
    public PlayerCombat combat;
    public Player_Bow bow;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ChangeEquipment"))
        {
            //combat.enabled = !combat.enabled;
            bow.enabled = !bow.enabled;
        }
    }
}
