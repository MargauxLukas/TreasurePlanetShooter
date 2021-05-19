using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateDamage : MonoBehaviour
{
    private List<ShipPlaytimeStatue> shipInZone = new List<ShipPlaytimeStatue>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ShipPlaytimeStatue>() != null)
        {
            collision.GetComponent<ShipPlaytimeStatue>().TakeDamage(1, true);
            shipInZone.Add(collision.GetComponent<ShipPlaytimeStatue>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ShipPlaytimeStatue>() != null && shipInZone.Contains(collision.GetComponent<ShipPlaytimeStatue>()))
        {
            shipInZone.Add(collision.GetComponent<ShipPlaytimeStatue>());
        }
    }
}
