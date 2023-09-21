using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public abstract string Name { get;}
    string Description { get; }
    Texture2D Icon { get; }
    bool IsStored { get; }

}
