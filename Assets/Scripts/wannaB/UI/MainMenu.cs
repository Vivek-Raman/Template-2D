using UnityEngine;
using UnityEngine.SceneManagement;

namespace wannaB.UI
{
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;

    public void UI_OnPlayGameClicked()
    {
        if (SceneManager.sceneCount > 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void UI_OnSettingsClicked()
    {
        SetActiveStateForAllPanels(false);
        settingsPanel.SetActive(true);
    }

    public void UI_OnExitClicked()
    {
        Application.Quit();
    }

    public void UI_OnBackToMainMenuClicked()
    {
        SetActiveStateForAllPanels(false);
        mainMenuPanel.SetActive(true);
    }

    private void SetActiveStateForAllPanels(bool toSet)
    {
        mainMenuPanel.SetActive(toSet);
        settingsPanel.SetActive(toSet);
    }
}
}
