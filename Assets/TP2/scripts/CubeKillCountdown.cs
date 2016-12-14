using UnityEngine;
using System.Collections;

public class CubeKillCountdown : MonoBehaviour {

	public int startingTreshold;
	public int textureSize;
	public Color collapseColor;
	public Color stableColor;

	private Texture2D texture;
	private int treshold = 0;
	private int nextRender;

	// Use this for initialization
	void Start () {
		this.treshold = this.startingTreshold;
		this.texture = new Texture2D(this.textureSize, this.textureSize, TextureFormat.ARGB32, false);
		this.nextRender = 5 - this.startingTreshold / 2;
		this.renderTexture ();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.treshold < 10) {
			if (this.nextRender == 0) {
				this.renderTexture ();
				this.nextRender = 5 - this.startingTreshold / 2;
			} else {
				this.nextRender--;
			}
		}
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
