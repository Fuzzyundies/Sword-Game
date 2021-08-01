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

    [SerializeField] private double emptyTileCheck;
    [SerializeField] private double raisedTileCheck;

    [SerializeField] private int minChance;
    [SerializeField] private int maxChance;

    // Start is called before the first frame update
    void Awake()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        double rolledValue;
        CreateCheckRanges();
        
        for (int i = 0; i < rows + columns; i++)
        {
            rolledValue = Random.value;
            if (rolledValue <= emptyTileCheck + raisedTileCheck)
            {
                //Set up way to randomise between calling empty or raised
            }
            else
                tileFactory.CreateBasicTile(); //Needs to flush out with moving the location of the instantiating. Also need to flush out the factory with transform/rotation.
        }
    }

    private double convertIntoToPerct(int n)
    {
        return System.Math.Abs((double)(n % 100 / 100));
    }

    // TO:DO Needs to be flushed out once game is more flushed out
    // Idea is to allow for either user or in-game adjustments to the values and it would be wise to verify the values to make sure they work.
    // For now, it will just be assumed it won't be open to the user and will need to be implemented later.
    private void CreateCheckRanges()
    {
        emptyTileCheck = convertIntoToPerct(chanceForEmpty);
        raisedTileCheck = convertIntoToPerct(chanceForRaised);

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
    }

}
