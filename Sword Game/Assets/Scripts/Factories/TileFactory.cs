using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFactory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject basicTile;
    public GameObject CreateBasicTile(Vector3 spawn, Quaternion rotation)
    {
        GameObject tile = Instantiate(basicTile, spawn, rotation);
        tile.SetActive(true);
        return tile;
    }

    public GameObject CreateEmptyTile(Vector3 spawn, Quaternion rotation)
    {
        GameObject tile = Instantiate(basicTile, spawn, rotation);
        tile.SetActive(false);
        return tile;
    }

    public GameObject CreateRaisedTile(Vector3 spawn, Quaternion rotation)
    {
        Vector3 raisedSpawn = new Vector3(spawn.x, spawn.y + 1f, spawn.z);
        GameObject tile = Instantiate(basicTile, raisedSpawn, rotation);
        tile.SetActive(true);
        return tile;
    }

    public Vector3 GetTileSize()
    {
        return basicTile.transform.localScale;
    }
}
