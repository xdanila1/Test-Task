using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InventoryCell))]
public class WeaponCell : MonoBehaviour
{
    
    private Weapon _weapon;

    public MyWeaponUnityEvent onChangeWeapon;

    // Start is called before the first frame update
    void Start()
    {
        _weapon = (Weapon)GetComponent<InventoryCell>().Item;
    }

    public void SetWeapon()
    {
        onChangeWeapon.Invoke(_weapon);
    }
}
