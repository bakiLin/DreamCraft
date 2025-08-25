using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private Image healthImage;

    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private WeaponHolder weaponHolder;

    public void Hit(float damage)
    {
        healthImage.fillAmount -= damage;
        if (healthImage.fillAmount == 0f)
        {
            Time.timeScale = 0f;
            weaponHolder.GameOver();
            gameOver.SetActive(true);
        }
    }
}
