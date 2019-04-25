using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolveSudoku : SudokuManager
{
    [SerializeField]
    private GameManager manager;

    private void Start()
    {
        manager.LoadTable();
        manager.AddTablesToList();
    }

    public void SolveSelected()
    {
        PopulateGrid(manager.CurrentTable.SudokuGrid, 0, 0);
        manager.UIManagerComponent.PrintResult(manager.CurrentTable.SudokuGrid);
    }
}
