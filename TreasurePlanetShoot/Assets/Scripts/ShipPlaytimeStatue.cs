using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipPlaytimeStatue : MonoBehaviour
{
    private float health, maxHealth = 50;
    public bool isPlayer;
    public bool isAlly;

    public Vector2 shotDirection;

    public Ship baseShip;
    [HideInInspector]
    public Weapon weapon;

    private float currentCooldown;

    [SerializeField]
    private Image healthBar = default;

    float invulnerabilityLeft = 0;

    private void Start()
    {
        ResetValue();
    }

    public void ResetValue()
    {
        maxHealth = baseShip.hitPoints;
        health = maxHealth;
        weapon = baseShip.weapon;
        currentCooldown = weapon.recoveryTime;
    }

    private void Update()
    {
        currentCooldown += Time.deltaTime;
        if(invulnerabilityLeft > 0)
        {
            invulnerabilityLeft -= Time.deltaTime;
        }
    }

    public bool TakeDamage(float dmg, bool isPlayerProjectile)
    {
        if (!isAlly && isPlayerProjectile != isPlayer && invulnerabilityLeft <= 0)
        {
            if(isPlayer)
            {
                invulnerabilityLeft = 2;
            }

            health -= dmg;
            if (health <= 0)
            {
                Die();
            }
            if (healthBar != null)
            {
                healthBar.fillAmount = health / maxHealth;
            }
            return true;
        }
        return isAlly;
    }

    private void Die()
    {
        if (isPlayer)
        {
            //T_ScoreManager.instance.EndGame();
        }
        else
        {
            //T_ScoreManager.instance.AddScore(baseShip.score, baseShip.difficultyScore);
            gameObject.SetActive(false);
        }
    }

    public void TryToShoot()
    {
        if (currentCooldown >= weapon.recoveryTime)
        {
            ProjectileManager.Shoot(this);
            currentCooldown = 0;
        }
    }

    public bool IsCooldownReady()
    {
        return (currentCooldown >= weapon.recoveryTime);
    }
}
