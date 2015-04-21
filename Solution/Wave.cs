
namespace WaveManagerApp
{
	public class Wave
	{
		public const int HeaderSize = 40;
		public const int MaxSampleValue = 255;
		public const string Extension = ".wav";

		private byte[] _header = new byte[HeaderSize];
		private int _numberOfSamples = 0;
		private byte[] _samples = null;

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
