using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private LevelGenerator levelGenerator;

    private int activeRows;
    private int activeColumns;

    
    void Awake()
    {
        levelGenerator.CreateTileMap();
        
        //For the first "room" in a run. Can be either a predetermined size or a random size depending on the function called.
        levelGenerator.NewLevel();
    }

    // Even though not used for the initial room generation, the plan is for the values to be able to be adjusted in game from players actions/events. Like rooms should be able to be very randomized and very customisable at the same time.
    // Number of tiles, chances for different types of tiles, tile sizes (stil has to be rectangular at least) to start. 
    public void SetDimensions(int rows, int columns)
    {
        SetActiveRows(rows);
        SetActiveColumns(columns);
    }

    public void SetActiveRows(int rows)
    {
        activeRows = rows;
    }

    public void SetActiveColumns(int columns)
    {
        activeColumns = columns;
    }
}
