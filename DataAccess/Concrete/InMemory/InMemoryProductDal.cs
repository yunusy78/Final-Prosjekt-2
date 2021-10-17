﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        private readonly List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product {ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15},
                new Product {ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3},
                new Product
                {
                    ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2
                },
                new Product {ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65},
                new Product {ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        // LINQ - Language Integratet Query
        // Lambda
        public void Delete(Product product)
        {
            /*Product productToDelete=null;  Bu kisma gerek yok LINQ kullandigimiz icin
            foreach (var p in _products)
            {
                if (product.ProductId == p.ProductId)
                {
                    productToDelete = p;
                }
                
            }*/

            var productToDelete =
                _products.SingleOrDefault(p =>
                    p.ProductId == product.ProductId); // Bu silme islemini guvenle gerceklestirir
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gonderdigim urun ID sine sahip olan listedeki urunu bul demek
            var productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
        }

        public List<Product> GetAll()
        {
            return _products; // veri tabanini donduruyorum
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        List<ProductDetailDto> IProductDal.GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}