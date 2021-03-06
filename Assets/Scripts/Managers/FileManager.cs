﻿using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    private static readonly string sudokuList = "SudokuList.csv";

    /// <summary>
    /// Save the current sudoku to a file
    /// </summary>
    /// <param name="sudoku"></param>
    public static void SaveToFile(int[] sudoku)
    {
        string filePath = Path.Combine(Application.persistentDataPath, sudokuList);
        string contents = null;
        if (File.Exists(filePath))
        {
            foreach (var number in sudoku)
            {
                contents += number.ToString() + ',';
            }
            File.AppendAllText(filePath, Environment.NewLine + contents);
        }
        else
        {
            var textFile = Resources.Load<TextAsset>("SudokuList");
            File.AppendAllText(filePath, textFile.ToString());
            SaveToFile(sudoku);
        }
    }

    /// <summary>
    /// Load all of the sudoku tables from the file
    /// </summary>
    /// <returns>a list of sudoku tables</returns>
    public static List<SudokuTable> LoadFromFile()
    {
        string filePath = Path.Combine(Application.persistentDataPath, sudokuList);
        int[] sudokuArray;
        List<SudokuTable> sudokuTables = new List<SudokuTable>();
        if (File.Exists(filePath))
        {
            string[] tables = File.ReadAllLines(filePath);

            foreach (string item in tables)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    string[] sudokuNumbers = item.Split(',');
                    sudokuArray = new int[81];
                    for (int i = 0; i < 81; i++)
                    {
                        sudokuArray[i] = int.Parse(sudokuNumbers[i]);
                    }

                    SudokuTable newTable = new SudokuTable();
                    newTable.SudokuArray = sudokuArray;
                    sudokuTables.Add(newTable);
                }
            }
        }
        else
        {
            var textFile = Resources.Load<TextAsset>("SudokuList");
            File.AppendAllText(filePath, textFile.ToString());
            return LoadFromFile();
        }
        return sudokuTables;
    }

    /// <summary>
    /// Delete the file from path
    /// </summary>
    public static void DeleteFile()
    {
        string filePath = Path.Combine(Application.persistentDataPath, sudokuList);

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}
