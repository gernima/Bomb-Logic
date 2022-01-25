using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static int currentActivators=0;
    public int neededActivators=1;
    public GameObject levelCompletePanel;
    private void Awake()
    {
        Time.timeScale = 0;
        currentActivators = 0;
        levelCompletePanel.SetActive(false);
    }
    private void Update()
    {
        if (currentActivators == neededActivators)
        {
            levelCompletePanel.SetActive(true);
        }
    }
    public void Restart()
    {
        Destroy(levelCompletePanel);
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
}
