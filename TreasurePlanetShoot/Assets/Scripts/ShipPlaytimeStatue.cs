using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipPlaytimeStatue : MonoBehaviour
{
    private float health, maxHealth = 50;
    public bool isPlayer;

    [HideInInspector]
    public Vector2 shotDirection;

    public Ship baseShip;
    [HideInInspector]
    public Weapon weapon;

    private float currentCooldown;

    [SerializeField]
    private Image healthBar = default;

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
    }

    public bool TakeDamage(float dmg, float bonusDamage, bool isAlly)
    {
        if (isAlly == isPlayer)
        {
            Debug.Log("TakeDmg");
            health -= dmg + bonusDamage;// * T_ScoreManager.instance.currentDifficulty;
            if (health <= 0)
            {
                Die();
            }
            if (healthBar != null)
            {
                healthBar.fillAmount = (maxHealth - health) / maxHealth;
            }
            return true;
        }
        return false;
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
