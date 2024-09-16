using UnityEngine;

// the script keeps tower prefabs and their prices. Any additional info may be added.

// this command makes the class visible in the inspector from the Shop class that has a reference to this one.
[System.Serializable]
public class TowerData
{
    public GameObject towerPrefub;
    public int cost;
}
