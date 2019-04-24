using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SudokuTable CurrentTable { get; set; } = new SudokuTable();
    public SudokuManager SudokuManagerComponent;
    public UIManager UIManagerComponent;

    public List<SudokuTable> SudokuTables = new List<SudokuTable>();

    public void AddTablesToList()
    {
        for (int i = 0; i < SudokuTables.Count; i++)
        {
            UIManagerComponent.AddOption(i+1);
        }
    }

    public void SaveTable()
    {
        CurrentTable.SudokuArray = SudokuManagerComponent.ConvertToArray(CurrentTable.SudokuGrid);
        FileManager.SaveToFile(CurrentTable.SudokuArray);
    }

    public void LoadTable()
    {
        SudokuTables = FileManager.LoadFromFile();
        foreach (var sudoku in SudokuTables)
        {
            sudoku.SudokuGrid = SudokuManagerComponent.ConvertToGrid(sudoku.SudokuArray);
        }
    }
}
