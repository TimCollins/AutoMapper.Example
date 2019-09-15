using System;
using App.DTO;
using App.Model;
using AutoMapper;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            BoringWay();
            BetterWay();
            FlatteningExample();
            Utils.WaitForEscape();
        }

        private static void FlatteningExample()
        {
            // Define a complex model
            var customer = new Customer
            {
                Name = "Homer Simpson"
            };

            var order = new Order
            {
                Customer = customer
            };

            var box = new Product
            {
                Name = "Box",
                Price = 4.99M
            };

            order.AddLineItem(box, 15);

            // Configure AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>());
            var mapper = config.CreateMapper();

            // Perform the mapping
            // The complex Order object containing Customer, Product and OrderLineItem instances is simplified
            // to a DTO containing just Name and Total
            var dto = mapper.Map<Order, OrderDTO>(order);

            // Here an assertion as to the content could be done but this will just output the data
            Console.WriteLine("Flattening Example:");
            Console.WriteLine($"Name: {dto.CustomerName}, Total: €{dto.Total}");
        }

        private static void BoringWay()
        {
            var dto = GetCategoryDTO(1);
            Display(dto);
        }

        private static void BetterWay()
        {
            // This should happen during startup, not be buried in a method
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>());
            // The mapper could also be extracted to a higher level
            var mapper = config.CreateMapper();

            var category = GetCategory(1);
            // The mapping between objects is done automatically here. No need to write anything else
            var dto = mapper.Map<CategoryDTO>(category);
            Display(dto);
        }

        private static void Display(CategoryDTO category)
        {
            Console.WriteLine("Name: {0}", category.CategoryName);
            Console.WriteLine("Description: {0}", category.Description);
            Console.WriteLine("PictureUrl: {0}", category.PictureUrl);
        }

        // Imagine this function is part of the data-access layer and communicating with a real database
        private static Category GetCategory(int id)
        {
            return new Category
            {
                CategoryID = id,
                CategoryName = "Test Category",
                Description = "A test category used for testing",
                PictureUrl = "https://www.example.com/picture.jpg"
            };
        }

        private static CategoryDTO GetCategoryDTO(int id)
        {
            var category = GetCategory(1);

            // This mapping function has to be written manually
            var categoryDTO = MapCategoryToDTO(category);

            return categoryDTO;
        }

        private static CategoryDTO MapCategoryToDTO(Category cat)
        {
            return new CategoryDTO
            {
                CategoryID = cat.CategoryID,
                CategoryName = cat.CategoryName,
                Description = cat.Description,
                PictureUrl = cat.PictureUrl
            };
        }
    }
}
