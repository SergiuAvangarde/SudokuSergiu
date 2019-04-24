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
