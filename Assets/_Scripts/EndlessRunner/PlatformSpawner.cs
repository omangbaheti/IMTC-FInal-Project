using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] GameObject coins;
    [SerializeField] GameObject[] blocked;

    [SerializeField] GameObject currentPlatform;

    void Start()
    {
        StartCoroutine(PlatformSpawn());
        StartCoroutine(CoinSpawn());
        StartCoroutine(BlockSpawn());
    }

    IEnumerator PlatformSpawn()
    {
        while (true)
        {
            currentPlatform = Instantiate(platform, transform.position, transform.rotation);



            //if(randomBlockNumDecision > 0)
            //{
            //    //mean spawn two
            //    int randomPositionA = Random.Range(-1, 2);
            //    int randomPositionB = Random.Range(-1, 2);
            //    Vector3 blockPositionA = new Vector3(transform.position.x + randomPositionA, transform.position.y, transform.position.z);
            //    Vector3 blockPositionB = new Vector3(transform.position.x + randomPositionB, transform.position.y, transform.position.z);

            //    int randomBlock = Random.Range(0, blocked.Length);
            //    GameObject blockA = Instantiate(blocked[randomBlock], blockPositionA, transform.rotation);
            //    GameObject blockB = Instantiate(blocked[randomBlock], blockPositionB, transform.rotation);
            //    blockA.transform.SetParent(platformTemp.transform);
            //    blockB.transform.SetParent(platformTemp.transform);
            //}

            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator CoinSpawn()
    {
        while(true)
        {
            int randomCoinPosition = (int)Random.Range(-1, 2);
            Vector3 coinPosition = new Vector3(transform.position.x + randomCoinPosition, coins.transform.position.y, transform.position.z);
            GameObject coinTemp = Instantiate(coins, coinPosition, coins.transform.rotation);
            coinTemp.transform.SetParent(currentPlatform.transform);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator BlockSpawn()
    {
        while(true)
        {
            //choose spawn one or two
            float spawnAmountofBlocked = Random.Range(0f, 1f);
            Debug.Log(spawnAmountofBlocked);
            if(spawnAmountofBlocked > 0.5f)
            {
                //spawn one
                int randomPositionA = Random.Range(-1,2);               
                int randomPositionB = Random.Range(-1,2);
                while(randomPositionA == randomPositionB)
                {
                    randomPositionB = Random.Range(-1, 2);
                }
                int randomSpawnItem = Random.Range(0, blocked.Length);
                Vector3 positionA = new Vector3(transform.position.x + randomPositionA, blocked[randomSpawnItem].transform.position.y, transform.position.z);
                Vector3 positionB = new Vector3(transform.position.x + randomPositionB, blocked[randomSpawnItem].transform.position.y, transform.position.z);
                //decide to spawn which
                
                GameObject blockA = Instantiate(blocked[randomSpawnItem], positionA, transform.rotation);
                GameObject blockB = Instantiate(blocked[randomSpawnItem], positionB, transform.rotation);
                blockA.transform.SetParent(currentPlatform.transform);
                blockB.transform.SetParent(currentPlatform.transform);
            }
            else
            {
                int randomPositionA = Random.Range(-1, 2);
                int randomSpawnItem = Random.Range(0, blocked.Length);
                Vector3 positionA = new Vector3(transform.position.x + randomPositionA, blocked[randomSpawnItem].transform.position.y, transform.position.z);               
                GameObject blockA = Instantiate(blocked[randomSpawnItem], positionA, transform.rotation);
                blockA.transform.SetParent(currentPlatform.transform);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
