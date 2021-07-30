using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFactory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject basicTile;
    public GameObject CreateBasicTile()
    {
        GameObject tile = Instantiate(basicTile);
        tile.SetActive(true);
        return tile;
    }

    public GameObject CreateEmptyTile()
    {
        GameObject tile = Instantiate(basicTile);
        tile.SetActive(false);
        return tile;
    }

    public GameObject CreateRaisedTile()
    {
        GameObject tile = Instantiate(basicTile);
        tile.SetActive(true);
        return tile;
    }
}
