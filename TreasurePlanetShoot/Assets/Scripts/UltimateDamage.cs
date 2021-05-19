using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateDamage : MonoBehaviour
{
    private List<ShipPlaytimeStatue> shipInZone = new List<ShipPlaytimeStatue>();

    private float timeBeforeTick;

    private void OnEnable()
    {
        timeBeforeTick = 0.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ShipPlaytimeStatue>() != null)
        {
            shipInZone.Add(collision.GetComponent<ShipPlaytimeStatue>());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<ShipPlaytimeStatue>() != null && !shipInZone.Contains(collision.GetComponent<ShipPlaytimeStatue>()))
        {
            shipInZone.Add(collision.GetComponent<ShipPlaytimeStatue>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ShipPlaytimeStatue>() != null && shipInZone.Contains(collision.GetComponent<ShipPlaytimeStatue>()))
        {
            shipInZone.Remove(collision.GetComponent<ShipPlaytimeStatue>());
        }
    }

    private void Update()
    {
        if(timeBeforeTick < 0)
        {
            Debug.Log("Tick");
            timeBeforeTick = 0.5f;
            foreach (ShipPlaytimeStatue ship in shipInZone)
            {

                Debug.Log("Ship : " + ship.TakeDamage(5, false));
            }
        }
        else
        {
            timeBeforeTick -= Time.deltaTime;
        }
    }
}
