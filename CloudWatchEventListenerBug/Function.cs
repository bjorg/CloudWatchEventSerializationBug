using System;
using System.Linq;
using Amazon.Lambda.CloudWatchEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace CloudWatchEventListener {

    public class EventDetails {

        //--- Properties ---
        public string Message { get; set; }
    }

    public class Function {

        //--- Methods ---
        public string FunctionHandler(CloudWatchEvent<EventDetails> request, ILambdaContext context) {
            Console.WriteLine($"Version = {request.Version}");
            Console.WriteLine($"Account = {request.Account}");
            Console.WriteLine($"Region = {request.Region}");
            Console.WriteLine($"Detail = {JsonConvert.SerializeObject(request.Detail)}");
            Console.WriteLine($"DetailType = {request.DetailType}");
            Console.WriteLine($"Source = {request.Source}");
            Console.WriteLine($"Time = {request.Time}");
            Console.WriteLine($"Id = {request.Id}");
            Console.WriteLine($"Resources = [{string.Join(",", request.Resources ?? Enumerable.Empty<string>())}]");
            return "Okay";
        }
    }
}
