using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Infrastructure.Data
{
    public class MapItem
    {
        public Type Type { get; private set; }
        public DataRetriveTypeEnum DataRetriveType { get; private set; }
        public string Key { get; private set; }

        public MapItem(Type type, DataRetriveTypeEnum dataRetriveType, string propertyName)
        {
            Type = type;
            DataRetriveType = dataRetriveType;
            Key = propertyName;
        }
    }
}
