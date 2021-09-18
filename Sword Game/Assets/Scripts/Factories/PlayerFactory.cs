using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Not doing Singleton on purpose, in case of eventual multiplayer.
 */

public class PlayerFactory : MonoBehaviour
{
    [SerializeField] private GameObject playerAgent;

    public void SpawnPlayer(Vector3 pos, Quaternion rot)
    {
        Instantiate(playerAgent, pos, rot);
    }

    public float GetPlayerHeight()
    {
        return playerAgent.GetComponentInChildren<CapsuleCollider>().height;
    }

    public GameObject GetPlayerAgent()
    {
        return playerAgent;
    }
}
