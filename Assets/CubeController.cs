using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	//キューブの移動速度
	private float speed = -0.2f;

	//消滅位置
	private float deadLine = -10f;

	private GameObject ground;
	private GameObject cubePrefab;
	public AudioSource audioSource;
	public AudioClip block;

	// Use this for initialization
	void Start () {
		this.ground = GameObject.Find ("ground");
		this.cubePrefab = GameObject.Find ("CubePrefab");
		this.audioSource = gameObject.GetComponent<AudioSource> ();
		this.audioSource.clip = block;
	}
	
	// Update is called once per frame
	void Update () {
		//キューブを移動させる
		transform.Translate(this.speed,0,0);

		//画面外に出たら破棄する
		if (transform.position.x < this.deadLine) {
			Destroy (gameObject);
		}

	}

	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.tag == "groundTag" || other.gameObject.tag == "cubeTag") {
			audioSource.PlayOneShot (block);

		}
	}

}
