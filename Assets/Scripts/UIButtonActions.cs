using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonActions : MonoBehaviour
{
    public Color defaultColor;
    public Color hoverColor;

    private Renderer renderer;

    private void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
        renderer.material.color = defaultColor;
    }

    public void PointerEnter()
    {
        SetColor(hoverColor);
    }

    public void PointerExit()
    {
        SetColor(defaultColor);
    }

    public void Exit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void SetColor(Color color)
    {
        renderer.material.color = color;
    }

    public void PlayerExit()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            // exit
            Exit();
        }
        else
        {
            // load main menu
            LoadScene("MainMenu");
        }
    }



    /*public void TeleportPlayer()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = gameObject.transform.position;
    }*/

}
