using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static int currentActivators=0;
    public int neededActivators=1;
    public GameObject levelCompletedPanel;
    public GameObject levelFailedPanel;
    public bool timeStop=true;
    private void Awake()
    {
        if (timeStop) Time.timeScale = 0;
        currentActivators = 0;
        if (levelCompletedPanel) levelCompletedPanel.SetActive(false);
        if (levelFailedPanel) levelFailedPanel.SetActive(false);
        GlobalEvents.levelFailed.AddListener(ActivateLevelFailedPanel);
    }
    private void Update()
    {
        if (currentActivators == neededActivators)
        {
            levelCompletedPanel.SetActive(true);
        }
    }
    public void ActivateLevelFailedPanel()
    {
        levelFailedPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        Destroy(levelCompletedPanel);
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);

    }
    public void Play()
    {
        Time.timeScale = 1;
        GlobalEvents.ActivateItems();
        GlobalEvents.ChangeIsStart();
    }
    public void ChangeInventoryVisibility(GameObject inventory)
    {
        inventory.SetActive(!inventory.activeSelf);
    }
    public void LoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
