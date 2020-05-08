using demoMongoDB.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace demoMongoDB.Services
{
    public class ProdutoService
    {
        private readonly IMongoCollection<Produto> _Produtos;

        public ProdutoService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Produtos = database.GetCollection<Produto>(settings.ProdutosCollectionName);
        }

        public List<Produto> Get() =>
            _Produtos.Find(Produto => true).ToList();

        public Produto Get(string id) =>
            _Produtos.Find<Produto>(Produto => Produto.Id == id).FirstOrDefault();

        public Produto Create(Produto Produto)
        {
            _Produtos.InsertOne(Produto);
            return Produto;
        }

        public void Update(string id, Produto ProdutoIn) =>
            _Produtos.ReplaceOne(Produto => Produto.Id == id, ProdutoIn);

        public void Remove(Produto ProdutoIn) =>
            _Produtos.DeleteOne(Produto => Produto.Id == ProdutoIn.Id);

        public void Remove(string id) => 
            _Produtos.DeleteOne(Produto => Produto.Id == id);
    }
}