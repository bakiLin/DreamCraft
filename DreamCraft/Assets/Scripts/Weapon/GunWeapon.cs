using UnityEngine;

public class GunWeapon : IWeapon
{
    public void Shoot(ref bool shoot)
    {
        Debug.Log("shoot");
        shoot = false;
    }
}
