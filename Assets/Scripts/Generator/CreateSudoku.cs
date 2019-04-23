using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSudoku : MonoBehaviour
{
    public SudokuTable NewTable;
    public SudokuManager SudokuRulles;

    public Text[] NumbersUI;

    public void PopulateTable()
    {
        //for (int i = 0, j = 0; i < 3 && j < 3; i++, j++)
        //{
        //    DiagonalNumber(i, j);
        //}
        //PopulateMargins();
        PopulateFirstRow();
        PopulateGrid(NewTable.SudokuGrid, 0);
        PrintResult();
    }

    public bool PopulateGrid(int[,] Sudoku, int col)
    {
        if (col >= Sudoku.GetLength(1))
        {
            return true;
        }

        for (int i = 1; i < Sudoku.GetLength(0); i++)
        {
            for (int j = 1; j <= 9; j++)
            {
                if (SudokuRulles.ValidatePosition(Sudoku, j, i, col))
                {
                    Sudoku[i, col] = j;
                    if (PopulateGrid(Sudoku, col + 1))
                    {
                        return true;
                    }
                    Sudoku[i, col] = 0;
                }
            }
        }
        return false;
    }

    private void PopulateFirstRow()
    {
        Queue<int> randomNum = new Queue<int>();
        randomNum = RandomNumbers();

        for (int i = 0; i < 9; i++)
        {
            int number = randomNum.Dequeue();

            NewTable.SudokuGrid[0, i] = number;
        }
    }

    //public void PopulateMargins()
    //{
    //    for (int i = 0; i < 9; i++)
    //    {
    //        for (int j = 0; j < 9; j++)
    //        {
    //            if (NewTable.SudokuGrid[i, j] == 0)
    //            {
    //                int value = 1;
    //
    //                for (int k = value; k < 10; k++)
    //                {
    //                    if (SudokuRulles.ValidatePosition(NewTable.SudokuGrid, k, i, j))
    //                    {
    //                        NewTable.SudokuGrid[i, j] = k;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}

    //private void DiagonalNumber(int subRow, int subCol)
    //{
    //    Queue<int> randomNum = new Queue<int>();
    //    randomNum = RandomNumbers();
    //
    //    for (int i = 0; i < 3; i++)
    //    {
    //        for (int j = 0; j < 3; j++)
    //        {
    //            int row = (subRow * 3) + i;
    //            int col = (subCol * 3) + j;
    //
    //            int number = randomNum.Dequeue();
    //
    //            if (SudokuRulles.ValidatePosition(NewTable.SudokuGrid, number, row, col))
    //            {
    //                NewTable.SudokuGrid[row, col] = number;
    //            }
    //            else
    //            {
    //                randomNum.Enqueue(number);
    //            }
    //        }
    //    }
    //}

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
        int k = 0;
        for (int i = 0; i < NewTable.SudokuGrid.GetLength(0); i++)
        {
            for (int j = 0; j < NewTable.SudokuGrid.GetLength(1); j++)
            {
                NumbersUI[k].text = NewTable.SudokuGrid[i, j].ToString();
                k++;
                //print(NewTable.SudokuGrid[i, j]);
            }
            //print("end row");
        }
    }
}
