using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
	public GameObject platformPrefab;
	public GameObject movingPlatform;

	public int numberOfPlatforms = 200;
	public float levelWidth = 3f;
	public float minY = 1f;
	public float maxY = 1.5f;

	// Use this for initialization
	void Start()
	{

		Vector3 spawnPosition = new Vector3();

		for (int i = 0; i < numberOfPlatforms; i++)
		{
			spawnPosition.y += Random.Range(minY, maxY);
			spawnPosition.x = Random.Range(-levelWidth, levelWidth);
			float selector = Random.Range(0f, 1f);
			if(selector > 0.85)
            {
				Instantiate(movingPlatform, spawnPosition, Quaternion.identity);
            }
            else
            {
				Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
			}
			
		}
	}
}
