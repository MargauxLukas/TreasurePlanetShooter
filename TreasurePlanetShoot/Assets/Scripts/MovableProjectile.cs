using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableProjectile : MonoBehaviour
{
    private Vector3 direction;
    private float speed = 5;

    [SerializeField]
    private bool isEnnemy = true;
    private float damage = 1;

    private Vector3 startPos;

    [SerializeField]
    private SpriteRenderer sprite = default;

    private void Start()
    {
        startPos = transform.position;
        gameObject.SetActive(false);
    }

    public void Initialise(Weapon newWeapon, ShipPlaytimeStatue shooter, Vector2 lazerDirection)
    {
        sprite.sprite = newWeapon.projectileSprite;
        direction = lazerDirection;
        speed = newWeapon.projectileSpeed;

        if (shooter.isPlayer && shooter.isAlly)
        {
            transform.position = shooter.gameObject.GetComponent<ShipController>().canon.transform.position;
        }
        else
        {
            transform.position = shooter.transform.position;
        }
        isEnnemy = !shooter.isPlayer;
        damage = newWeapon.damage;

        transform.up = direction;
        gameObject.SetActive(true);
    }

    public void DestroyLazer()
    {
        direction = Vector3.zero;
        speed = 0;
        transform.position = startPos;
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        transform.position += direction * speed * Time.fixedDeltaTime;

        if (transform.position.x < -8.6f || transform.position.x > 8.6f || transform.position.y < -4.6f || transform.position.y > 4.6f)
        {
            DestroyLazer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ShipPlaytimeStatue>() != null)
        {
            if (collision.GetComponent<ShipPlaytimeStatue>().TakeDamage(damage, isEnnemy))
            {
                GetComponent<Animator>().Play("ProjectileExplosion");
            }
        }
    }
}

