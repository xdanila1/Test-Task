using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyFloatUnityEvent : UnityEvent<float> { }
[System.Serializable]
public class MyBoolUnityEvent : UnityEvent<bool> { }
[System.Serializable]
public class MyWeaponUnityEvent : UnityEvent<Weapon> { }
[System.Serializable]
public class MyIntUnityEvent : UnityEvent<int> { }


