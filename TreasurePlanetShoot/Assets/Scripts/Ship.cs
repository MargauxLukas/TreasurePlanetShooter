using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ship", menuName = "GameScriptable/Create new Ship")]
public class Ship : ScriptableObject
{
    public string nom;
    public Sprite shipSprite;
    public int hitPoints;
    public Weapon weapon;
    public float speed;
    public int score, difficultyScore;

    public List<Vector2> wayPoints = new List<Vector2>();


}
