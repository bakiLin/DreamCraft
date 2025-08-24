using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private PlayerInput playerInput;

    private IWeapon weapon;

    private GunWeapon gunWeapon = new GunWeapon();

    private RifleWeapon rifleWeapon = new RifleWeapon();

    private bool shoot;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        weapon = gunWeapon;
    }

    private void OnEnable()
    {
        playerInput.OnStartShoot += StartShoot;
        playerInput.OnStopShoot += StopShoot;
        playerInput.OnChangeWeapon += ChangeWeapon;
    }

    private void OnDisable()
    {
        playerInput.OnStartShoot -= StartShoot;
        playerInput.OnStopShoot -= StopShoot;
        playerInput.OnChangeWeapon -= ChangeWeapon;
    }

    private void Update()
    {
        if (shoot)
        {
            weapon.Shoot(ref shoot);
        }
    }

    private void StartShoot()
    {
        shoot = true;
    }

    private void StopShoot()
    {
        shoot = false;
    }

    private void ChangeWeapon()
    {
        if (!shoot)
        {
            if (weapon == gunWeapon) weapon = rifleWeapon;
            else weapon = gunWeapon;
        }
    }
}
