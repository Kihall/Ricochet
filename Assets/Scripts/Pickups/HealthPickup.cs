using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : BasePickup
{
    [SerializeField] private int lifeAmount = 1;

    protected override void Pickup()
    {
        FailZone.Instance.GetExtraLife(lifeAmount);
    }
}
