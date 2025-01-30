using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject _congratsPanel;
    [SerializeField] private GameObject _mainPanel;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger con: " + other.gameObject.name);
        if (other.CompareTag("FinalWall"))
        {
            Debug.Log("¡Entraste en el Trigger de la FinalWall!");
            _mainPanel.SetActive(false);
            _congratsPanel.SetActive(true);
        }
    }
}
