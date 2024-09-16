using UnityEngine;

// here we choose the tower to build by clicking at the buttons in UI
public class Shop : MonoBehaviour
{
    [SerializeField] Bank bank;

    BuildManager buildManager;

    public TowerData archerTower; // receives the data (prefab and cost) for the archer tower
    public TowerData bigArcherTower; // receives the data (prefab and cost) for the big archer tower

    private void Start()
    {
        buildManager = BuildManager.Instance;
    }

    // tells our build manager that we want to build archer tower
    public void SelectArcherTower()
    {
        buildManager.SelectTowerToBuild(archerTower);
    }

    // tells our build manager that we want to build big archer tower
    public void SelectBigArcherTower()
    {
        buildManager.SelectTowerToBuild(bigArcherTower);
    }
}
