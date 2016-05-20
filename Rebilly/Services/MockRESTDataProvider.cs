﻿using System.Collections.Generic;

namespace Rebilly.Services
{
    public class MockRESTDataProvider<TEntity> : DataProvider<TEntity>
    {
        public override IList<TEntity> Get(string path, Dictionary<string, string> arguments = null)
        {
            return null;
        }
    }
}