using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSudoku : SudokuManager
{
    private SudokuTable newTable = new SudokuTable();
    [SerializeField]
    private GameManager manager;

    public void Start()
    {
        CreateNewTable();
    }

    /// <summary>
    /// calculates another random grid of numbers for the sudoku table
    /// </summary>
    public void CreateNewTable()
    {
        RefreshGrid();
        PopulateGrid(newTable.SudokuGrid, 0, 0);
        RandomDelete();
    }

    /// <summary>
    /// after the table is generated correctly, the program removes numbers in random order until only 17 remains
    /// </summary>
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
        manager.UIManagerComponent.PrintResult(newTable.SudokuGrid);
        manager.CurrentTable = newTable;
    }

    /// <summary>
    /// make all of the numbers from the grid 0
    /// </summary>
    private void RefreshGrid()
    {
        for (int i = 0; i < newTable.SudokuGrid.GetLength(0); i++)
        {
            for (int j = 0; j < newTable.SudokuGrid.GetLength(1); j++)
            {
                newTable.SudokuGrid[i, j] = 0;
            }
        }
        manager.CurrentTable = newTable;
    }
}
