using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSudoku : MonoBehaviour
{
    public SudokuTable NewTable;
    public SudokuManager SudokuRulles;

    public void PopulateTable()
    {
        for (int i = 0, j = 0; i < 3 && j < 3; i++, j++)
        {
            DiagonalNumber(i, j);
        }
        PopulateMargins();
        PrintResult();
    }

    public void PopulateMargins()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (NewTable.SudokuGrid[i, j] == 0)
                {
                    int value = 1;

                    for (int k = value; k < 10; k++)
                    {
                        if (SudokuRulles.ValidatePosition(NewTable.SudokuGrid, k, i, j))
                        {
                            NewTable.SudokuGrid[i, j] = k;
                        }
                    }
                }
            }
        }
    }

    private void DiagonalNumber(int subRow, int subCol)
    {
        Queue<int> randomNum = new Queue<int>();
        randomNum = RandomNumbers();

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int row = (subRow * 3) + i;
                int col = (subCol * 3) + j;

                int number = randomNum.Dequeue();

                if (SudokuRulles.ValidatePosition(NewTable.SudokuGrid, number, row, col))
                {
                    NewTable.SudokuGrid[row, col] = number;
                }
                else
                {
                    randomNum.Enqueue(number);
                }
            }
        }
    }

    private Queue<int> RandomNumbers()
    {
        int counter = 0;
        Queue<int> random_container = new Queue<int>(9);
        do
        {
            int random_number = Random.Range(1, 10);
            if (!random_container.Contains(random_number))
            {
                //Debug.Log(random_number + "   " + counter);
                random_container.Enqueue(random_number);
                counter++;
            }
        }
        while (random_container.Count != 9);

        return random_container;
    }

    private void PrintResult()
    {
        for (int i = 0; i < NewTable.SudokuGrid.GetLength(0); i++)
        {
            for (int j = 0; j < NewTable.SudokuGrid.GetLength(1); j++)
            {
                print(NewTable.SudokuGrid[i, j]);
            }
            print("end row");
        }
    }
}
