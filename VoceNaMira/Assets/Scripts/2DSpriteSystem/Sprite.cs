using UnityEngine;
using System.Collections;

public class Sprite : MonoBehaviour {

	private Texture2D _spriteTexture;
	private SpriteSheetInfo _spriteInfo;
	private float _interval;
	private bool _isPlaying;

	public enum PlayMode{
		Loop,
		Once,
		Pong
	}

	public void Create(SpriteSheetInfo SpriteInfo){
		if (_isPlaying)
				Stop ();
		_spriteInfo = SpriteInfo;
		renderer.material = new Material (Shader.Find("Transparent/Diffuse"));
		_spriteTexture = _spriteInfo.GetTexture ();

	}

	public void Play(PlayMode playMode,float intervalBetweenFrames,bool forceStop=true){
		_interval = intervalBetweenFrames;
		if (!forceStop) 
		{
			switch (playMode) {
			case PlayMode.Loop:
					StartCoroutine(Loop());
					break;
			case PlayMode.Once:
					StartCoroutine(Once());
					break;
			case PlayMode.Pong:
					StartCoroutine(Pong());
					break;
			}
		} else {
			Stop();
			Play(playMode,intervalBetweenFrames,false);
		}
	}

	private IEnumerator Loop(){
		
		string[] spriteNames = _spriteInfo.GetSpriteNames ();
		renderer.material.mainTexture = _spriteTexture;
		_isPlaying = true;
		while(true){
			for(int i = 0; i < spriteNames.Length; i++){
				SpriteRect rect = _spriteInfo.GetSprite(spriteNames[i]);
				Vector2 imageDimension = new Vector2(_spriteTexture.width,_spriteTexture.height);
				renderer.material.mainTextureOffset = rect.GetOffset(imageDimension);
				renderer.material.mainTextureScale = rect.GetScale(imageDimension);
				yield return new WaitForSeconds(_interval);
			}
		}
	}

	private IEnumerator Once(){
		
		string[] spriteNames = _spriteInfo.GetSpriteNames ();
		renderer.material.mainTexture = _spriteTexture;
		_isPlaying = true;

		for(int i = 0; i < spriteNames.Length; i++){
			SpriteRect rect = _spriteInfo.GetSprite(spriteNames[i]);
			Vector2 imageDimension = new Vector2(_spriteTexture.width,_spriteTexture.height);
			renderer.material.mainTextureOffset = rect.GetOffset(imageDimension);
			renderer.material.mainTextureScale = rect.GetScale(imageDimension);
			yield return new WaitForSeconds(_interval);
		}

		Stop ();
	}

	private IEnumerator Pong(){
		
		string[] spriteNames = _spriteInfo.GetSpriteNames ();
		renderer.material.mainTexture = _spriteTexture;
		_isPlaying = true;
		while(true){
			for(int i = -(spriteNames.Length -1); i < spriteNames.Length -1; i++){
				SpriteRect rect = _spriteInfo.GetSprite(spriteNames[Mathf.Abs(i)]);
				Vector2 imageDimension = new Vector2(_spriteTexture.width,_spriteTexture.height);
				renderer.material.mainTextureOffset = rect.GetOffset(imageDimension);
				renderer.material.mainTextureScale = rect.GetScale(imageDimension);
				yield return new WaitForSeconds(_interval);
			}
		}
	}

	public void setSprite(string name){

		SpriteRect rect = _spriteInfo.GetSprite (name);
		Vector2 imgDimensions = new Vector2 (_spriteTexture.width, _spriteTexture.height);
		renderer.material.mainTextureOffset = rect.GetOffset(imgDimensions);
		renderer.material.mainTextureScale = rect.GetScale(imgDimensions);
	}

	public void Stop()
	{
		_isPlaying = false;
		StopAllCoroutines ();
	}

	public Texture2D SpriteTexture
	{
		get{return _spriteTexture;}
	}

	public SpriteSheetInfo SpriteInfo
	{
		get{return _spriteInfo;}
	}

	public float Interval
	{
		get{return _interval;}
		set{_interval = value;}
	}

}
