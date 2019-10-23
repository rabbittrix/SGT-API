 using System.Collections.Generic;
 using System.Collections;
 using SGTwebAPI.Database;
 using static System.Console;

 namespace SGTwebAPI {

     /// <summary>
     /// Examples
     /// </summary>
     public class Program {
         /// <summary>
         /// Main Method
         /// </summary>
         public static void Main () {

             //Option to go all at once
             // ArrayList Itens = [21325295, 21322517, 21310867, 21316305, 21297462, 21299546, 21318184, 21323292, 21306597, 21310697, 21310030, 21302498, 21313816, 21324768, 21321430, 21314282, 21298383, 21303181];

             //Instanciating with base URL
             FirebaseDB firebaseDB = new FirebaseDB ("https://hacker-news.firebaseio.com/v0/item");
             /*
              for (int i = 0; i < Itens.Size (); i++) {
                  //Para cada item percorrido você vai atribuir o valor na variavel indice;
                  int indice = Itens.get (i);
             */
             //Referring to Node with name "Item"
             FirebaseDB firebaseDBTeams = firebaseDB.Node ("21325295.json?print=pretty");

             var data = @"{
                                'item': {
                                    'id': {
                                        'title': 'A uBlock Origin update was rejected from the Chrome Web Store',
                                        'uri': 'https://github.com/uBlockOrigin/uBlock-issues/issues/',
                                        'postedBy': 'ismaildonmez',
                                        'time': '2019-10-12T13:43:01+00:00'
                                        'score': '1716',
                                        'commentCount': '572'
                                        }
                                   }

                          }";

             WriteLine ("GET Request");
             FirebaseResponse getResponse = firebaseDBTeams.Get ();
             WriteLine (getResponse.Success);
             if (getResponse.Success)
                 WriteLine (getResponse.JSONContent);
             WriteLine ();

             WriteLine ("PUT Request");
             FirebaseResponse putResponse = firebaseDBTeams.Put (data);
             WriteLine (putResponse.Success);
             WriteLine ();

             WriteLine ("POST Request");
             FirebaseResponse postResponse = firebaseDBTeams.Post (data);
             WriteLine (postResponse.Success);
             WriteLine ();

             WriteLine ("PATCH Request");
             FirebaseResponse patchResponse = firebaseDBTeams
                 // Use of NodePath to refer path lnager than a single Node
                 .NodePath ("21312609.json?print=pretty/21323663.json?print=pretty")
                 .Patch ("{\"Designation\":\"CRM Consultant\"}");
             WriteLine (patchResponse.Success);
             WriteLine ();

             WriteLine ("DELETE Request");
             FirebaseResponse deleteResponse = firebaseDBTeams.Delete ();
             WriteLine (deleteResponse.Success);
             WriteLine ();

             WriteLine (firebaseDBTeams.ToString ());
             ReadLine ();
         }
     }
 }

 /*
 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using Microsoft.AspNetCore.Hosting;
 using Microsoft.Extensions.Configuration;
 using Microsoft.Extensions.Hosting;
 using Microsoft.Extensions.Logging;

 namespace SGTwebAPI
 {
     public class Program
     {
         public static void Main(string[] args)
         {
             CreateHostBuilder(args).Build().Run();
         }

         public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 });
     }
 }
 */