using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // animator qui effectue l'animation avant la transition de la scene
    public Animator sceneTransition;

    /// <summary>
    /// Charge une scène
    /// </summary>
    public void LoadScene(string scene)
    {
        StartCoroutine(EnumEffect(scene));
    }

    /// <summary>
    /// Temporise le chargement de la scène
    /// </summary>
    protected IEnumerator EnumEffect(string scene)
    {
        Time.timeScale = 1.0f;
        // start animator
        sceneTransition.SetTrigger("start");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(scene);
    }
}
