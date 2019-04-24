using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    private static readonly string SudokuList = "SudokuList.csv";

    public static void SaveToFile(int[] sudoku)
    {
        string filePath = Path.Combine(Application.persistentDataPath, SudokuList);
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

    public static List<SudokuTable> LoadFromFile()
    {
        string filePath = Path.Combine(Application.persistentDataPath, SudokuList);
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

    public static void DeleteFile()
    {
        string filePath = Path.Combine(Application.persistentDataPath, SudokuList);

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}
