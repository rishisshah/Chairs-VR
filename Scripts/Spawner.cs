using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    // Use this for initialization
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

	private int difficultyIncrease = 1;
	private float speedIncr = 0.005f;

	void Start ()
    {
        StartCoroutine(SpawnWaves());
	}
	
    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
			int less = Random.Range (0, 2);
			float waveTime = Random.Range (0.0f, 1.0f);
            for (int i = 0; i < hazardCount - less; i++)
            {
				Quaternion[] choices = {Quaternion.Euler (Random.Range (0.0f, 360.0f), Random.Range (0.0f, 360.0f), Random.Range (0.0f, 360.0f)),
					Quaternion.Euler (0, Random.Range (0.0f, 360.0f),0)
				};
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x) + transform.position.x, spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z) + transform.position.z);
				Quaternion spawnRotation = choices[Random.Range(0, choices.Length)];
                GameObject justSpawned = Instantiate(hazard, spawnPosition, spawnRotation);


				SlidingMonster script = justSpawned.GetComponent<SlidingMonster> ();

				script.speed += speedIncr * difficultyIncrease;
				difficultyIncrease++;

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait + waveTime);
        }
    }

}
