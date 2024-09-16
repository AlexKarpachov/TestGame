using UnityEngine;

public class BuildPoint : MonoBehaviour
{
    [SerializeField] Color hoverColor;
    [SerializeField] Vector3 positionOffset;

    BuildManager buildManager;
    public GameObject tower;
    Color startColor;
    Renderer rend;

    private void Start()
    {
        buildManager = BuildManager.Instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public Vector2 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    // called when the player clicks at this cell to build a tower
    private void OnMouseDown()
    {
        if (!buildManager.CanBuild) { return; } // checkes whether we can build here
        if (tower != null) // forbids building if there is another tower was build
        {
            Debug.Log("You cannot build here. TODO: Add some visual message that the player cannot build at this place");
            return;
        }
        buildManager.BuildTowerOn (this); // sends this game object to the build manager
    }
    private void OnMouseEnter()
    {
        if (!buildManager.CanBuild) { return; }
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
