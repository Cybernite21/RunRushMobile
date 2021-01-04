using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiObsticleSpawner : MonoBehaviour
{

    RectTransform obsticlePanel;
    public GameObject uiObsticle;

    public float delayBtwnSpawn = 2f;

    public bool spawn = true;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        obsticlePanel = gameObject.GetComponent<RectTransform>();
        StartCoroutine(spawnUiObsticle());
        gameManager = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.difficulty > 1)
        {
            delayBtwnSpawn = gameManager.difficultyStates[gameManager.difficulty - 2].uiObsticleSpawnDelay;
            spawn = gameManager.difficultyStates[gameManager.difficulty - 2].spawnUiObsticles;
        }
    }

    IEnumerator spawnUiObsticle()
    {
        if(spawn)
        {
            Vector3 spawnPosition = GetBottomLeftCorner(obsticlePanel) - new Vector3(Random.Range(0, obsticlePanel.rect.x * 2), Random.Range(0, obsticlePanel.rect.y * 2), 0);
            Instantiate(uiObsticle, spawnPosition, Quaternion.identity, obsticlePanel);
            yield return new WaitForSeconds(delayBtwnSpawn);
        }
        yield return null;
        StartCoroutine(spawnUiObsticle());
    }

    Vector3 GetBottomLeftCorner(RectTransform rt)
    {
        Vector3[] v = new Vector3[4];
        rt.GetWorldCorners(v);
        return v[0];
    }
}
