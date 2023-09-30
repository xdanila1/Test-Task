using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    Inventory Inventory { get; }
    bool Overflowing { get; }
    public void PickUp(Item item, int count);
}
