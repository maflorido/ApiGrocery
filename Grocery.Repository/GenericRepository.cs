﻿using Grocery.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace Grocery.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> 
        where T : class
    {
        private GroceryContext dbContext = new GroceryContext();

        public void Editar(T objeto)
        {
            this.dbContext.Entry(objeto).State = EntityState.Modified;
        }

        public void Excluir(T objeto)
        {
            this.dbContext.Set<T>().Remove(objeto);
        }

        public List<T> Filtrar(Expression<Func<T, bool>> filtro)
        {
            var query = from a in this.dbContext.Set<T>().Where(filtro)
                        select a;

            return query.ToListAsync().Result;
        }

        public void Incluir(T objeto)
        {
            this.dbContext.Set<T>().Add(objeto);
        }

        public List<T> Listar()
        {
            return this.dbContext.Set<T>().ToListAsync().Result;
        }

        public T Obter(long id)
        {
            return this.dbContext.Set<T>().FindAsync(id).Result;
        }
    }
}
