using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainManager : SingletonManager<MainManager>
{
    public Canvas canvas;
    public MenuUI menuUI;
    public CharacterSelectUI characterSelectUI;
    public OptionUI optionUI;

    private void Start()
    {
        menuUI.startButton.onClick.AddListener(() => { OpenCharacterSelectUI(); });
        menuUI.optionButton.onClick.AddListener(() => { OpenOptionUI(); });
        menuUI.exitButton.onClick.AddListener(() => { CloseGame(); });

        characterSelectUI.character1.onClick.AddListener(() => { SelectCharacter(1); });
        characterSelectUI.character2.onClick.AddListener(() => { SelectCharacter(2); });
        characterSelectUI.character3.onClick.AddListener(() => { SelectCharacter(3); });
        characterSelectUI.returnButton.onClick.AddListener(() => { CloseCharacterPanel(); });

        optionUI.returnButton.onClick.AddListener(() => { CloseOptionUI(); });
    }

    private void OpenCharacterSelectUI()
    {
        characterSelectUI.GetComponent<Canvas>().enabled = true;
        menuUI.GetComponent<Canvas>().enabled = false;
    }

    private void SelectCharacter(int n)
    {
        PlayerPrefs.SetInt("CharacterIndex", n);
        SceneManager.LoadScene(1);
    }

    private void CloseCharacterPanel()
    {
        characterSelectUI.GetComponent<Canvas>().enabled = false;
        menuUI.GetComponent<Canvas>().enabled = true;
    }

    private void OpenOptionUI()
    {
        optionUI.GetComponent<Canvas>().enabled = true;
        menuUI.GetComponent<Canvas>().enabled = false;
    }

    private void CloseOptionUI()
    {
        optionUI.GetComponent<Canvas>().enabled = false;
        menuUI.GetComponent<Canvas>().enabled = true;
    }

    private void CloseGame()
    {
        Application.Quit();
    }

}
