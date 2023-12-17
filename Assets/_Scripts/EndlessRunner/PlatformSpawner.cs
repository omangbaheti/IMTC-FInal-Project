using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] GameObject coins;
    [SerializeField] GameObject[] bottomItems;

    [SerializeField] GameObject currentPlatform;
    [SerializeField] WinterPlayerPoints playerPoints;

    float dynamicDA;
    float timer = 0;
    void Start()
    {
        //StartCoroutine(CoinSpawn());
        StartCoroutine(BlockBottomSpawn());
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

    //IEnumerator BlockSpawn()
    //{
    //    while(true)
    //    {
    //        //choose spawn one or two
    //        float spawnAmountofBlocked = Random.Range(0f, 1f);
    //        Debug.Log(spawnAmountofBlocked);
    //        if(spawnAmountofBlocked > 0.5f)
    //        {
    //            //spawn one
    //            int randomPositionA = Random.Range(-1,2);               
    //            int randomPositionB = Random.Range(-1,2);
    //            while(randomPositionA == randomPositionB)
    //            {
    //                randomPositionB = Random.Range(-1, 2);
    //            }
    //            int randomSpawnItem = Random.Range(0, blocked.Length);
    //            Vector3 positionA = new Vector3(transform.position.x + randomPositionA, blocked[randomSpawnItem].transform.position.y, transform.position.z);
    //            Vector3 positionB = new Vector3(transform.position.x + randomPositionB, blocked[randomSpawnItem].transform.position.y, transform.position.z);
    //            //decide to spawn which

    //            GameObject blockA = Instantiate(blocked[randomSpawnItem], positionA, blocked[randomSpawnItem].transform.rotation);
    //            GameObject blockB = Instantiate(blocked[randomSpawnItem], positionB, blocked[randomSpawnItem].transform.rotation);
    //            blockA.transform.SetParent(currentPlatform.transform);
    //            blockB.transform.SetParent(currentPlatform.transform);
    //        }
    //        else
    //        {
    //            int randomPositionA = Random.Range(-1, 2);
    //            int randomSpawnItem = Random.Range(0, blocked.Length);
    //            Vector3 positionA = new Vector3(transform.position.x + randomPositionA, blocked[randomSpawnItem].transform.position.y, transform.position.z);               
    //            GameObject blockA = Instantiate(blocked[randomSpawnItem], positionA, blocked[randomSpawnItem].transform.rotation);
    //            blockA.transform.SetParent(currentPlatform.transform);
    //        }

    //        yield return new WaitForSeconds(0.5f);
    //    }
    //}

    IEnumerator BlockBottomSpawn()
    {
        while (true)
        {
            //DDA
            dynamicDA = Mathf.Lerp(0.5f, 0.1f, timer / 120f);

            float randomPosition = Random.Range(0f, 1f);
            if(randomPosition > 0.5)
            {
                int randomItem = Random.Range(0, bottomItems.Length);
                Vector3 positionA = new Vector3(transform.position.x + transform.position.x - 1, bottomItems[randomItem].transform.position.y, transform.position.z);
                GameObject left = Instantiate(bottomItems[randomItem], positionA, bottomItems[randomItem].transform.rotation);
                left.GetComponent<SnowObjectHandle>().winterPlayerPoints = playerPoints;
            }
            else
            {
                int randomItem = Random.Range(0, bottomItems.Length);
                Vector3 positionA = new Vector3(transform.position.x + transform.position.x + 1, bottomItems[randomItem].transform.position.y, transform.position.z);
                GameObject left = Instantiate(bottomItems[randomItem], positionA, bottomItems[randomItem].transform.rotation);
                left.GetComponent<SnowObjectHandle>().winterPlayerPoints = playerPoints;
            }
            

            yield return new WaitForSeconds(dynamicDA);
            Debug.Log(dynamicDA);
            timer += Time.deltaTime;
        }
    }
}
