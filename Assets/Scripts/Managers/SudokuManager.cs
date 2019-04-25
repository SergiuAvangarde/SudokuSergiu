using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuManager : MonoBehaviour
{
    /// <summary>
    /// this funtion checks the rulles of the Sudoku game, the given number can be onl once per line or collumn
    /// and only once in the respective subgrid
    /// </summary>
    /// <param name="the sudoku table"></param>
    /// <param name="the number you want to validate"></param>
    /// <param name="the row to wich you want to add the number"></param>
    /// <param name="the collumn to wich you want to add the number"></param>
    /// <returns>true if the position is valid</returns>
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

    /// <summary>
    /// this functions checks every number from 1 to 9 and puts the corect number in the corect position
    /// it is using backtraching to revert to a previous selection until it finds the first corect solution
    /// </summary>
    /// <param name="the current sudoku table"></param>
    /// <param name="the row where to start to populate"></param>
    /// <param name="the collumn where to start to populate"></param>
    /// <returns>true if the solution was found</returns>
    public bool PopulateGrid(int[,] sudoku, int row, int col)
    {
        if (col >= sudoku.GetLength(1))
        {
            col = 0;
            row++;
        }
        if (row >= sudoku.GetLength(0))
        {
            return true;
        }
        if (sudoku[row, col] == 0)
        {
            List<int> randomNum = new List<int>();
            randomNum = RandomNumbers();

            for (int i = 0; i < randomNum.Count; i++)
            {
                int value = randomNum[i];
                if (ValidatePosition(sudoku, value, row, col))
                {
                    sudoku[row, col] = value;
                    if (PopulateGrid(sudoku, row, col + 1))
                    {
                        return true;
                    }
                    sudoku[row, col] = 0;
                }
            }
        }
        else
        {
            if (PopulateGrid(sudoku, row, col + 1))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// gets 9 random unique numbers and puts them in a list
    /// </summary>
    /// <returns>a list of numbers 1-9 in random order</returns>
    private List<int> RandomNumbers()
    {
        List<int> random_container = new List<int>(9);
        do
        {
            int random_number = Random.Range(1, 10);
            if (!random_container.Contains(random_number))
            {
                random_container.Add(random_number);
            }
        }
        while (random_container.Count != 9);

        return random_container;
    }

    /// <summary>
    /// takes the 2D array and converts it in simple array
    /// </summary>
    /// <param name="2D Array"></param>
    /// <returns>simple array</returns>
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

    /// <summary>
    /// takes a simple array and converts it in a 2D array of 9x9
    /// </summary>
    /// <param name="simple Array"></param>
    /// <returns>2D array</returns>
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
