using UnityEngine;
using System.Collections;

public class CubeKillCountdown : MonoBehaviour {

	public int startingTreshold;
	public int textureSize;
	public int frameBeforeCollapse;
	public Color collapseColor;
	public Color stableColor;

	private Texture2D texture;
	private int treshold = 0;
	private int nextRender;
	private int currentFrame = 1;

	// Use this for initialization
	void Start () {
		this.treshold = this.startingTreshold;
		this.texture = new Texture2D(this.textureSize, this.textureSize, TextureFormat.ARGB32, false);
		this.nextRender = 10 - this.startingTreshold;
		this.renderTexture ();
	}
	
	// Update is called once per frame
	void Update () {
		this.treshold = Mathf.CeilToInt((float)this.currentFrame / this.frameBeforeCollapse * 10) + 1;
		if (this.treshold < 10) {
			if (this.nextRender == 0) {
				this.renderTexture ();
				this.nextRender = 10 - this.startingTreshold;
			} else {
				this.nextRender--;
			}
		} else if (this.treshold == 10){
			this.renderTexture ();
			transform.Translate (Vector3.down);
		}
		this.currentFrame++;
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
		float coef = (float)this.treshold / 10;
		if (coef > .5f)
			coef = .5f;
		if (rnd >= this.treshold) {
			return Color.Lerp (this.stableColor, this.collapseColor, coef);
		} else {
			return Color.Lerp (this.collapseColor, this.stableColor, coef - .3f);
		}
	}
}
