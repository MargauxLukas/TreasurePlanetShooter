using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    protected virtual void ApplyEffect()
    {
        Debug.Log("Collected !");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ShipPlaytimeStatue>() != null && collision.GetComponent<ShipPlaytimeStatue>().isPlayer)
        {
            ApplyEffect();
            gameObject.SetActive(false);
        }
    }
}
