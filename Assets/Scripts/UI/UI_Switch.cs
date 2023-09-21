using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Switch : MonoBehaviour
{
    public void SwitchUI(GameObject UIElement) => UIElement.SetActive(!UIElement.activeSelf);

}
