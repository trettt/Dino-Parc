using TMPro;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI welcomeMessage;

    private void Start()
    {
        Invoke("HideStartText", 5f);
    }

    void HideStartText()
    {
        welcomeMessage.text = "";
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
