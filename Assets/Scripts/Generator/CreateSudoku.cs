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
        manager.UIManagerComponent.PrintResult(newTable.SudokuGrid);
        manager.CurrentTable = newTable;
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
        manager.CurrentTable = newTable;
    }
}
