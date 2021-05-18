using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBehavior : MonoBehaviour
{
    Transform player;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private float rotationSpeed = 10;

    [SerializeField]
    private ShipPlaytimeStatue statue;

    private float currentCooldown;

    private void Start()
    {
        player = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        statue.TryToShoot();

        transform.RotateAround(player.position + offset, new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
        transform.right = new Vector3(0, 1, 0);
    }
}
