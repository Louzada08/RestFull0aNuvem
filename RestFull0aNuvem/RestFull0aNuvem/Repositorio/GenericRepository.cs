using Microsoft.EntityFrameworkCore;
using RestFull0aNuvem.Model.Base;
using RestFull0aNuvem.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestFull0aNuvem.Repositorio
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly BdFoodContext _context;
        private DbSet<T> dataset;

        public GenericRepository(BdFoodContext context)
        {
            _context = context;
            dataset = context.Set<T>();
        }

        public T Create(T objT)
        {
            try
            {
                dataset.Add(objT);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objT;
        }

        public T Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null) dataset.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool Existe(long? id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<T> FindPage(int pagina, int tamanhoPagina)
        {
            List<T> usuarios = dataset.ToList();
            return usuarios;
        }

        public T Update(T objT)
        {
            if (!Existe(objT.Id)) return null;
            var result = dataset.SingleOrDefault(p => p.Id.Equals(objT.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(objT);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objT;
        }
    }
}
