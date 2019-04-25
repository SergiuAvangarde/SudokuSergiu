using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolveSudoku : SudokuManager
{
    [SerializeField]
    private GameManager manager;

    /// <summary>
    /// Loads the tables from the file and populates the dropdown
    /// </summary>
    private void Start()
    {
        manager.LoadTable();
        manager.AddTablesToList();
    }

    /// <summary>
    /// solve the selected sudoku table from the dropdown
    /// </summary>
    public void SolveSelected()
    {
        PopulateGrid(manager.CurrentTable.SudokuGrid, 0, 0);
        manager.UIManagerComponent.PrintResult(manager.CurrentTable.SudokuGrid);
    }
}
