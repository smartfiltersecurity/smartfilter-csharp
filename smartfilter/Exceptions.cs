using System;

namespace smartfilter
{
	public class NetworkException : Exception { }
	public class BadInputParameter : Exception { }
	public class BadApiKey : Exception { }
	public class RequestTooLarge : Exception { }
	public class InternalError : Exception { }
	public class AccountQuotaExceeded : Exception { }
}

