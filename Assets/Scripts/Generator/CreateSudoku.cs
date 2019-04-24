using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSudoku : MonoBehaviour
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

        List<int> randomNum = new List<int>();
        randomNum = RandomNumbers();

        for (int i = 0; i < randomNum.Count; i++)
        {
            int value = randomNum[i];
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
        return false;
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
