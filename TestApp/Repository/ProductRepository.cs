using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestApp.Models;

namespace TestApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private DbContext context;
        private bool disposed = false;

        public ProductRepository(DbContext context)
        {
            this.context = context;
        }

        public int Add(Product productEntity)
        {
            context.Set<Product>().Add(productEntity);
            int numOfRecordsSaved = Save();
            if (numOfRecordsSaved == 1)
            {
                return productEntity.Id;
            }
            else return -1;
        }

        public int Delete(Product productEntity)
        {
            if (context.Entry(productEntity).State == EntityState.Detached)
            {
                context.Set<Product>().Attach(productEntity);
            }
            context.Set<Product>().Remove(productEntity);
            int numbOfRecordsDeleted = Save();
            if (numbOfRecordsDeleted == 1)
            {
                return 1;
            }
            else return -1;
        }

        public int Delete(int id)
        {
            Product ProductToDelete = context.Set<Product>().Find(id);
            if (ProductToDelete != null)
            {
                return Delete(ProductToDelete);
            }
            else
                return 0;
        }

        public IEnumerable<Product> FindBy(System.Linq.Expressions.Expression<Func<Product, bool>> predicate)
        {
            IQueryable<Product> query = context.Set<Product>().Where(predicate);
            return query.AsEnumerable();
        }

        public Product GetById(int? id)
        {
            return context.Set<Product>().Find(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            IQueryable<Product> query = context.Set<Product>();
            return query.AsEnumerable();
        }

        public int Update(Product productEntity)
        {
            context.Set<Product>().Attach(productEntity);
            context.Entry(productEntity).State = EntityState.Modified;
            int numOfRecordsSaved = Save();
            if (numOfRecordsSaved == 1)
            {
                return productEntity.Id;
            }
            else
                return -1;
        }

        public int Save()
        {
            int numberOfRowsChanged = 0;
            try
            {
                numberOfRowsChanged = context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            return numberOfRowsChanged;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}