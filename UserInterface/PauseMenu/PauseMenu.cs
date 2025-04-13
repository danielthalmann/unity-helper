using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // panneau qui affiche le menu
    public GameObject menuPanel;
    // nom de la scene pour quitter le jeu
    public string sceneStart = "Start";

    private bool opened;

    /// <summary>
    /// Start est appelé avant la première mise à jour d'image
    /// </summary>
    void Start()
    {
        CloseMenu();
    }

    /// <summary>
    /// Update est appelé une fois par rendu d'image
    /// </summary>
    void Update()
    {
        // capture le bouton annuler pour ouvrir le menu
        if (Input.GetButtonDown("Cancel"))
            ToggleMenu();

    }

    /// <summary>
    /// Bescule le menu
    /// </summary>
    public void ToggleMenu()
    {
        if (!opened)
            OpenMenu();
        else
            CloseMenu();
    }

    /// <summary>
    /// Ouvre le menu
    /// </summary>
    public void OpenMenu()
    {
        // stop le déroulement du temps
        // ceci permet de figer toutes les annimations
        Time.timeScale = 0;

        // affiche le panneau contenant les boutons d'action
        menuPanel.SetActive(true);
        opened = true;
    }

    /// <summary>
    /// Ferme le menu
    /// </summary>
    public void CloseMenu()
    {
        // relance le temps
        Time.timeScale = 1;
        menuPanel.SetActive(false);
        opened = false;
    }

    /// <summary>
    /// Quit la scéne
    /// </summary>
    public void Exit()
    {
        SceneManager.LoadScene(sceneStart);
    }

}
