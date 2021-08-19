using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] LevelGenerator levelGenerator;
    [SerializeField] private int numberOfEnemies;
    [SerializeField] private int rows;
    [SerializeField] private int columns;

    List<GameObject> tiles;

    // Start is called before the first frame update
    void Awake()
    {
        rows = Random.Range(5, 20);
        columns = Random.Range(5, 20);

        levelGenerator.GenerateLevel(rows, columns);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
