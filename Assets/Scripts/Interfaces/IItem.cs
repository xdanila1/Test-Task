using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    string Name { get;}
    string Description { get; }
    Sprite Icon { get; }
    bool IsStored { get; }

}
