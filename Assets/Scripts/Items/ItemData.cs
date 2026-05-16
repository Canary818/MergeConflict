using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "ItemData", menuName ="MergeConflict/ItemData",  order = 1)]
public class ItemData : ScriptableObject
{
    public uint ID; 
    public Sprite sprite;
    public string itemName;
    public string desc;

    void Init()
    {
    }
}
