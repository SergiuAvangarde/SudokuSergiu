using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolveSudoku : SudokuManager
{
    [SerializeField]
    private GameManager Manager;

    private void Start()
    {
        Manager.LoadTable();
        Manager.AddTablesToList();
    }

    public void SolveSelected()
    {
        PopulateGrid(Manager.CurrentTable.SudokuGrid, 0, 0);
        Manager.UIManagerComponent.PrintResult(Manager.CurrentTable.SudokuGrid);
    }
}
