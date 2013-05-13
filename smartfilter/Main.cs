using System;
using System.IO;

namespace smartfilter
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var key = "key goes here";
			var whitelist = "whitelist goes here";
			var input = "the <script>alert('quick brown fox');</script> jumps over the lazy dog";
			var sf = new SmartFilter(key);

			try
			{
				Console.WriteLine("Verify: " + sf.Verify());
				Console.WriteLine("Info: " + sf.Info());
				Console.WriteLine("Detect: " + sf.Detect(input, whitelist));
				Console.WriteLine("Filter: " + sf.Filter(input, whitelist));
			}
			catch (NetworkException) 
			{
				Console.WriteLine("Exception: Network connectivity issue");
			}
			catch (BadInputParameter) 
			{
				Console.WriteLine("Exception: Bad input parameter");
			}
			catch (BadApiKey) 
			{
				Console.WriteLine("Exception: Bad API key");
			}
			catch (RequestTooLarge) 
			{
				Console.WriteLine("Exception: Request too large");
			}
			catch (InternalError) 
			{
				Console.WriteLine("Exception: Internal error");
			}
			catch (AccountQuotaExceeded) 
			{
				Console.WriteLine("Exception: Account quota exceeded");
			}
		}
	}
}
