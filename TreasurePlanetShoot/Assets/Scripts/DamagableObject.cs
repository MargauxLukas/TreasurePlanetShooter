using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableObject : MonoBehaviour
{
    [SerializeField]
    private bool isAlly;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<ShipPlaytimeStatue>() != null)
        {
            collision.GetComponent<ShipPlaytimeStatue>().TakeDamage(1, !isAlly);
        }
    }
}
