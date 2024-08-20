using MongoDB.Driver;
using MongoDB.Bson;

var dbClient = new MongoClient("mongodb://localhost:27017");
IMongoDatabase db = dbClient.GetDatabase("StudentDB");
var std = db.GetCollection<BsonDocument>("Student");

var fil = Builders<BsonDocument>.Filter.Eq("StudentID", 101);
var dec = std.Find(fil).FirstOrDefault();



var studentCollection = db.GetCollection<BsonDocument>("Student");

// Create a new student document
var newStudent = new BsonDocument
{
    { "StudentID", 101 },
    { "Name", "John Doe" },
    { "Age", 21 },
    { "Major", "Computer Science" },
    { "EnrollmentDate", new BsonDateTime(DateTime.UtcNow) }
};

// Insert the document into the collection


int input=0;

Console.WriteLine("1: Insert, 2:Display, 3:Exit");
input = Convert.ToInt32(Console.ReadLine());

do
{
    switch (input)
    {
        case 1:
            studentCollection.InsertOne(newStudent); //==> Inserting One data
            Console.WriteLine("New student document inserted successfully.");
            break;

        case 2:
            Console.WriteLine(dec.ToString());
            break;

        case 3:
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Not Done!!!");
            break;
    }
}
while (input != 3);



