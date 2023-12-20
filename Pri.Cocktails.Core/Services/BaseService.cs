using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Interfaces.Repositories;
using Pri.Cocktails.Core.Interfaces.Services;
using Pri.Cocktails.Core.Services.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Services
{
    public abstract class BaseService<Tinterface,Tclass>:IBaseService<Tclass> where Tinterface : IBaseRepository<Tclass> where Tclass : BaseEntity
    {
        protected readonly Tinterface _itemRepository;

        public BaseService(Tinterface itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ItemResultModel<Tclass>> GetAllAsync()
        {
            var items = await _itemRepository.GetAllAsync();
            var result = new ItemResultModel<Tclass>();

            if (items == null || !items.Any())
            {
                result.ValidationResults = new List<ValidationResult>
                {
                    new ValidationResult("Not Found!!")
                };
                return result;
            }

            result.IsSucces = true;
            result.Items = items;

            return result;
        }

        public async Task<ItemResultModel<Tclass>> GetByIdAsync(int id)
        {            
            var result = new ItemResultModel<Tclass>();

            if (id <= 0)
            {
                result.ValidationResults = new List<ValidationResult>
                {
                    new ValidationResult("Nothing is found")
                };
                return result;
            }

            var items = await _itemRepository.GetByIdAsync(id);

            if (items == null)
            {
                result.ValidationResults = new List<ValidationResult>
                {
                    new ValidationResult("Nothing is found")
                };
                return result;
            }

            result.Items = new List<Tclass> { items };
            result.IsSucces = true;
            return result;
        }       
        
    }
}
