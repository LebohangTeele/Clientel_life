using DB_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace DB_API.Repository
{
    public class CoffeeRepository : IRepository<Coffee, int>
    {
        private readonly DBEntities context;

        public CoffeeRepository(DBEntities context) => this.context = context;

        public bool Delete(int id)
        {
            try
            {
                if (!IfExists(id))
                {
                    return false;
                }
                var product = context.Coffees.Find(id);
                context.Coffees.Remove(product);
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Coffee Edit(Coffee entity)
        {
            try
            {
                context.Entry(entity);
                context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!IfExists(entity.CofID))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public IEnumerable<Coffee> GetAll()
        {
            try
            {
                return context.Coffees.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Coffee> GetbyId(int id)
        {
            try
            {
                if (!IfExists(id))
                {
                    return null;
                }
                return context.Coffees.Where(cv => cv.CofID == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IfExists(int id)
        {
            throw new NotImplementedException();
        }

        public Coffee Insert(Coffee entity)
        {
            try
            {
                context.Coffees.Add(entity);
                context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return entity;
        }
    }
}