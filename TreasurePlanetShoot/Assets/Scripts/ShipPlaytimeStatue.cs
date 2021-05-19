using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipPlaytimeStatue : MonoBehaviour
{
    [SerializeField]
    private float health, maxHealth = 50;
    public bool isPlayer;
    public bool isAlly;

    public Vector2 shotDirection;

    public Ship baseShip;
    [HideInInspector]
    public Weapon weapon;

    private float currentCooldown;
    private float currentUltiCharge = 0;

    [SerializeField]
    private Image healthBar, ultiBar;

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

    public bool TakeDamage(float dmg, bool isEnemyProjectile)
    {
        if (!isAlly && isEnemyProjectile == isPlayer && invulnerabilityLeft <= 0)
        {
            if(isPlayer)
            {
                invulnerabilityLeft = 2;
                GetComponent<Animator>().Play("PlayerInvulnerabilityFeedback");
            }
            if (health > 0)
            {
                health -= dmg;
                if (health <= 0)
                {
                    Die();
                }
                if (healthBar != null)
                {
                    healthBar.fillAmount = health / maxHealth;
                }
            }
            return true;
        }
        else if(isAlly)
        {
            return isEnemyProjectile;
        }
        else
        {
            return false;
        }
    }

    private void Die()
    {
        GetComponent<Animator>().Play("Explosion");
        currentCooldown = -99;
        if (isPlayer)
        {
            UIManager.instance.LoseLevel();
        }
        else
        {
            if(baseShip.dropOnDeath != null)
            {
                Instantiate(baseShip.dropOnDeath, transform.position, Quaternion.identity, transform.parent);
            }
        }
    }

    public bool IsAlive => health > 0;

    //Appelé lors d'un Event d'animation
    private void DisableObject()
    {
        gameObject.SetActive(false);
    }

    public void TryToShoot()
    {
        if (currentCooldown >= weapon.recoveryTime && health > 0)
        {
            ProjectileManager.Shoot(this);
            currentCooldown = 0;
        }
    }

    public void AddUltiCharge(float value)
    {
        if(currentUltiCharge < 1 && currentUltiCharge+value >= 1)
        {
            GetComponent<Animator>().Play("UltiUp");
        }
        currentUltiCharge += value;
        if(currentUltiCharge >= 1)
        {
            currentUltiCharge = 1;
        }
        ultiBar.fillAmount = currentUltiCharge;
    }

    public bool CanUseUlti()
    {
        return currentUltiCharge == 1;
    }

    public void UseUlti()
    {
        currentUltiCharge = 0;
        ultiBar.fillAmount = currentUltiCharge;
    }
}
