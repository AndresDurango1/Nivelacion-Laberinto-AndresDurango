using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainController : MonoBehaviour
{
    [SerializeField] private Texture2D cursor_OnButton;
    [SerializeField] private AudioSource playAgainButton;

    public void PlayAgain()
    {
        StartCoroutine(PlayAudioThenLoadScene(playAgainButton));
    }
    private IEnumerator PlayAudioThenLoadScene(AudioSource source)
    {
        source.Play();
        while (source.isPlaying == true)
        {
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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
