`CCR.cs` contains C# classes to manipulate Continuity of Care Record (CCR) documents.

`Program.cs` is an example program that prints out the medications in a sample CCR file (`ccrsample_Allscripts.xml`)

http://medbi.blogspot.com/2008/02/creating-c-bindings-for-ccr-and-ccd.html

Example:

	using CCR;

	static void Main(string[] args)
	{
		ContinuityOfCareRecord ccr = Deserialize<ContinuityOfCareRecord>(@"ccrsample_Allscripts.xml");

		Console.WriteLine("CCRDocumentObjectID = {0}", ccr.CCRDocumentObjectID);

		foreach(var medication in ccr.Body.Medications)
			Console.WriteLine(medication.Product[0].ProductName.Text);
	}