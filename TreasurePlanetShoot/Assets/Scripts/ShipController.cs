using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    //On the Scriptable
    private float acceleration = 0.02f, maxSpeed = .1f;

    [SerializeField]
    private GameObject canon;

    //On the GO
    private Vector2 newShotDirection;
    private Vector3 moveDirection, inertieDirection, nextPosition;
    [SerializeField]
    private Camera cam = default;

    private float currentInertieX, currentInertieY;

    public ShipPlaytimeStatue currentStatue;

    /*private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = currentStatue.baseShip.shipSprite;
    }*/

    // Update is called once per frame
    void FixedUpdate()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;

        currentInertieX = Mathf.Lerp(currentInertieX, moveDirection.x * maxSpeed * 2, acceleration);

        if (currentInertieX < acceleration / 50 && currentInertieX > -acceleration / 50)
        {
            currentInertieX = 0;
        }

        currentInertieY = Mathf.Lerp(currentInertieY, moveDirection.y * maxSpeed * 2, acceleration);
        if (currentInertieY < acceleration / 50 && currentInertieY > -acceleration / 50)
        {
            currentInertieY = 0;
        }

        inertieDirection = new Vector3(currentInertieX, currentInertieY, 0);


        nextPosition = transform.position + inertieDirection;
        nextPosition = new Vector3(Mathf.Clamp(nextPosition.x, -9, 9), Mathf.Clamp(nextPosition.y, -5, 5), 0);

        transform.position = nextPosition;
    }

    private void Update()
    {
        newShotDirection = (cam.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        if(Vector2.Angle(newShotDirection, transform.up) < 75 && Vector2.Angle(newShotDirection, transform.up) > -75)
        {
            currentStatue.shotDirection = newShotDirection;
            canon.transform.up = newShotDirection;
        }

        if (Input.GetMouseButton(0))
        {
            currentStatue.TryToShoot();
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        inertieDirection /= 10;
        Debug.Log("Collis");
        currentStatue.TakeDamage(10, 0, false);
    }*/
}
