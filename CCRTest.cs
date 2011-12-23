using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using CCR;

namespace CCRTest
{
	class Program
	{
		static void Main(string[] args)
		{
			ContinuityOfCareRecord ccr = Deserialize<ContinuityOfCareRecord>(@"ccrsample_Allscripts.xml");

			Console.WriteLine("CCRDocumentObjectID = {0}", ccr.CCRDocumentObjectID);

			foreach(var medication in ccr.Body.Medications)
				Console.WriteLine(medication.Product[0].ProductName.Text);
		}

		public static T Deserialize<T>(string pathName)
		{
			using (TextReader reader = new StreamReader(pathName))
				return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
		}
	}
}
