using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace WaveManagerApp
{
	class Preferences
	{
		private static Color _waveColor = Color.Green;
		private static Color _waveBgColor = Color.Black;
		private static float _thickness = 1;
		private static Color _fileViewBgColor = Color.White;
		private static Color _fileViewForeColor = Color.Black;
		private static Font _fileViewFont = new Font("Arial", 12);
		private static string[] _openedWaves = new string[0];
		
		private static XmlDocument xmlDoc = new XmlDocument();


		public static Color FileViewBgColor
		{
			get { return _fileViewBgColor ; }
			set { _fileViewBgColor = value; }
		}

		public static Color FileViewForeColor
		{
			get { return _fileViewForeColor; }
			set { _fileViewForeColor = value; }
		}

		public static Font FileViewFont
		{
			get { return _fileViewFont; }
			set { _fileViewFont = value; }
		}

		public static Color WaveBgColor 
		{
			get { return _waveBgColor; }
			set { _waveBgColor = value; }
		}
		public static Color WaveColor
		{
			get { return _waveColor; }
			set { _waveColor = value; }
		}

		public static float Thickness
		{
			get { return _thickness; }
			set { _thickness = value; }
		}

		public static string[] OpenedWaves
		{
			get { return _openedWaves; }
			set { _openedWaves = value; }
		}

		public static Pen PenForWave()
		{
			return new Pen(Preferences.WaveColor,_thickness);
		}

		public static void PersistPreferences()
		{
			#region XmlParse
			XmlNode rootNode = xmlDoc.CreateElement("preferences");
			xmlDoc.AppendChild(rootNode);

			Type type = typeof(Preferences); 
			foreach (var p in type.GetProperties())
			{
				if (p.Name != "xmlDoc") { 
					object o =  p.GetValue(null, null);
					if(o!=null)
					rootNode.AppendChild(createNode(p.Name,o));
				}
			}

			Console.Write(xmlDoc.InnerXml);
			xmlDoc.Save(".config.xml");
			#endregion

		}

		public static void LoadPreferences()
		{
			XmlDocument doc = new XmlDocument();
			if (!File.Exists(".config.xml")) { return; }
			doc.Load(".config.xml");
			Console.Write(doc.InnerXml);


			XElement root = XElement.Parse(doc.InnerXml);
			try{
			foreach (XElement element in root.Elements())
			{
				Type type = typeof(Preferences);
				foreach (var p in type.GetProperties())
				{
					if (p.Name == element.Name)
					{
						object o = p.GetValue(null, null);
						
						if (o is Color)
						{
							Color c = Color.FromArgb(int.Parse(element.Value));
							p.SetValue(o, c );
						}
						else if (o is Font)
						{
							p.SetValue(o, GetFont(element));
						}
						else if (o is float)
						{
							p.SetValue(o, float.Parse(element.Value));
						}
						else if (o is string[])
						{
							List<string> atts = new List<string>();
							foreach (XElement n in element.Elements())
							{
								atts.Add(n.Value);
							}
							p.SetValue(null, atts.ToArray());
						}
						break;
					}
				}
			}
			Console.Write(Preferences.FileViewBgColor);

			}catch(Exception ex){
				Console.WriteLine(ex.Message);
			}
		}

		private static XmlNode createNode(string name, object obj )
		{

			XmlNode node = xmlDoc.CreateElement(name);


			if (obj is Color)
			{
				node.InnerText = ((Color)obj).ToArgb().ToString();

			}
			else
			if (obj is Font)
			{
				ParseFont((Font)obj,node);
			}
			else if (obj is string[])
			{
				foreach (string s in (string[])obj)
				{
					XmlNode n = xmlDoc.CreateElement("directory");
					n.InnerText = s;
					node.AppendChild(n);
				}
			}
			else
			{
				node.InnerText = obj.ToString();
			}

		
			return node;
		}

		private static void ParseFont(Font f, XmlNode node)
		{
			XmlAttribute attribute = xmlDoc.CreateAttribute("family");
			attribute.Value = f.FontFamily.Name;
			node.Attributes.Append(attribute);
			attribute = xmlDoc.CreateAttribute("style");
			attribute.Value = f.Style.ToString();
			node.Attributes.Append(attribute);
			attribute = xmlDoc.CreateAttribute("size");
			attribute.Value = f.Size.ToString();
			node.Attributes.Append(attribute);
			attribute = xmlDoc.CreateAttribute("script");
			attribute.Value = System.Convert.ToString(f.GdiCharSet); 
			node.Attributes.Append(attribute);
		}
		
		private static Font GetFont(XElement element)
		{
			string family = element.Attribute("family").Value;
			float size = float.Parse(element.Attribute("size").Value);
			FontStyle style = GetFontStyle(element.Attribute("style").Value);
			byte script = System.Convert.ToByte(element.Attribute("script").Value) ;
			Font f = new Font(family,
				size,
				style,
				GraphicsUnit.Point,
				script );
			return f;
		}

		private static FontStyle GetFontStyle(string style)
		{
			FontStyle fontStyle = new FontStyle();
			if (style.Contains("Italic"))
			{
				fontStyle |= FontStyle.Italic;
			}
			if (style.Contains("Bold"))
			{
				fontStyle |= FontStyle.Bold;
			}
			if (style.Contains("Regular"))
			{
				fontStyle |= FontStyle.Regular;
			}
			if (style.Contains("Strikeout"))
			{
				fontStyle |= FontStyle.Strikeout;
			}
			if (style.Contains("Underline"))
			{
				fontStyle |= FontStyle.Underline;
			}

			return fontStyle;

			
		}
		
	}
}
