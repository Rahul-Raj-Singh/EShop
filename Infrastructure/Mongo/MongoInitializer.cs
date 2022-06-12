using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Conventions;

namespace EShop.Infrastructure.Mongo
{
    public class MongoInitializer
    {
        private bool _isInitialized;
        public void Initialize()
        {
            if (_isInitialized) return;

            IConventionPack conventionPack = new ConventionPack 
            {
                new IgnoreExtraElementsConvention(true),
                new CamelCaseElementNameConvention(),
                new EnumRepresentationConvention(MongoDB.Bson.BsonType.String)
            };

            ConventionRegistry.Register("EShop", conventionPack, _ => true);

            _isInitialized = true;

        }
    }
}