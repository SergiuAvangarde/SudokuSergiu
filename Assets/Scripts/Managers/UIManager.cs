using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Dropdown TableSelection;
    [SerializeField]
    private GameManager Manager;
    [SerializeField]
    private Text[] NumbersUI;

    public void PrintResult(int[,] sudoku)
    {
        int k = 0;
        for (int i = 0; i < sudoku.GetLength(0); i++)
        {
            for (int j = 0; j < sudoku.GetLength(1); j++)
            {
                if (sudoku[i, j] == 0)
                {
                    NumbersUI[k].text = "";
                }
                else
                {
                    NumbersUI[k].text = sudoku[i, j].ToString();
                }
                k++;
            }
        }
    }

    public void AddOption(int index)
    {
        Dropdown.OptionData newTable = new Dropdown.OptionData();
        newTable.text = "Sudoku nr." + index.ToString();
        TableSelection.options.Add(newTable);
        TableSelection.value = 1;
    }

    public void SelectOption(int index)
    {
        Manager.CurrentTable = Manager.SudokuTables[index];
        PrintResult(Manager.CurrentTable.SudokuGrid);
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


