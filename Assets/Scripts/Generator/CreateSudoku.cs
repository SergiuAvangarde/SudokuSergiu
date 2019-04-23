using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSudoku : MonoBehaviour
{
    public SudokuTable NewTable = new SudokuTable();
    public SudokuManager SudokuRulles;

    [SerializeField]
    private Text[] NumbersUI;

    public void Start()
    {
        RefreshGrid();
        PopulateGrid(NewTable.SudokuGrid, 0, 0);
        RandomDelete();
    }

    public void CreateNewTable()
    {
        RefreshGrid();
        PopulateGrid(NewTable.SudokuGrid, 0, 0);
        RandomDelete();
    }

    private void RandomDelete()
    {
        int count = 81;
        while (count > 15)
        {
            int row = Random.Range(0, 9);
            int col = Random.Range(0, 9);

            if (NewTable.SudokuGrid[row, col] != 0)
            {
                NewTable.SudokuGrid[row, col] = 0;
                count--;
            }
        }
        PrintResult();
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
            if (SudokuRulles.ValidatePosition(Sudoku, value, row, col))
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
        for (int i = 0; i < NewTable.SudokuGrid.GetLength(0); i++)
        {
            for (int j = 0; j < NewTable.SudokuGrid.GetLength(1); j++)
            {
                NewTable.SudokuGrid[i, j] = 0;
            }
        }
    }

    private void PrintResult()
    {
        int k = 0;
        for (int i = 0; i < NewTable.SudokuGrid.GetLength(0); i++)
        {
            for (int j = 0; j < NewTable.SudokuGrid.GetLength(1); j++)
            {
                if (NewTable.SudokuGrid[i, j] == 0)
                {
                    NumbersUI[k].text = "";
                }
                else
                {
                    NumbersUI[k].text = NewTable.SudokuGrid[i, j].ToString();
                }
                k++;
            }
        }
    }
}
