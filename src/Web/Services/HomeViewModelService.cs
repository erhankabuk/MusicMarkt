using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specification;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.Models;

namespace Web.Services
{
    public class HomeViewModelService : IHomeViewModelService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Brand> _brandRepository;

        public HomeViewModelService(IRepository<Product> productRepository, IRepository<Category> categoryRepository, IRepository<Brand> brandRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
        }



        public async Task<HomeViewModel> GetHomeViewModelAsync(int? categoryId, int? brandId)
        {
            var specProducts = new ProductsFilterSpecification(categoryId, brandId);
            var list = (await _productRepository.ListAsync(specProducts))
                .Select(x => new ProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PictureUri = x.PictureUri,
                    Price = x.Price
                }).ToList();


            var vm = new HomeViewModel()
            {
                Products = list,
                Categories = (await _categoryRepository.ListAllAsync())
                .Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList(),
                Brands = (await _brandRepository.ListAllAsync())
                .Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList(),
                BrandId=brandId,
                CategoryId=categoryId

            };

            return vm;
        }

       
    }
}
