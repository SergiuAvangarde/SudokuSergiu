using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Dropdown tableSelection;
    [SerializeField]
    private GameManager manager;
    [SerializeField]
    private Text[] numbersUI;

    /// <summary>
    /// Print the sudoku table to UI
    /// if the number is 0, it prints an empty string
    /// </summary>
    /// <param name="sudoku table"></param>
    public void PrintResult(int[,] sudoku)
    {
        int k = 0;
        for (int i = 0; i < sudoku.GetLength(0); i++)
        {
            for (int j = 0; j < sudoku.GetLength(1); j++)
            {
                if (sudoku[i, j] == 0)
                {
                    numbersUI[k].text = "";
                }
                else
                {
                    numbersUI[k].text = sudoku[i, j].ToString();
                }
                k++;
            }
        }
    }

    /// <summary>
    /// Add an option to the dropdown menu
    /// the number of the table will be the same as the one from the list
    /// </summary>
    /// <param name="the index of the table from the list"></param>
    public void AddOption(int index)
    {
        Dropdown.OptionData newTable = new Dropdown.OptionData();
        newTable.text = "Sudoku nr." + index.ToString();
        tableSelection.options.Add(newTable);
        tableSelection.value = 1;
    }

    /// <summary>
    /// Change the table with the one selected from the dropdown
    /// </summary>
    /// <param name="index"></param>
    public void SelectOption(int index)
    {
        manager.CurrentTable = manager.SudokuTables[index];
        PrintResult(manager.CurrentTable.SudokuGrid);
    }

    /// <summary>
    /// Call the funtion to delete the file
    /// </summary>
    public void DeleteFile()
    {
        FileManager.DeleteFile();
    }

    /// <summary>
    /// Switch between scenes
    /// </summary>
    public void SwitchScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "SudokuGenerator")
        {
            SceneManager.LoadScene("SudokuSolver");
        }
        else if (scene.name == "SudokuSolver")
        {
            SceneManager.LoadScene("SudokuGenerator");
        }
    }
}


