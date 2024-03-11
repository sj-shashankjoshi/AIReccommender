using AIReccommender.DataLoader;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIReccommender.Entities;
using AIReccommender.DataAggregator;
using AIReccommender.DataLoader;

namespace AIReccommender.UIClient
{
    public class DataLoaderFactory
    {
        protected DataLoaderFactory() 
        {
            
        }
        public static readonly DataLoaderFactory Instance = new DataLoaderFactory();

        public virtual IDataLoader GetDataLoader() 
        {
            string className = ConfigurationManager.AppSettings["DL"];
            Type loaderType = Type.GetType(className);
            return (IDataLoader)Activator.CreateInstance(loaderType);
        }
    }
}
