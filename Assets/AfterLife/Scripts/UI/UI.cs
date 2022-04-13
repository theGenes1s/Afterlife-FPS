using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    /// <summary>
    /// Main menu canvas Play Button
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene("Main"); //load main game scene.

    /// <summary>
    /// Main menu canvas Quit Button
    /// /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
