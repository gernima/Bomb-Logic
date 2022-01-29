using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Building building;
    private void OnMouseDrag()
    {
        BuildingsGrid.StartPlacingBuilding(building);
    }
}
