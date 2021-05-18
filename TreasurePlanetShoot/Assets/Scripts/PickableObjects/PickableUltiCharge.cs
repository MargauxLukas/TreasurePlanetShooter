using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableUltiCharge : PickableObject
{
    protected override void ApplyEffect(ShipPlaytimeStatue ship)
    {
        ship.AddUltiCharge(0.25f);
    }
}
