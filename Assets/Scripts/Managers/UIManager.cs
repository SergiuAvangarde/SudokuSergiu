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

    public void AddOption(int index)
    {
        Dropdown.OptionData newTable = new Dropdown.OptionData();
        newTable.text = "Sudoku nr." + index.ToString();
        tableSelection.options.Add(newTable);
        tableSelection.value = 1;
    }

    public void SelectOption(int index)
    {
        manager.CurrentTable = manager.SudokuTables[index];
        PrintResult(manager.CurrentTable.SudokuGrid);
    }

    public void DeleteFile()
    {
        FileManager.DeleteFile();
    }

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


