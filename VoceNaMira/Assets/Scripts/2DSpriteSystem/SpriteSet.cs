using UnityEngine;
using System.Collections.Generic;

public class SpriteSet : MonoBehaviour {

	public TextAsset spriteData;
	private static List<SpriteSheetInfo> sprites;
	// Use this for initialization
	void Awake () {
		sprites = XMLParser.Parse (spriteData);

		//foreach (SpriteSheetInfo sprite in sprites)
		//	print (sprite.SpriteName);
	}

	public static SpriteSheetInfo GetSprite(string name)
	{
			foreach (SpriteSheetInfo sprite in sprites) {
				if (sprite.SpriteName == name) {
					return sprite;
				}
			}

		return null;
	}
}
