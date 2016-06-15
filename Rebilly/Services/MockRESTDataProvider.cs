﻿using System.Collections.Generic;

using Rebilly.Entities;

namespace Rebilly.Services
{
    public class MockRESTDataProvider<TEntity> : DataProvider<TEntity> where TEntity : IEntity
    {
        public override IList<TEntity> Get(string path, Dictionary<string, string> arguments = null)
        {
            return null;
        }


        public override TEntity Create(string path, TEntity entity)
        {
            return entity;
        }


        public override TEntity Update(string path, TEntity entity)
        {
            return entity;
        }


        public override void Delete(string path, TEntity entity)
        {

        }
    }
}
