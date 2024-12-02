using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;
    void Start()
    {

    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void LoadOptions() 
    {
        optionsMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
