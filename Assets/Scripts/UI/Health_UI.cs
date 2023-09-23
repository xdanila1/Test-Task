using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_UI : MonoBehaviour
{

    [SerializeField] Gradient _gradientHP;

    private Image _imageHealth;

    
    void Start()
    {
        _imageHealth = GetComponent<Image>();
    }


    public void UpdateUI(float num)
    {
        _imageHealth.fillAmount = num;
        _imageHealth.color = _gradientHP.Evaluate(_imageHealth.fillAmount);
    }
}
