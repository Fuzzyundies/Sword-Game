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
        }
    }

    private double convertIntoToPerct(int n)
    {
        return System.Math.Abs((double)(n % 100 / 100));
    }

    private void CreateCheckRanges()
    {
        if(emptyTileCheck + raisedTileCheck < 1.0)
        {
            //Do something clever
            //Reduce by half
            //Recurssive call
        }
        ;
    }

}
