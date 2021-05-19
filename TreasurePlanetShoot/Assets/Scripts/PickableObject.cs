using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    protected virtual void ApplyEffect(ShipPlaytimeStatue ship)
    {
        Debug.Log("Collected !");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ShipPlaytimeStatue>() != null && collision.GetComponent<ShipPlaytimeStatue>().isPlayer && !collision.GetComponent<ShipPlaytimeStatue>().isAlly)
        {
            ApplyEffect(collision.GetComponent<ShipPlaytimeStatue>());
            audioSource.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
