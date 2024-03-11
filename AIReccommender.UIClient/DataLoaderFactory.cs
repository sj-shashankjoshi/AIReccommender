using AIReccommender.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace AIReccommender.UIClient
{
    public class DataLoaderFactory
    {
        protected DataLoaderFactory()
        {

        }
        public static readonly DataLoaderFactory Instance = new DataLoaderFactory();
        public virtual IDataLoader CreateDataLoader()
        {
            string ClassName = ConfigurationManager.AppSettings["DL"];
            Type type = Type.GetType(ClassName);
            return (IDataLoader)Activator.CreateInstance(type);
        }
    }
}
