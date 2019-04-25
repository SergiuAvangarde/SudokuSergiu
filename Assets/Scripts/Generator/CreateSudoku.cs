using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSudoku : SudokuManager
{
    private SudokuTable newTable = new SudokuTable();
    [SerializeField]
    private GameManager Manager;

    public void Start()
    {
        RefreshGrid();
        PopulateGrid(newTable.SudokuGrid, 0, 0);
        RandomDelete();
    }

    public void CreateNewTable()
    {
        RefreshGrid();
        PopulateGrid(newTable.SudokuGrid, 0, 0);
        RandomDelete();
    }

    private void RandomDelete()
    {
        int count = 81;
        while (count > 17)
        {
            int row = Random.Range(0, 9);
            int col = Random.Range(0, 9);

            if (newTable.SudokuGrid[row, col] != 0)
            {
                newTable.SudokuGrid[row, col] = 0;
                count--;
            }
        }
        Manager.UIManagerComponent.PrintResult(newTable.SudokuGrid);
        Manager.CurrentTable = newTable;
    }

    private List<int> RandomNumbers()
    {
        int counter = 0;
        List<int> random_container = new List<int>(9);
        do
        {
            int random_number = Random.Range(1, 10);
            if (!random_container.Contains(random_number))
            {
                random_container.Add(random_number);
                counter++;
            }
        }
        while (random_container.Count != 9);

        return random_container;
    }

    private void RefreshGrid()
    {
        for (int i = 0; i < newTable.SudokuGrid.GetLength(0); i++)
        {
            for (int j = 0; j < newTable.SudokuGrid.GetLength(1); j++)
            {
                newTable.SudokuGrid[i, j] = 0;
            }
        }
    }
}
