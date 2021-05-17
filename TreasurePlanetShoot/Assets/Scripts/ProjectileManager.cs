using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ShootingEventClass : UnityEvent<ShipPlaytimeStatue> { }

public class ProjectileManager : MonoBehaviour
{
    public GameObject projectilePrefab, projectileStock;

    public static List<MovableProjectile> allProjectiles;
    [HideInInspector]
    public List<MovableProjectile> allProjectilesLocal;

    private static ShootingEventClass shotEvent = new ShootingEventClass();

    private void Start()
    {
        allProjectiles = allProjectilesLocal;
        shotEvent.AddListener(ShootingEvent);
    }

    public static void Shoot(ShipPlaytimeStatue shooter)
    {
        shotEvent.Invoke(shooter);
    }

    void ShootingEvent(ShipPlaytimeStatue shooter)
    {
        StartCoroutine(ShootLazer(shooter));
    }

    [ContextMenu("Add Lazer")]
    public void AddLazerInScene()
    {
        for(int i = 0; i < 10; i++)
        {
            MovableProjectile newProjectile = Instantiate(projectilePrefab, new Vector3(10, 10, 0), Quaternion.identity, projectileStock.transform).GetComponent<MovableProjectile>();
            allProjectilesLocal.Add(newProjectile);
        }
    }

    [ContextMenu("Remove Lazer")]
    public void RemoveLazerInScene()
    {
        for (int i = 0; i < 10; i++)
        {
            if (allProjectilesLocal.Count > 0)
            {
                MovableProjectile newProjectile = allProjectilesLocal[allProjectilesLocal.Count - 1];
                allProjectilesLocal.RemoveAt(allProjectilesLocal.Count - 1);
                DestroyImmediate(newProjectile.gameObject);
            }
        }
    }

    IEnumerator ShootLazer(ShipPlaytimeStatue shooter)
    {
        for (int burst = 0; burst < shooter.weapon.burstNumber; burst++)
        {
            List<Vector2> newTargets = ProjectileDirections(shooter.weapon.projectileByBurst, shooter.weapon.angleBeetwenProjectile, shooter.shotDirection);

            for (int j = 0; j < newTargets.Count; j++)
            {
                for (int i = 0; i < allProjectiles.Count; i++)
                {
                    if (!allProjectiles[i].gameObject.activeSelf)
                    {
                        allProjectiles[i].Initialise(shooter.weapon, shooter, newTargets[j]);
                        break;
                    }
                }
            }

            yield return new WaitForSeconds(shooter.weapon.burstDelay);
        }
    }

    List<Vector2> ProjectileDirections(int nbProjectile, int angle, Vector2 startDirection)
    {
        List<Vector2> projectiles = new List<Vector2>();

        Vector2 newTraj = startDirection;
        Vector2 vecToAdd = newTraj;

        if (nbProjectile % 2 == 0)
        {
            vecToAdd = Quaternion.Euler(0, 0, -angle / 2) * newTraj;
        }

        projectiles.Add(vecToAdd);

        for (int i = 2; i <= nbProjectile; i++)
        {

            if (i % 2 == 0)
            {
                vecToAdd = Quaternion.Euler(0, 0, angle * (int)(i / 2)) * projectiles[0];

            }
            else
            {
                vecToAdd = Quaternion.Euler(0, 0, -angle * (int)(i / 2)) * projectiles[0];
            }
            projectiles.Add(vecToAdd);
        }

        return new List<Vector2>(projectiles);
    }
}

