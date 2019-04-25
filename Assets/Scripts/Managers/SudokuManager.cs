using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuManager : MonoBehaviour
{
    public bool ValidatePosition(int[,] currentTable, int number, int row, int col)
    {
        if (currentTable[row,col] != 0)
        {
            return false;
        }

        for (int i = 0; i < currentTable.GetLength(1); i++)
        {
            if (currentTable[row, i] == number)
            {
                return false;
            }
        }

        for (int i = 0; i < currentTable.GetLength(0); i++)
        {
            if (currentTable[i, col] == number)
            {
                return false;
            }
        }

        for (int i = 0; i <= 2; i++)
        {
            for (int j = 0; j <= 2; j++)
            {
                if (currentTable[i + (row / 3) * 3, j + (col / 3) * 3] == number)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public bool PopulateGrid(int[,] Sudoku, int row, int col)
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
                if (ValidatePosition(Sudoku, value, row, col))
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

    public int[] ConvertToArray(int[,] grid)
    {
        int[] array = new int[81];
        int index = 0;
        foreach(int number in grid)
        {
            array[index] = number;
            index++;
        }
        return array;
    }

    public int[,] ConvertToGrid(int[] array)
    {
        int[,] grid = new int[9,9];
        int index = 0;

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                grid[i, j] = array[index];
                index++;
            }
        }
        return grid;
    }
}
