using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingsGrid : MonoBehaviour
{
    public Vector2Int GridSize = new Vector2Int(10, 10);
    public Tilemap[] blockTilemaps;
    public Building mt;

    private Building[,] grid;
    private static Building flyingBuilding;
    private GameObject item;
    private Camera mainCamera;

    private void OnDrawGizmosSelected()
    {
        for (int x = 0; x < GridSize.x; x++)
        {
            for (int y = 0; y < GridSize.y; y++)
            {
                if ((x + y) % 2 == 0) Gizmos.color = new Color(0.88f, 0f, 1f, 0.3f);
                else Gizmos.color = new Color(1f, 0.68f, 0f, 0.3f);

                Gizmos.DrawCube(transform.position + new Vector3(x, y, 0), new Vector3(1, 1, .1f));
            }
        }
    }
    private void Awake()
    {
        grid = new Building[GridSize.x, GridSize.y];

        foreach (Tilemap tilemap in blockTilemaps)
        {
            BoundsInt bounds = tilemap.cellBounds;
            TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

            for (int x = 0; x < bounds.size.x; x++)
            {
                for (int y = 0; y < bounds.size.y; y++)
                {
                    TileBase tile = allTiles[x + y * bounds.size.x];
                    if (tile != null)
                    {
                        //Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                        grid[x, y] = mt;
                    }
                }
            }
        }

        mainCamera = Camera.main;
    }
    public void SetItem(GameObject _item)
    {
        item = _item;
    }
    public static void StartPlacingBuilding(Building buildingPrefab)
    {
        if (flyingBuilding != null)
        {
            Destroy(flyingBuilding.gameObject);
        }

        flyingBuilding = Instantiate(buildingPrefab);
        //flyingBuilding.transform.position = new Vector3(0, 0, 0);
        flyingBuilding.isPlaced = false;
    }

    private void Update()
    {
        if (flyingBuilding != null)
        {
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;
            
            int x = Mathf.RoundToInt(worldPosition.x);
            int y = Mathf.RoundToInt(worldPosition.y);

            bool available = true;

            if (x < 0 || x > GridSize.x - flyingBuilding.Size.x) available = false;
            if (y < 0 || y > GridSize.y - flyingBuilding.Size.y) available = false;

            if (available && IsPlaceTaken(x, y)) available = false;

            flyingBuilding.transform.position = new Vector3(x, y, 0);
            flyingBuilding.SetTransparent(available);

            if (available && Input.GetMouseButtonDown(0))
            {
                flyingBuilding.isPlaced = true;
                PlaceFlyingBuilding(x, y);
            }
        }
    }

    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                if (grid[placeX + x, placeY + y] != null) return true;
            }
        }
        return false;
    }

    private void PlaceFlyingBuilding(int placeX, int placeY)
    {
        for (int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                grid[placeX + x, placeY + y] = flyingBuilding;
            }
        }
        if (item)
        {
            Destroy(item);
        }
        flyingBuilding.SetNormal();
        flyingBuilding = null;
    }
}
