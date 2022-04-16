using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //TO DO - CHANGE CURSOR TO POINTER ON BUTTON HOVER 
    public void Play()
    {
        SceneManager.LoadScene("Loading");
    }
    public void Settings()
    {
        //TO DO
    }
    public void Quit()
    {
        Application.Quit();
    }
    //UI cursos changing
    public void AOnMouseOver()
    {
        Cursor.SetCursor(default, Vector2.zero, CursorMode.Auto);
    }
    public void AOnMouseExit()
    {
        Cursor.SetCursor(default, Vector2.zero, CursorMode.Auto);
    }
}
