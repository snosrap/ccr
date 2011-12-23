# C\# Class

`CCR.cs` contains C# classes to manipulate Continuity of Care Record (CCR) documents.  It was generated using `xsd.exe`, the `CCR.xsd` file and some instructions at http://medbi.blogspot.com/2008/02/creating-c-bindings-for-ccr-and-ccd.html.

`CCRTest.cs` is an example program that prints out the medications in a sample CCR file (`ccrsample_Allscripts.xml`)

Example:

	using CCR;

	static void Main(string[] args)
	{
		ContinuityOfCareRecord ccr = Deserialize<ContinuityOfCareRecord>(@"ccrsample_Allscripts.xml");

		Console.WriteLine("CCRDocumentObjectID = {0}", ccr.CCRDocumentObjectID);

		foreach(var medication in ccr.Body.Medications)
			Console.WriteLine(medication.Product[0].ProductName.Text);
	}

# XSL Transform

`ccr.xsl` is a modified version of AAFP's XSL file that renders dates better.  In the AAFP XSLT file, ISO-8601 dates like "2010-06-19" render as "Jan 01, 2010". This modified XSLT renders dates correctly: ("Jun 19, 2010").

The diff looks vast, but changes are solely the result of pasting in the exact code from date.format-date.template.xsl.  Once the XML is normalized, the diff boils down to:

	1960c1960,1962
	-                 <xsl:value-of select="$tz"/>
	---
	+                 <xsl:if test="(substring($tz, 1, 1) = '-' or substring($tz, 1, 1) = '+') and substring($tz, 4, 1) = ':'">
	+                   <xsl:value-of select="$tz" />
	+                 </xsl:if>
