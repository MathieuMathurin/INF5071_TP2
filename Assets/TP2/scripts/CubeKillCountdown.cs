using UnityEngine;
using System.Collections;

public class CubeKillCountdown : MonoBehaviour {

	public int startingTreshold;
	public int textureSize;
	public Color collapseColor;
	public Color stableColor;

	private Texture2D texture;
	private int treshold = 0;

	// Use this for initialization
	void Start () {
		this.treshold = this.startingTreshold;
		this.texture = new Texture2D(this.textureSize, this.textureSize, TextureFormat.ARGB32, false);
	}
	
	// Update is called once per frame
	void Update () {
		this.renderTexture ();
	}

	private void renderTexture() {
		for (int i = 0; i < this.textureSize; ++i) {
			for (int j = 0; j < this.textureSize; ++j) {
				texture.SetPixel(i, j, this.renderTextureSlot());
			}
		}
		this.texture.Apply ();
		GetComponent<Renderer>().material.mainTexture = this.texture;
	}

	private Color renderTextureSlot() {
		int rnd = Random.Range (0, 10);
		if (rnd >= this.treshold) {
			return this.stableColor;
		} else {
			return this.collapseColor;
		}
	}
}
