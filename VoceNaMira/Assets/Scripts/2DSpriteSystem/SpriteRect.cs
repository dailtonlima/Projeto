using UnityEngine;
using System.Collections;

public class SpriteRect {

	private int _startX,_startY,_width,_height;

	public SpriteRect(int startX,int startY,int width,int height){
		_startX = startX;
		_startY = startY;
		_width = width;
		_height = height;
	}

	public int startX
	{
		get{return _startX;}
	}
	
	public int startY
	{
		get{return _startY;}
	}
	
	public int Width
	{
		get{return _width;}
	}
	
	public int Heigth
	{
		get{return _height;}
	}

	public Vector2 GetScale(Vector2 imageDimensions){
	
		float x = _width / imageDimensions.x;
		float y = _height / imageDimensions.y;
		return new Vector2 (x,y);
	}

	public Vector2 GetOffset(Vector2 imageDimensions){

		Vector2 scale = GetScale (imageDimensions);
		float x = _startX / imageDimensions.x;
		float y = 1 - (_startY / imageDimensions.y + scale.y);
		return new Vector2 (x, y);
	}



}
