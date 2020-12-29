using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
    public GameObject plr;
    public GameObject obsticlePrefab;

    public GameObject obsticleHolder;

    private GameObject myObsticle;

    public GameObject tmpObsticle;

    public float spawnOffsetY = 3.5f;
    public float lvlWidth = 6;
    public int obsticles = 15;

    [Range(0, 100)]
    public float coinPercentage = 20f;

    float n;
    float c;

    // Start is called before the first frame update
    void Start()
    {
        plr = GameObject.FindGameObjectWithTag("Player");
        Vector3 spawnPos = new Vector3();

        for(int i = 0; i < obsticles; i++)
        {
            spawnPos.y = 2;
            spawnPos.x += Random.Range(-4f, -8f) - 2;
            spawnPos.z = Random.Range(-lvlWidth, lvlWidth);
            tmpObsticle = Instantiate(obsticlePrefab, spawnPos, Quaternion.identity, obsticleHolder.transform);
            spawnOffsetY = tmpObsticle.transform.position.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        /*if(other.gameObject.name.StartsWith("Platform"))
        {
            if(Random.Range(1, 7) == 1)
            {
                Destroy(other.gameObject);
                myPlat = (GameObject)Instantiate(springPrefab, new Vector3(Random.Range(-6.5f, 6.5f), plr.transform.position.y + (spawnOffsetY + Random.Range(.5f, 1f)), plr.transform.position.z), Quaternion.identity);
            }
            else
            {
                other.gameObject.transform.position = new Vector3(Random.Range(-6.5f, 6.5f), plr.transform.position.y + (spawnOffsetY + Random.Range(.5f, 1f)), plr.transform.position.z);
            }
        }
        else if(other.gameObject.name.StartsWith("Spring"))
        {
            if (Random.Range(1, 7) == 1)
            {
                other.gameObject.transform.position = new Vector3(Random.Range(-6.5f, 6.5f), plr.transform.position.y + (spawnOffsetY + Random.Range(.5f, 1f)), plr.transform.position.z);               
            }
            else
            {
                Destroy(other.gameObject);
                myPlat = (GameObject)Instantiate(platformPrefab, new Vector3(Random.Range(-6.5f, 6.5f), plr.transform.position.y + (spawnOffsetY + Random.Range(.5f, 1f)), plr.transform.position.z), Quaternion.identity);
            }
        }*/
        if (other.gameObject.tag == "obsticle")
        {
            create(other);
        }
        else if (other.gameObject.tag.StartsWith("building"))
        {
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x - 121, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
        }
    }

    void create(Collider other)
    {
        n = Random.Range(1, 11);
        c = Random.Range(0f, 100f);

        myObsticle = Instantiate(obsticlePrefab, new Vector3(tmpObsticle.transform.position.x + Random.Range(-4f, -8f), 2, Random.Range(-lvlWidth, lvlWidth)), Quaternion.identity, obsticleHolder.transform);
        //myObsticle = Instantiate(obsticlePrefab, new Vector3(Random.Range(-lvlWidth, lvlWidth) + (tmpObsticle.transform.position.y + Random.Range(2f, 4f)), plr.transform.position.z), Quaternion.identity, obsticleHolder.transform);
        tmpObsticle = myObsticle;

        /*if(c <= coinPercentage)
        {
            Vector3 cPos = new Vector3(myObsticle.transform.position.x, myObsticle.transform.position.y + 1.75f, myObsticle.transform.position.z);
            Instantiate(coinPrefab, cPos, Quaternion.identity, obsticleHolder.transform);
        }*/

        Destroy(other.gameObject);
    }
}
