using System;
using System.Drawing;
using System.IO;

namespace WaveManagerApp
{
	public static class WaveMgr
	{
		public static Wave IsValid(string fileName)
		{
			string ext = Path.GetExtension(fileName).ToLower();
			if (ext != Wave.Extension)
				return null;
			
			Wave w = Read(fileName);
			//check if first 4 bytes is "RIFF" 
			if (w.Header[0] != 82 || w.Header[1] != 73 || w.Header[2] != 70 || w.Header[3] != 70)
			{
				return null;
			}
			return w;
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

		public static bool Save(Wave wave, string fileName)
		{
			byte[] wavebytes = new byte[wave.Header.Length + Wave.NSize + wave.Samples.Length];
			System.Buffer.BlockCopy(wave.Header, 0, wavebytes, 0, wave.Header.Length);
			System.Buffer.BlockCopy(BitConverter.GetBytes(wave.NumberOfSamples), 0, wavebytes, wave.Header.Length, Wave.NSize);
			System.Buffer.BlockCopy(wave.Samples, 0, wavebytes, wave.Header.Length + Wave.NSize, wave.Samples.Length);

			File.WriteAllBytes(fileName, wavebytes);

			return true;
		}

		
		


	
	}
}
