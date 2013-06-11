using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace RestSharp.Deserializers
{
	public class DynamicJsonDeserializer : IDeserializer
	{
		public string RootElement { get; set; }
		public string Namespace { get; set; }
		public string DateFormat { get; set; }
		
		public T Deserialize<T>(IRestResponse response)
		{
			return JsonConvert.DeserializeObject<dynamic>(response.Content);
		}
	}
}

namespace smartfilter
{
	public class SmartFilter
	{
		public string key;
		public string apiBase;
		
		public SmartFilter(string key)
		{
			this.key = key;
			this.apiBase = "https://api.prevoty.com/1";
		}

		// Endpoint: /key/verify
		public bool Verify()
		{
			var client = new RestClient(this.apiBase);
			client.AddHandler("application/json", new RestSharp.Deserializers.DynamicJsonDeserializer());
			
			var request = new RestRequest("/key/verify", Method.GET);
			request.RequestFormat = DataFormat.Json;
			request.AddParameter("api_key", this.key);

			var response = client.Execute<dynamic>(request);
			int status = (int)response.StatusCode;
			
			switch (status)
			{
			case 200:
				return true;
			case 400:
				throw new BadInputParameter();
			case 403:
				throw new BadApiKey();
			case 413:
				throw new RequestTooLarge();
			case 500:
				throw new InternalError();
			case 507:
				throw new AccountQuotaExceeded();
			default:
				throw new NetworkException();
			}
		}

		// Endpoint: /key/info
		public dynamic Info()
		{
			var client = new RestClient(this.apiBase);
			client.AddHandler("application/json", new RestSharp.Deserializers.DynamicJsonDeserializer());
			
			var request = new RestRequest("/key/info", Method.GET);
			request.RequestFormat = DataFormat.Json;
			request.AddParameter("api_key", this.key);
			
			var response = client.Execute<dynamic>(request);
			int status = (int)response.StatusCode;
			
			switch (status)
			{
			case 200:
				return response.Data;
			case 400:
				throw new BadInputParameter();
			case 403:
				throw new BadApiKey();
			case 500:
				throw new InternalError();
			default:
				throw new NetworkException();
			}
		}

		// Endpoint: /rule/verify
		public bool VerifyRule(string ruleKey)
		{
			var client = new RestClient(this.apiBase);
			client.AddHandler("application/json", new RestSharp.Deserializers.DynamicJsonDeserializer());

			var request = new RestRequest("/rule/verify", Method.GET);
			request.RequestFormat = DataFormat.Json;
			request.AddParameter("api_key", this.key);
			request.AddParameter("rule_key", ruleKey);

			var response = client.Execute<dynamic>(request);
			int status = (int)response.StatusCode;

			switch (status)
			{
				case 200:
				return true;
				case 400:
				throw new BadInputParameter();
				case 403:
				throw new BadApiKey();
				case 413:
				throw new RequestTooLarge();
				case 500:
				throw new InternalError();
				case 507:
				throw new AccountQuotaExceeded();
				default:
				throw new NetworkException();
			}
		}

		// Endpoint: /xss/filter
		public dynamic Filter(string input, string ruleKey)
		{
			var client = new RestClient(this.apiBase);
			client.AddHandler("application/json", new RestSharp.Deserializers.DynamicJsonDeserializer());
			
			var request = new RestRequest("/xss/filter", Method.POST);
			request.RequestFormat = DataFormat.Json;
			request.AddParameter("api_key", this.key);
			request.AddParameter("input", input);
			request.AddParameter("rule_key", ruleKey);
			
			var response = client.Execute<dynamic>(request);
			int status = (int)response.StatusCode;

			Console.WriteLine(response.Content);
			
			switch (status)
			{
			case 200:
				return response.Data;
			case 400:
				throw new BadInputParameter();
			case 403:
				throw new BadApiKey();
			case 413:
				throw new RequestTooLarge();
			case 500:
				throw new InternalError();
			case 507:
				throw new AccountQuotaExceeded();
			default:
				throw new NetworkException();
			}
		}
	}
}

