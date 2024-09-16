using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] Bank bank;

    TowerData towerToBuild;

    public GameObject archerTowerPrefab;
    public GameObject bigArcherTowerPrefab;
    public static BuildManager Instance;
    public bool CanBuild { get { return towerToBuild != null; } }

    private void Awake()
    {
        Instance = this; // here we created Singleton as we have only one such instance in the game
    }

    // the parameter receives the data from the cell, we want to build at
    public void BuildTowerOn(BuildPoint buildPoint) 
    {
        if (bank.CurrentBalance < towerToBuild.cost) // checks whether we have enough money to build the chosen tower
        {
            Debug.Log("Not enough money. TODO: make some visual message in the UI");
            return; 
        }

        bank.MoneyWithdrawal(towerToBuild.cost);
        GameObject tower = Instantiate(towerToBuild.towerPrefub, buildPoint.GetBuildPosition(), Quaternion.identity);
        buildPoint.tower = tower; // set the tower on the chosen point and blocks it for the future attemts to build here.
    }

    // receives tower type and its price from the store
    public void SelectTowerToBuild(TowerData towerData)
    {
        towerToBuild = towerData;
    }
}
