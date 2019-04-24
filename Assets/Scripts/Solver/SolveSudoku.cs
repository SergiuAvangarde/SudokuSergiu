using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolveSudoku : MonoBehaviour
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

    private bool PopulateGrid(int[,] Sudoku, int row, int col)
    {
        if (col >= Sudoku.GetLength(1))
        {
            col = 0;
            row++;
        }
        if (row >= Sudoku.GetLength(0))
        {
            return true;
        }
        if (Sudoku[row, col] == 0)
        {

            for (int i = 1; i <= 9; i++)
            {
                int value = i;
                if (Manager.SudokuManagerComponent.ValidatePosition(Sudoku, value, row, col))
                {
                    Sudoku[row, col] = value;
                    if (PopulateGrid(Sudoku, row, col + 1))
                    {
                        return true;
                    }
                    Sudoku[row, col] = 0;
                }
            }
        }
        else
        {
            if (PopulateGrid(Sudoku, row, col + 1))
            {
                return true;
            }
        }
        return false;
    }
}
