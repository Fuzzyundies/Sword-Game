//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private TileFactory tileFactory;

    [SerializeField] private int rows;
    [SerializeField] private int columns;

    [SerializeField] private int chanceForEmpty;
    [SerializeField] private int chanceForRaised;
    [SerializeField] private int chanceForNormal;

    private double emptyTileCheck;
    private double raisedTileCheck;
    private double normalTileCheck;

    private int minChance;
    private int maxChance;

    private Vector3 tileSize;

    // Start is called before the first frame update
    void Awake()
    {
        GenerateLevel();
    }

    /*
     * 50% chance for normal "walkable tile" regardless of other percentages.
     */
    public void GenerateLevel()
    {
        double rolledValue;
        CreateCheckRanges();
        GetTileSize();
        


        for (int i = 0; i < rows; i++)
        {
            for (int k = 0; k < columns; k++)
            {
                rolledValue = Random.value;
                Debug.Log(rolledValue);
                if (rolledValue <= normalTileCheck)
                {
                    tileFactory.CreateBasicTile(new Vector3(i * tileSize.x, 0, k * tileSize.z), Quaternion.identity);
                }
                else
                {
                    CreateRandomChangedTile(i, 0, k);
                }
            }
        }
    }
    // TO:DO needs to be flushed out to incorporate min/max chance, as well as ChangedTile weight
    private GameObject CreateRandomChangedTile(int i, int j, int k)
    {
        int randomValue = Random.Range(0, chanceForEmpty + chanceForRaised);
        if (randomValue <= chanceForRaised)
        {
            Debug.Log("Created Raised");
            return (tileFactory.CreateRaisedTile(new Vector3(i * tileSize.x, j, k * tileSize.z), Quaternion.identity));
        }
        else
        {
            Debug.Log("Created Empty");
            return (tileFactory.CreateEmptyTile(new Vector3(i * tileSize.x, j, k * tileSize.z), Quaternion.identity));
        }
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

        /* Unused code
        if (chanceForEmpty + chanceForRaised >= 100)
        {
            if (chanceForEmpty > maxChance)
                chanceForEmpty = maxChance;
            else if (chanceForEmpty < minChance)
                chanceForEmpty = minChance;
            
            if (chanceForRaised > maxChance)
                chanceForRaised = maxChance;
            else if (chanceForRaised < minChance)
                chanceForRaised = minChance;
        }
        else
        {
            emptyTileCheck = convertIntoToPerct(chanceForEmpty);
            raisedTileCheck = convertIntoToPerct(chanceForRaised);
        }*/
        Debug.Log("Normal Tile Check: " + normalTileCheck);
    }

    private void GetTileSize()
    {
        tileSize = tileFactory.GetTileSize();
    }
}
