using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {

            // we will work with bison = Birary Json don't worry it is very simple !


            string connectionString = "mongodb://localhost";
            string databaseName = "csharp";
            Console.WriteLine(">>Create Get database");
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase(databaseName);
            //CreateDemo is a function where you want to create your collection (in relational databases) called tables
           // CreateDemo(database);


            //one minute please, here we want to update just one collection it is very simple follow these steps niahaha !
            Console.WriteLine("Update collection data by Bson Document");
            MongoCollection<BsonDocument> employees = database.GetCollection("employee");
            BsonDocument doc = employees.FindOne();
            foreach (string name in doc.Names)
            {
            BsonElement element = doc.GetElement(name);
            Console.WriteLine("{0}: {1}", name, element.Value);
            }
            doc.Set("name", BsonValue.Create("update-employee"));
            doc.Set("email", BsonValue.Create("update-employee@gmail.com"));
            employees.Save(doc);
            Console.WriteLine("updated data was success!");


            //(">>>read collection data by Bson document");
            //we want to show all the employees stored in the database
            MongoCollection<BsonDocument> employees1 = database.GetCollection("employee");
            foreach(BsonDocument doc1 in employees.FindAll())
            {
                foreach(string name in doc1.Names)
                {
                    BsonElement element = doc1.GetElement(name);
                    Console.WriteLine("{0}: {1}", name, element);

                }
                Console.WriteLine("");
            }
            //after outputing what we have written it is time to delete some collection data
            Console.WriteLine(">>>Delete all data in Employee collection");
            //MongoCollection<BsonDocument> employees = database.GetCollection("employee");
            CommandResult result = employees.Drop();
            if (result.Ok)
            {
                Console.WriteLine("deleted all data in employees collection was success");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }


            Console.Read();


        }

        private static void CreateDemo(MongoDatabase database)
        {
            Console.WriteLine(">>Create collection data by BSON Document");
            MongoCollection<BsonDocument> employees = database.GetCollection("employee");
            for (int i = 1; i <= 5; i++)
            {
                BsonDocument employee = new BsonDocument{
                    {"name","Employee "+i},
                    {"email",String.Format("email{0}@email.com",i)},
                    {"createddate",DateTime.Now}
              
             };
                employees.Insert(employee);


            }
        }
    }
}
         

 

