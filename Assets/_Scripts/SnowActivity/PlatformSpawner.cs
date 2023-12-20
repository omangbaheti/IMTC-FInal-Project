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

    [SerializeField] private Transform leftSpawn;
    [SerializeField] private Transform rightSpawn;

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
    

    IEnumerator BlockBottomSpawn()
    {
        while (true)
        {
            //DDA
            dynamicDA = Mathf.Lerp(0.5f, 0.1f, timer / 120f);

            float randomPosition = Random.Range(0f, 1f);
            float randomHeight = Random.Range(1f, 4f);
            int randomItemIndex = Random.Range(0, bottomItems.Length);
            var randomItem = bottomItems[randomItemIndex];
            if(randomPosition > 0.5)
            {
                Vector3 spawnPosition = new Vector3(leftSpawn.position.x, leftSpawn.position.y + randomHeight, leftSpawn.position.z);
                GameObject left = Instantiate(randomItem, spawnPosition, leftSpawn.rotation, transform);
                left.GetComponent<SnowObjectHandle>().winterPlayerPoints = playerPoints;
            }
            else
            {
                Vector3 spawnPosition = new Vector3(rightSpawn.position.x, rightSpawn.position.y + randomHeight, rightSpawn.position.z);
                GameObject left = Instantiate(randomItem, spawnPosition, leftSpawn.rotation, transform);
                left.GetComponent<SnowObjectHandle>().winterPlayerPoints = playerPoints;
            }

            float randomTime = Random.Range(2f, 4f);
            yield return new WaitForSeconds(randomTime);
            Debug.Log(dynamicDA);
            timer += Time.deltaTime;
        }
    }
}
