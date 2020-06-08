using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonActions : MonoBehaviour
{
    public Color defaultColor;
    public Color hoverColor;
    public Color disabledColor;

    private Renderer renderer;
    private bool isEnabled = true;

    private void Start()
    {
        // initialize
        renderer = gameObject.GetComponent<Renderer>();

        SetColor(defaultColor);

        // set level chooser buttons based on player progress
        int maxLevelPlayed = PlayerPrefs.GetInt("maxLevelPlayed", 1);
        if (transform.parent != null && transform.parent.name == "LevelChooseButtons" && !gameObject.name.ToLower().Contains("tutorial"))
        {
            int buttonLevelNumber = Tools.GetLevelNumber(gameObject.name);

            if (buttonLevelNumber > maxLevelPlayed)
            {
                gameObject.GetComponent<UIButtonActions>().SetColor(disabledColor);
                isEnabled = false;
            }

        }
    }

    public void PointerEnter()
    {
        if (isEnabled)
        {
            SetColor(hoverColor);
        }

        AudioManager.instance.PlayOneShot("UIButtonHover");

    }

    public void PointerExit()
    {
        if (isEnabled)
        {
            SetColor(defaultColor);
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }

    public void LoadScene(string scene)
    {
        if (isEnabled)
        {
            SceneManager.LoadScene(scene);
        }
    }

    public void SetColor(Color color)
    {
        if (isEnabled)
        {
            renderer.material.color = color;
            renderer.material.SetColor("_EmissionColor", color);
        }

    }

    public void PlayerExit()
    {
        // the floating button under the player

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

    public void Continue()
    {
        if (isEnabled)
        {
            string lastLevelPlayed = PlayerPrefs.GetString("lastLevelPlayed", "Level01"); // change this to tutorial? disable button on new game?
            LoadScene(lastLevelPlayed);
        }
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void PlayClickSound()
    {
        AudioManager.instance.PlayOneShot("UIButtonClick");
    }

}
