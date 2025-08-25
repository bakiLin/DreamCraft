using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    private Shooter shooter;

    private IWeapon weapon;

    private GunWeapon gunWeapon = new GunWeapon();

    private RifleWeapon rifleWeapon = new RifleWeapon();

    private bool shoot;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
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
            shooter.Shoot();
        }
    }

    private void StartShoot()
    {
        shoot = true;
        shooter.ResetTimer();
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

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        enabled = false;
    }
}
