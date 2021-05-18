using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingLevelZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<ShipController>() != null)
        {
            UIManager.instance.EndLevel();
        }
    }
}
