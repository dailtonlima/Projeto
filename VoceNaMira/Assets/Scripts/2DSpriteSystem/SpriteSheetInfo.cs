using UnityEngine;
using System.Collections.Generic;

public class SpriteSheetInfo {

	private Dictionary<string,SpriteRect> _spriteInfo;
	private string _spriteName;

	public SpriteSheetInfo(Dictionary<string,SpriteRect> SpriteInfo,string SpriteName){
		_spriteInfo = SpriteInfo;
		_spriteName = SpriteName;
	}

	public SpriteRect GetSprite(string name){
		return _spriteInfo[name];
	}

	public string[] GetSpriteNames(){
		string[] names = new string[_spriteInfo.Count];
		_spriteInfo.Keys.CopyTo (names, 0);
		return names;
	}

	public Texture2D GetTexture(){
		Texture2D texture = (Texture2D) Resources.Load (_spriteName);
		return texture;
	}


	public Dictionary<string,SpriteRect> SpriteInfo{
		get{return _spriteInfo;}
	}

	public string SpriteName{
		get{return _spriteName;}
	}
}
