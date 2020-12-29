using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int difficulty = 1;

    public float distance = 0;
    public Text scoreTXT;

    public level[] difficultyStates;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.RoundToInt(Mathf.Abs((GameObject.FindGameObjectWithTag("Player").transform.position.x - 36)));
        scoreTXT.text = distance.ToString();

        if(difficultyStates.Length > 0)
        {
            if(difficultyStates[difficulty-1].distance <= distance)
            {
                difficulty++;
            }
        }
    }

    public void restartLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    [System.Serializable]
    public class level
    {
        public int distance;
        public float uiObsticleSpawnDelay;
        public bool spawnUiObsticles;

        public level(int dist, bool _spawnUiObsticles, float _uiObsticleSpawnDelay)
        {
            distance = dist;
            uiObsticleSpawnDelay = _uiObsticleSpawnDelay;
            spawnUiObsticles = _spawnUiObsticles;
        }
    }
}
