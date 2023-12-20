using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Interfaces.Repositories;
using Pri.Cocktails.Core.Interfaces.Services;
using Pri.Cocktails.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Services
{
    public class MeasuringUnitService : BaseService<IMeasuringUnitRepository,MeasuringUnit>,IMeasuringUnitService
    {
        private readonly ICocktailRepository _cocktailRepository;

        public MeasuringUnitService(IMeasuringUnitRepository measuringUnitRepository,ICocktailRepository cocktailRepository):base(measuringUnitRepository)
        {
            _cocktailRepository = cocktailRepository;
        }

        public async Task<ItemResultModel<MeasuringUnit>> AddAsync(string name)
        {
            var measuringUnit = new MeasuringUnit { Name = name };

            if (! await _itemRepository.AddAsync(measuringUnit))
            {
                return new ItemResultModel<MeasuringUnit>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Something went wrong!")
                    }
                };
            }

            return new ItemResultModel<MeasuringUnit> { IsSucces = true };
        }

        public async Task<ItemResultModel<MeasuringUnit>> UpdateAsync(int id, string name)
        {
            var measuringUnit = await _itemRepository.GetByIdAsync(id);

            if(measuringUnit == null)
            {
                return new ItemResultModel<MeasuringUnit>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Something went wrong!")
                    }
                };
            }

            measuringUnit.Name = name;

            if (!await _itemRepository.UpdateAsync(measuringUnit))
            {
                return new ItemResultModel<MeasuringUnit>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Something went wrong!")
                    }
                };
            }

            return new ItemResultModel<MeasuringUnit> { IsSucces= true };
        }

        public async Task<ItemResultModel<MeasuringUnit>> DeleteAsync(int id)
        {
            var measuringUnit = await _itemRepository.GetByIdAsync(id);
            if (measuringUnit == null)
            {
                return new ItemResultModel<MeasuringUnit>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Measuring unit do's not exists!!")
                    }
                };
            }
            //prevent deletion when cocktails are using this
            bool haseCocktails = _cocktailRepository.GetAll().Any(c => c.CocktailIngredient
                                                                            .Select(ci => ci.MeasuringUnitId)
                                                                            .Contains(id)
                                                                            );

            if (haseCocktails)
            {
                return new ItemResultModel<MeasuringUnit>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Can not delete beceause some cocktails are using this!!")
                    }
                };
            }

            await _itemRepository.DeleteAsync(measuringUnit);
            return new ItemResultModel<MeasuringUnit> { IsSucces = true };
        }
    }
}
