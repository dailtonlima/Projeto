using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public class XMLParser {

	public static List<SpriteSheetInfo> Parse(TextAsset xml)
	{
		XmlReader reader = XmlReader.Create (new StringReader (xml.text));
		Dictionary<string,SpriteRect> current = new Dictionary<string, SpriteRect> ();
		string currentSpriteName = string.Empty;
		int currentRect = 0;

		List<SpriteSheetInfo> info = new List<SpriteSheetInfo> ();
		while (reader.Read()) {
			if(reader.IsStartElement("sprite"))
			{
				if(current.Count > 0){
					info.Add(new SpriteSheetInfo(current,currentSpriteName));
					currentRect = 0;
					current.Clear();
				}

				currentSpriteName = reader.GetAttribute("name");

			}else{
				if(reader.IsStartElement("rect")){
					string rectName = reader.GetAttribute("name");
					if(string.IsNullOrEmpty(rectName)){
						rectName = currentRect.ToString();
					}

					string[] content = reader.ReadElementString().Split(',');
					current.Add(rectName,new SpriteRect(int.Parse(content[0]),
					                                    int.Parse(content[1]),
					                                    int.Parse(content[2]),
					                                    int.Parse(content[3])));
					currentRect++;
				}
			}
		}

		if(current.Count > 0){
			info.Add(new SpriteSheetInfo(current,currentSpriteName));
		}

		reader.Close ();
		return info;
	}
}
