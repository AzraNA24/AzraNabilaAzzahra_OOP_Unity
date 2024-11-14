using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder;
    private Weapon weapon;

    void Awake()
    {
        weapon = weaponHolder;
        Debug.Log($"WeaponPickup: Weapon {weapon.name}");
    }

    void Start()
    {
        if (weapon != null)
        {
            TurnVisual(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && weapon != null)
        {
            Player player = other.GetComponent<Player>();

            Debug.Log("Player receive weapon!");

            if (player.currentWeapon != null)
            {
                Debug.Log($"Player Change weapon from {player.currentWeapon.name} to {weapon.name}");
                player.currentWeapon.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log($"Player got weapon: {weapon.name}");
            }

            Weapon instantiate_Weapon = Instantiate(weapon, other.transform);
            instantiate_Weapon.transform.localPosition = Vector2.zero;
            instantiate_Weapon.transform.localRotation = Quaternion.identity;

            player.currentWeapon = instantiate_Weapon;
            TurnVisual(true, instantiate_Weapon);
        }
    }

    void TurnVisual(bool on)
    {
        weapon.gameObject.SetActive(on);
        Debug.Log($"WeaponPickup: Change weapon to {(on ? "active" : "nonactive")}");
    }

    void TurnVisual(bool on, Weapon weapon)
    {
        weapon.gameObject.SetActive(on);
        Debug.Log($"WeaponPickup: Change weapon {weapon.name} to {(on ? "active" : "nonactive")}");
    }
}
