
using System;
namespace WaveManagerApp
{
	[Serializable]
	public class Wave
	{
		public const int HeaderSize = 40;
		public const int NSize = 4;
		public const int MaxSampleValue = 255;
		public const string Extension = ".wav";
		public const string DataObject = "wave";

		private string _fileName;
		private byte[] _header = new byte[HeaderSize];
		private int _numberOfSamples = 0;
		private byte[] _samples = null;


		public string FileName
		{
			get { return _fileName; }
			set { _fileName = value; }
		}

		public byte[] Header
		{
			get { return _header; }
			set { _header = value; }
		}

		public int NumberOfSamples
		{
			get { return _numberOfSamples; }
			set { _numberOfSamples = value; }
		}
		public byte[] Samples
		{
			get { return _samples; }
			set { _samples = value; }
		}

	}
}
