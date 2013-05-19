using System;
using System.IO;

namespace smartfilter
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var apiKey = "api key goes here";
			var ruleKey = "rule key goes here";
			var input = "the <script>alert('quick brown fox');</script> jumps over the lazy dog & mouse";
			var sf = new SmartFilter(apiKey);

			try
			{
				Console.WriteLine("Verify: " + sf.Verify());
				Console.WriteLine("Info: " + sf.Info());
				Console.WriteLine("Verify Rule: " + sf.VerifyRule(ruleKey));
				Console.WriteLine("Filter: " + sf.Filter(input, ruleKey));
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
