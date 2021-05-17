using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBehavior : MonoBehaviour
{
    Transform player;

    [SerializeField]
    private float rotationSpeed = 10;

    [SerializeField]
    private Weapon allyWeapon;

    private float currentCooldown;

    private void Start()
    {
        player = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        currentCooldown += Time.deltaTime;
        if(currentCooldown>=allyWeapon.recoveryTime)
        {
            
        }

        transform.RotateAround(player.position, new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
        transform.right = new Vector3(0, 1, 0);
    }
}
