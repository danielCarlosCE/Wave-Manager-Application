using System.IO;

namespace WaveManagerApp
{
	public static class WaveMgr
	{
		public static bool IsValid(string fileName)
		{
			string ext = Path.GetExtension(fileName);
			if (ext == Wave.Extension)
				return true;
			return false;
		}

		public static Wave Read(string fileName)
		{
			Wave wave = new Wave();
			wave.FileName = fileName;

			BinaryReader br = new BinaryReader(File.OpenRead(fileName));
			using (br)
			{
				br.Read(wave.Header, 0, Wave.HeaderSize);
				wave.NumberOfSamples = br.ReadInt32();
				wave.Samples = new byte[wave.NumberOfSamples];
				br.Read(wave.Samples, 0, wave.NumberOfSamples);
			}

			return wave;
		}
	}
}
