using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TO:DO Implement Command design pattern for when an agent steps on the tile.
public class TileManager : MonoBehaviour
{
    [SerializeField] private E_TileState tileState;

    public void Awake()
    {
        tileState = E_TileState.Off;
    }

    public void SetTileState(E_TileState newState)
    {
        tileState = newState;
    }

    private void OnDisable()
    {
        if (tileState == E_TileState.Raised)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - gameObject.transform.localScale.y, gameObject.transform.position.z);
        tileState = E_TileState.Off;
    }

    private void OnEnable()
    {
        if (tileState == E_TileState.Raised)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + gameObject.transform.localScale.y, gameObject.transform.position.z);
    }
}
