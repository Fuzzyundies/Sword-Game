//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private TileCreationFactory tileCreationFactory;
    [SerializeField] private TileActivationFactory tileActivationFactory;
    [SerializeField] private PlayerFactory playerFactory;

    private int maxRows = 20;
    private int maxColumns = 20;
    private int minRows = 5;
    private int minColumns = 5;

    [SerializeField] private int activeRows;
    [SerializeField] private int activeColumns;

    private Vector3 tileSize;

    private GameObject[,] allTiles;
    private GameObject[,] activeTiles;

    [SerializeField] private int emptyChance;
    [SerializeField] private int raisedChance;
    [SerializeField] private int trappedChance;
    [SerializeField] private int basicChance;

    private int minBasicChance = 25;
    private int fullRange;

    private void Awake()
    {
        allTiles = new GameObject[maxRows, maxColumns];
    }

    public void CreateTileMap()
    {
        tileSize = tileCreationFactory.GetTileSize();

        for (int i = 0; i < maxRows; i++)
        {
            for (int j = 0; j < maxColumns; j++)
            {
                allTiles[i, j] = tileCreationFactory.CreateTile(new Vector3(i * tileSize.x, 0, j * tileSize.z), Quaternion.identity);
            }
        }
    }

    public void NewLevel()
    {
        NewLevel(Random.Range(minRows, maxRows), Random.Range(minColumns, maxColumns));
    }

    public void NewLevel(int rows, int columns)
    {
        SetValues();
        activeRows = rows;
        activeColumns = columns;
        activeTiles = new GameObject[activeRows, activeColumns];

        for (int i = 0; i < rows; i++)
        {
            for (int k = 0; k < columns; k++)
            {
                EnableTile(i, k);
            }
        }

        NavMeshBuilder.BuildNavMesh();
        SpawnPlayer();
    }

    private void SetValues()
    {
        if (basicChance < minBasicChance)
            basicChance = minBasicChance;

        fullRange = basicChance + emptyChance + raisedChance + trappedChance;
    }

    //There is a better way/cleaner way of doing this, but it works for now. Goes through basic then empty, raised, and finally trapped. Able to be added onto later for different types.
    private void EnableTile(int row, int column)
    {
        int randomValue = Random.Range(0, fullRange);

        if (randomValue <= basicChance)
        {
            tileActivationFactory.EnableBasicTile(allTiles[row, column].GetComponent<TileManager>());
        }
        else
        {
            randomValue -= basicChance;
            
            if (randomValue <= emptyChance)
            {
                ; //No need for it to do anything. Will be added to the currentTileMap regardless.
            }
            else
            {
                randomValue -= emptyChance;

                if (randomValue <= raisedChance)
                {
                    tileActivationFactory.EnableRaisedTile(allTiles[row, column].GetComponent<TileManager>());
                }
                else
                {
                    randomValue -= raisedChance;

                    if (randomValue <= trappedChance)
                    {
                        tileActivationFactory.EnableTrapTile(allTiles[row, column].GetComponent<TileManager>());
                    }
                    else
                    {
                        Debug.LogWarning("Type of tile not enabled");
                    }
                }
            }
        }
        activeTiles[row,column] = allTiles[row, column];
    }

    // Stephen style of code, wonder how memory efficient to return a constructor like this.
    public Vector3 GetAgentSpawnLocation(int row, int column, GameObject agent)
    {
        return new Vector3(activeTiles[row,column].transform.position.x, activeTiles[row, column].transform.position.y + activeTiles[row, column].GetComponent<BoxCollider>().bounds.size.y * 0.5f + agent.GetComponentInChildren<CapsuleCollider>().height * 0.5f, activeTiles[row, column].transform.position.z);
    }

    // TO:DO make a more intelligent spawner.
    private void SpawnPlayer()
    {
        bool spawned = false;
        while (!spawned)
        {
            int row = Random.Range(0, activeRows);
            int column = Random.Range(0, activeColumns);
            if (activeTiles[row,column].activeSelf)
            {
                playerFactory.SpawnPlayer(GetAgentSpawnLocation(row, column, playerFactory.GetPlayerAgent()), Quaternion.identity);
                spawned = true;
            }
        }
    }
}
