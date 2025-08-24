using UnityEngine;

public class RifleWeapon : IWeapon
{
    public void Shoot(ref bool shoot)
    {
        Debug.Log("shoot");
    }
}
