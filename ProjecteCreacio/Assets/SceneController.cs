using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private ExitController exitController;
    public HealthSystem playerHealthSystem;
    // Start is called before the first frame update
    void Start()
    {
        exitController = GameObject.FindObjectOfType<ExitController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (exitController.OnTrigger)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (playerHealthSystem.IsDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
