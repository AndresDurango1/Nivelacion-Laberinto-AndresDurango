using UnityEngine;
using UnityEngine.UI;

public class MinimapController : MonoBehaviour
{
    [SerializeField] private GameObject minimapPanel;
    void Start()
    {
        minimapPanel.SetActive(false);
    }
    public void ToggleMinimap()
    {
        minimapPanel.SetActive(!minimapPanel.activeSelf);
    }
}
