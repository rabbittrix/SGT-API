# SGT-API

First dotnet build after dotnet run

You can modify the search method in Program.cs, I left this option as it is a free API and also has the TodoItem.cs API that can connect to SQLServer or another relational database, so you have the option of non relational Firebase and relational DB. Then I will improve more, because I did the rush, more can send suggestions.
Have fun.

Firebase API Create folder Database and add 4 classes as follows.

FirebaseDB.cs FirebaseRequest.cs FirebaseResponse.cs UtilityHelper.cs Let’s look into each file one by one.

FirebaseDB is main class user interacts with, it exposes the API to be consumed by user of library. It’s constructor takes baseURI of Firebase Database as parameter and assigns to RootNode private property. Class is using Method Chaining to maintain resource URI with the help of Node() & NodePath() They are taking string as input and appending to RootNode and returns FirebaseDB object with combined URI. Here Node can take only single node whether NodePath is for multiple Nodes. Class has methods for each Firebase supported HTTP method which are returning FirebaseResponse Put, Post & Patch methods are having parameter to accept JSON data as string, whether Get & Delete don’t need it. They all are instantiating FirebaseRequest with HttpMethod object according to request type, resource URI as RootNode and optional parameter jsonData as string. ToString() is overridden here to return current resource URI.

FirebaseRequet class is where actual magic happens. Constructor takes Http Method, Firebase URI and optional JSON data as parameter. It also appends .json to URI which is necessary to make REST calls, In base base URI it should be /.json while URI with any Node needs only .json to be appended. Execute() is responsible for making HTTP calls with help of RequestHelper() of UtilityHelper It validates URI and JSON data, if invalid then it returns FirebaseResponse with Success=False and proper ErrorMessage. If all parameters are valid, it makes HTTP calls, and forms FirebaseResponse object and returns it. If Request if of type GET then it parses response content to string and appends it to FirebaseResponse object to be returned to caller. RequestHelper() is an Asynchronous method, which is returns Task, but in Execute method with use of Wait() and Result we are handling it synchronously. In further enhancement Asynchronous API will also be exposed to consumer.

FirebaseResponse represents output of API calls against FirebaseDB. It contains 4 public properties as follows.

Success JSONContent ErrorMessage HttpResponse In Firebase.Net I have tried to not surprise the consumer by throwing any unexpected error, so FirebaseResponse has boolean property Success, which tells you whether call is successful or not, along with proper message in ErrorMessage Error will not always be a Http Error, it could be related to invalid JSON or improper URI also, they both are handled here. If HTTP call is successful Success will have True, ErrorMessage will be null, HttpResponse will contain complete HttpResponseMessage and if request type is GET then JSONContent will contain the response JSON as string.

UtilityHelper contains 3 static methods to keep our keep running. ValidateURI() takes URI as string and validates it using TryCreate() of Uri class and returns Boolean. TryParseJSON() validates and format JSON string, Firebase does not allow JSON which uses single quotes instead of double quotes, but in C# most people will pass in single quotes because of multiline support, very few will use escape character for double quotes. That’s why I’m parsing it which validates JSON as well as calling ToString() on JToken object will returns me well formatted JSON in double quotes. If valid returns True and out parameter output contains Formatted JSON. If invalid then returns False and out parameter output contains Error Message. RequestHelper() is an asynchrnous method, which is responsibe for making all HTTP calls to Firebase Database.

Now update your Program.cs with following code.

Here, I am calling all the methods in API. First I am instantiating FirebaseDB object with base URI of my Firebase App, you may replace it with your App URI. Then in next line Node(“Teams”) is used to point object to a different resource URI.
“Item” don’t need to be already available in your Firebase database. Then we have some JSON data in which is a multiline JSON string using single quotes,
It is supported in Library but Firebase. So you can use it here. Next, we have "Get() call" which is returning FirebaseResponse in getResponse.
It is always a good idea to verify success before calling getResponse.JSONContent, like I am doing here. Now we are calling Put() & Post() with given data,
behaviour of these HTTP calls is already described in Section 2. Patch() is interesting here because of 2 reasons, First it is used along with NodePath() which is accessing 3 nodes depth. And second JSON data is passed using escape characters for double quotes, which is how Firebase actually accepts data. 
Now "Delete()" called a method which deletes complete JSON tree at given URI. Finally ToString() method prints current resource URI of Firebase Database.
