using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarRating : MonoBehaviour {

	private RawImage oldImage;
	private RawImage newImage;

	// Use this for initialization
	void Start () {
    oldImage = GetComponent<RawImage>();
		newImage.texture = Resources.Load("filled_star");
	}

	// Update is called once per frame
	void Update () {

	}

	void OnStarClick() {


	}
}
