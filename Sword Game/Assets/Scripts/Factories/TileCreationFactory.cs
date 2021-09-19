using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCreationFactory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject basicTile;

    public GameObject CreateTile(Vector3 spawn, Quaternion rotation)
    {
        GameObject tile = Instantiate(basicTile, spawn, rotation);
        tile.SetActive(false);
        return tile;
    }

    public Vector3 GetTileSize()
    {
        return basicTile.transform.localScale;
    }
}
