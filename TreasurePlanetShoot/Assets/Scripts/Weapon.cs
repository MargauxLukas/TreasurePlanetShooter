using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "GameScriptable/Create new Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    public string nom;
    public Sprite projectileSprite;

    public float recoveryTime, projectileSpeed, damage, damageByDifficulty, burstDelay;
    public int burstNumber, projectileByBurst, angleBeetwenProjectile;
}
