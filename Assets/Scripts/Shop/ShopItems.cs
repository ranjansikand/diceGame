// Just a list of items


using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Die", menuName = "Items/ItemList", order = 2)]
public class ShopItems : ScriptableObject
{
    public List<Item> items;
}
