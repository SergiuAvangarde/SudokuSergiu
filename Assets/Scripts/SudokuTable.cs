using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuTable : MonoBehaviour
{
    public int[,] SudokuGrid = new int[8,8];
    public int[] SudokuArray = new int[80];

    public void SetNumber(int number, int i, int j)
    {
        SudokuGrid[i, j] = number;
    }


}
