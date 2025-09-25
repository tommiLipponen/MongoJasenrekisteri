using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoJäsenrekisteri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoJäsenrekisteri.Services
{
    public class JasenetServices
    {
        private readonly IMongoCollection<Jasenet> JasenData;

        public JasenetServices(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("JasenetKanta"));

            IMongoDatabase database = client.GetDatabase("JasenDB");

            JasenData = database.GetCollection<Jasenet>("JasenetCollection");
        }

        public IEnumerable<Jasenet> AllJasenet()
        {
            return JasenData.Find(X => true).ToList();
        }

        public void CreateJasen(Jasenet model)
        {
            JasenData.InsertOne(model);
        }

        public Jasenet GetOneJasen(string Id)
        {
            return JasenData.Find(X => X.Id == Id).FirstOrDefault();
        }

        public void EditJasen(string Id, Jasenet model)
        {
            JasenData.ReplaceOne(X => X.Id == Id, model);
        }

        public void DeleteJasen(Jasenet model)
        {
            JasenData.DeleteOne(X => X.Id == model.Id);
        }
    }
}
