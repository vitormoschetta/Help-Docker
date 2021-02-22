using System;
using Domain.Commands;
using Domain.Contracts.Handlers;
using Domain.Contracts.Repositories;
using Domain.Entities;

namespace Domain.Handlers
{
    public class ProductHandler : Notifiable, IProductHandler
    {
        private readonly IProductRepository _repository;
        public ProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        
        public CommandResult Create(ProductCreateCommand command)
        {
            var exist = _repository.Exists(command.Name);
            if (exist) 
                return new CommandResult(false, "Já existe um Produto cadastrado com esse Nome. ", command);                
                
            var product = new Product(command.Name, command.Price);

            AddNotifications(product);
            if (Invalid)
                return new CommandResult(false, string.Join(". ", Notifications));

            _repository.Create(product);

            return new CommandResult(true, "Produto cadastrado com sucesso! ", product);
        }
        
        public CommandResult Update(ProductUpdateCommand command)
        {
            var product = _repository.GetById(command.Id);     
            if (product == null) 
                return new CommandResult(false, "Produto não encontrado na base de dados. ", null);

            var exist = _repository.ExistsUpdate(command.Name, command.Id);
            if (exist)
                return new CommandResult(false, "Já existe outro Produto cadatrado com esse Nome. ", null);

            product.Update(command.Name, command.Price);

            AddNotifications(product);
            if (Invalid)
                return new CommandResult(false, string.Join(". ", Notifications));           

            _repository.Update(product);

            return new CommandResult(true, "Produto atualizado com sucesso!. ", product);
        }

        public CommandResult AddPromotion(ProductPromotionCommand command)
        {
            var product = _repository.GetById(command.Id);     
            if (product == null) 
                return new CommandResult(false, "Produto não encontrado na base de dados. ", null);           

            product.AddPromotion(command.Price);

            AddNotifications(product);
            if (Invalid)
                return new CommandResult(false, string.Join(". ", Notifications));           

            _repository.Update(product);

            return new CommandResult(true, "Preço do Produto atualizado com sucesso! ", product);
        }

        public CommandResult Delete(string id)
        {
            var product = _repository.GetById(id);
            if (product == null)
                return new CommandResult(false, "Produto não encontrado na base de dados. ", null);

            _repository.Delete(product.Id);

            return new CommandResult(true, "Produco excluído com sucesso! ", product);
        }

    }
}