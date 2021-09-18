//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private TileFactory tileFactory;
    [SerializeField] private PlayerFactory playerFactory;

    private int rows;
    private int columns;

    [SerializeField] private int chanceForEmpty;
    [SerializeField] private int chanceForRaised;
    [SerializeField] private int chanceForTrap;
    [SerializeField] private int chanceForNormal;

    private double emptyTileCheck;
    private double raisedTileCheck;
    private double normalTileCheck;
    private double trapTileCheck;

    private int minChance;
    private int maxChance;

    private Vector3 tileSize;

    private List<GameObject> currentTileMap = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {

    }

    /*
     * 50% chance for normal "walkable tile" regardless of other percentages.
     */
    public void GenerateLevel(int rows, int columns)
    {
        this.rows = rows;
        this.columns = columns;
        double rolledValue;
        CreateCheckRanges();
        tileSize = tileFactory.GetTileSize();

        for (int i = 0; i < this.rows; i++)
        {
            for (int k = 0; k < this.columns; k++)
            {
                rolledValue = Random.value;
                if (rolledValue <= normalTileCheck)
                {
                    currentTileMap.Add(tileFactory.CreateBasicTile(new Vector3(i * tileSize.x, 0, k * tileSize.z), Quaternion.identity));
                }
                else
                {
                    currentTileMap.Add(CreateRandomChangedTile(i, 0, k));
                }
            }
        }

        Debug.Log(currentTileMap.Count);

        NavMeshBuilder.BuildNavMesh();

        SpawnPlayer();
    }
    // TO:DO needs to be flushed out to incorporate min/max chance, as well as ChangedTile weight
    private GameObject CreateRandomChangedTile(int i, int j, int k)
    {
        int randomValue = Random.Range(0, chanceForEmpty + chanceForRaised + chanceForTrap);
        if (randomValue <= chanceForRaised)
        {
            return (tileFactory.CreateRaisedTile(new Vector3(i * tileSize.x, j, k * tileSize.z), Quaternion.identity));
        }
        else if (randomValue <= chanceForRaised + chanceForEmpty)
        {
            return (tileFactory.CreateEmptyTile(new Vector3(i * tileSize.x, j, k * tileSize.z), Quaternion.identity));
        }
        else
            return (tileFactory.CreateTrapTile(new Vector3(i * tileSize.x, j, k * tileSize.z), Quaternion.identity));
    }

    private double convertIntoToPerct(int n)
    {
        return System.Math.Abs((double)(n % 100 / 100));
    }

    // TO:DO Needs to be flushed out once game is more flushed out
    // Idea is to allow for either user or in-game adjustments to the values and it would be wise to verify the values to make sure they work.
    // For now, it will just be assumed it won't be open to the user and will need to be implemented later.
    // Update the 0.5 to being a variable, but wait for a better picture on what to do.
    private void CreateCheckRanges()
    {
        emptyTileCheck = convertIntoToPerct(chanceForEmpty);
        
        raisedTileCheck = convertIntoToPerct(chanceForRaised);

        normalTileCheck = convertIntoToPerct(chanceForNormal);
        if (normalTileCheck <= 0.5)
            normalTileCheck = 0.5;

        trapTileCheck = convertIntoToPerct(chanceForTrap);
    }

    // Stephen style of code :-), wonder how memory efficient to return a constructor like this, and if it auto clears up/marked for garbage collecting.
    public Vector3 GetSpawnLocation(int i, GameObject agent)
    {
        return new Vector3(currentTileMap[i].transform.position.x, currentTileMap[i].transform.position.y + currentTileMap[i].GetComponent<BoxCollider>().bounds.size.y * 0.5f + agent.GetComponentInChildren<CapsuleCollider>().height * 0.5f, currentTileMap[i].transform.position.z);
    }

    public List<GameObject> GetTileList()
    {
        return currentTileMap;
    }

    private void SpawnPlayer()
    {
        bool spawned = false;
        while (!spawned)
        {
            int num = Random.Range(0, rows + columns);
            if (currentTileMap[num].activeSelf)
            {
                playerFactory.SpawnPlayer(GetSpawnLocation(num, playerFactory.GetPlayerAgent()), Quaternion.identity);
                spawned = true;
            }
        }
    }
}
