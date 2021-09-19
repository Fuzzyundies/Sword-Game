using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileActivationFactory : MonoBehaviour
{
    //TO:DO load materials into Resources/Materials, and use Flyweight as a way to set/reset (OnDisable) the material back to the basic green.
    [SerializeField] private Material basicTileMaterial;
    [SerializeField] private Material trapTileMaterial;
    public void EnableRaisedTile(TileManager tile)
    {
        tile.SetTileState(E_TileState.Raised);
        tile.gameObject.GetComponent<Renderer>().material = basicTileMaterial;
        tile.gameObject.SetActive(true);
    }

    public void EnableBasicTile(TileManager tile)
    {
        tile.SetTileState(E_TileState.Basic);
        tile.gameObject.GetComponent<Renderer>().material = basicTileMaterial;
        tile.gameObject.SetActive(true);
    }

    public void EnableTrapTile(TileManager tile)
    {
        tile.SetTileState(E_TileState.Trap);
        tile.gameObject.GetComponent<Renderer>().material = trapTileMaterial;
        tile.gameObject.SetActive(true);
    }
}
