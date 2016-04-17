using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace MusicManager
{
	/// <summary>
	/// Summary description for SerializeHelper.
	/// </summary>
	public class SerializeHelper
	{
		private static SerializeHelper helper;
		public SerializeHelper()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public static SerializeHelper GetHelper()
		{
			if(helper==null)
				helper=new SerializeHelper();
			return helper;
		}
        public void SaveFile(object obj, string FileName)
        {
            FileStream fs = new FileStream(FileName, FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(fs, obj);
            fs.Close();
        }
        public object ReadFile(string FileName)
        {
            FileStream fs = new FileStream(FileName, FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();
            object tempobjectdata = (object)bformatter.Deserialize(fs);
            fs.Close();
            return tempobjectdata;
        }
		public string Serialize(object obj)
		{
			try
			{
				MemoryStream stream=new MemoryStream();
				BinaryFormatter bformatter = new BinaryFormatter();
				bformatter.Serialize(stream, obj);
				byte [] bArray;
				bArray=stream.ToArray();
				stream.Position=0;
				string tempobjectdatastring=Convert.ToBase64String(bArray);
				stream.Close();
				return tempobjectdatastring;
			}
			catch(Exception e)
			{
				throw e;
			}
		}
		public object DeSerialize(string tempobjectdatastring)
		{
			try
			{
				byte [] bArray;	
				bArray=Convert.FromBase64String(tempobjectdatastring);
				MemoryStream stream=new MemoryStream();
				stream.Position=0;
				stream.Write(bArray,0,bArray.Length);
				stream.Position=0;
				BinaryFormatter bformatter = new BinaryFormatter();
				object tempobjectdata = (object)bformatter.Deserialize(stream);
				stream.Close();
				return tempobjectdata;
			}
			catch(Exception e)
			{
				throw e;
			}
		}
		public object MakeClone(object obj)
		{
			try
			{
				MemoryStream stream=new MemoryStream();
				BinaryFormatter bformatter = new BinaryFormatter();
				bformatter.Serialize(stream, obj);
				stream.Position=0;
				object tempobjectdata = (object)bformatter.Deserialize(stream);
				return tempobjectdata;
			}
			catch(Exception e)
			{
                throw e;
			}
		}
	}
}
