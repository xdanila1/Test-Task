using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponModePanel : MonoBehaviour
{
    [SerializeField] private Image _singlemodeIcon;
    [SerializeField] private Image _automodeIcon;

    public MyBoolUnityEvent OnSetAutoMode;

    private bool _isAutoGun = true;

    public void SetStartMode(Weapon weapon)
    {
        if (weapon is GunItem gun)
        {
            _isAutoGun = gun.IsAutomatic;
            if (gun.IsAutomatic)
            {
                SetAutoMode();
                
                return;
            }
        }

        SetSingleMode();
    }
    public void SetSingleMode()
    {
        _singlemodeIcon.enabled = true;
        _automodeIcon.enabled = false;
        OnSetAutoMode.Invoke(false);
    }
    public void SetAutoMode()
    {
        if (!_isAutoGun) return;
        _singlemodeIcon.enabled = false;
        _automodeIcon.enabled = true;
        OnSetAutoMode.Invoke(true);
    }
}
