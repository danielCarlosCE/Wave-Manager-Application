
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

		public static Wave CopyWave(Wave wave)
		{

			if (wave == null)
				return null;

			Wave newWave = new Wave();
			newWave.Header = wave.Header;
			newWave.NumberOfSamples = wave.NumberOfSamples;
			newWave.FileName = wave.FileName;
			newWave.Samples = new byte[wave.NumberOfSamples];
			for (int i = 0; i < wave.Samples.Length; i++ )
			{
				newWave.Samples[i] = wave.Samples[i];
			}
			return newWave;

		}

		public  bool Equals(Wave wave)
		{
			if (wave == null)
				return false;
			for (int i = 0; i < wave.Header.Length; i++)
			{
				if (this.Header[i] != wave.Header[i])
					return false;
			}
			if (this.NumberOfSamples != wave.NumberOfSamples)
				return false;
			if(	this.FileName != wave.FileName) 
				return false;
			for (int i = 0; i < wave.Samples.Length; i++)
			{
				if (this.Samples[i] != wave.Samples[i])
					return false;
			}

			return true;

		}

	}
}
