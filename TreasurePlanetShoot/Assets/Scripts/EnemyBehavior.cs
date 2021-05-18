using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBehavior : MonoBehaviour
{
    private Ship baseStatue;

    [SerializeField]
    private ShipPlaytimeStatue playtimeStatue = default;

    private int wayIndex = 0;

    private Vector3 localPos = Vector3.zero, direction = Vector3.zero, nextTarget = Vector3.zero;

    private void OnEnable()
    {
        SetEnnemy(playtimeStatue.baseShip);
    }

    public void SetEnnemy(Ship newStatue)
    {
        GetComponent<SpriteRenderer>().sprite = newStatue.shipSprite;
        baseStatue = newStatue;
        playtimeStatue.baseShip = newStatue;
        ShipReset();
        transform.up = new Vector3(-1, 0, 0);
    }

    public void ShipReset()
    {
        playtimeStatue.ResetValue();
        wayIndex = 0;
        localPos = Vector3.zero;
        direction = Vector3.zero;
        nextTarget = Vector3.zero;
    }

    private void Update()
    {
        if (transform.position.x < 8.5f)
        {
            if (Vector2.Distance(localPos, nextTarget) < 0.1f)
            {
                wayIndex++;
                wayIndex %= baseStatue.wayPoints.Count;
                nextTarget = baseStatue.wayPoints[wayIndex];
            }

            direction = (nextTarget - localPos).normalized;

            localPos += direction * baseStatue.speed * Time.deltaTime;

            transform.position += direction * baseStatue.speed * Time.deltaTime;
            if (transform.position.x < 8.2f)
            {
                playtimeStatue.TryToShoot();
            }
        }
    }
}
