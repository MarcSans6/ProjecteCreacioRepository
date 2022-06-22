using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameObject enterDoor;
    private GameObject exitDoor;
    private GameObject player;
    public bool m_LevelFinished = false;

    public bool LevelFinished
    {
        get => m_LevelFinished;
    }

    void Start()
    {
        player = GameObject.Find("Player");
        enterDoor = GameObject.Find("EnterDoor");
        exitDoor = GameObject.Find("ExitDoor");
        enterDoor.GetComponent<Animator>().SetBool("Open", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_LevelFinished)
            return;

        CheckEnemiesAlive();
        if (m_LevelFinished)
            OpenExitDoor();

    }

    private void CheckEnemiesAlive()
    {
        m_LevelFinished = true;//GameObject.FindGameObjectsWithTag("Enemy") == null;
    }

    private void OpenExitDoor()
    {
       exitDoor.GetComponent<Animator>().SetBool("Open", true);
    }
}
