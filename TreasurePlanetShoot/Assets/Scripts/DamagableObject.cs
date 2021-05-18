using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<ShipPlaytimeStatue>() != null && collision.GetComponent<ShipPlaytimeStatue>().isPlayer)
        {
            collision.GetComponent<ShipPlaytimeStatue>().TakeDamage(1, false);
        }
    }
}
