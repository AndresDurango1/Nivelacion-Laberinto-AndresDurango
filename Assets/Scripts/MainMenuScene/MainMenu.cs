using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Texture2D cursor_OnButton;
    [SerializeField] private AudioSource playButton;

    public void Play()
    {
        StartCoroutine(PlayAudioThenLoadScene(playButton));
    }
    private IEnumerator PlayAudioThenLoadScene(AudioSource source)
    {
        source.Play();
        while (source.isPlaying == true)
        {
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OnButtonCursorEnter()
    {
        Cursor.SetCursor(cursor_OnButton, Vector2.zero, CursorMode.Auto);
    }
    public void OnButtonCursorExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}

