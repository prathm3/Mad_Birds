using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Enemy[] _enemies ;
    private static int _nextLevelindex = 1;
    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Enemy enmey in _enemies)
        {
            if (enmey != null)
            {
                return;
            }
            Debug.Log("You killed enemies");
            _nextLevelindex++;
            string nextLevel = "level" + _nextLevelindex;
            SceneManager.LoadScene(nextLevel);
        }

    }
}
