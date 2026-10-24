using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ACE.Classes.ACE_Extra;

public static class BinarySerializerSafe
{
	public static void WriteToBinaryFile<T>(string filePath, T objectToWrite)
	{
		using FileStream fileStream = File.Create(filePath);
		new BinaryFormatter().Serialize(fileStream, objectToWrite);
		fileStream.Close();
	}

	public static T ReadFromBinaryFile<T>(string filePath)
	{
		using FileStream fileStream = File.OpenRead(filePath);
		T result = (T)new BinaryFormatter().Deserialize(fileStream);
		fileStream.Close();
		return result;
	}

	public static byte[] SerializeStruct<T>(T objectToWrite)
	{
		MemoryStream memoryStream = new MemoryStream();
		new BinaryFormatter().Serialize(memoryStream, objectToWrite);
		byte[] result = memoryStream.ToArray();
		memoryStream.Close();
		return result;
	}

	public static T DeserializeStruct<T>(byte[] bytes)
	{
		MemoryStream memoryStream = new MemoryStream(bytes);
		try
		{
			T result = (T)new BinaryFormatter().Deserialize(memoryStream);
			memoryStream.Close();
			return result;
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}
}
