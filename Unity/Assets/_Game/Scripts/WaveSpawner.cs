using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	// Variables
	[Header("Wave Settings")]
	public float startTimer = 5f;
	public float waveTimer = 10f;

	[Header("Transform Setup")]
	public Transform enemyPrefab;
	public Transform spawnP;

	private int waveCount = 1;
	
	// Update is called once per frame
	void Update () {
		// When timer reaches zero..
		if (startTimer <= 0f) {
			//.. Spawn first wave
			StartCoroutine (SpawnWave ());
			//.. Set countdown
			startTimer = waveTimer;
		}
		// Countdown & Clamp Timer
		startTimer -= Time.deltaTime;
		startTimer = Mathf.Clamp (startTimer, 0f, Mathf.Infinity);
	}

	IEnumerator SpawnWave(){
		// Spawn one enemy more every wave
		for (int i = 0; i < waveCount; i++) {
			SpawnEnemy ();
			yield return new WaitForSeconds (0.5f);
		}
	}

	void SpawnEnemy(){
		Instantiate (enemyPrefab, spawnP.position, spawnP.rotation);
	}
}
