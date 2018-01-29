using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic.Core;

namespace Business.Extension
{
    public static class IListExtension
    {
        public static IList<T> ApplySort<T>(this IList<T> source, string orderBy,
                  Dictionary<string, PropertyMappingValue> mappingDictionary)
        {
            if(source == null)
            {
                throw new ArgumentException("source");
            }
            if(mappingDictionary == null)
            {
                throw new ArgumentException("mappingDictionary");
            }
            if (string.IsNullOrEmpty(orderBy))
            {
                return source;
            }

            //the orderby string is separatedby ",", so we split it
            var orderByAfterSplit = orderBy.Split(',');
            foreach (var orderByClause in orderByAfterSplit.Reverse())
            {
                var trimmedOrderByClause = orderByClause.Trim();
                var orderDescending = trimmedOrderByClause.EndsWith(" desc");

                //remove " asc" or " desc" from orderByClause and get property Name
                var indexOfFirstSpace = trimmedOrderByClause.IndexOf(" ");
                var propertyName = indexOfFirstSpace == -1 ? 
                    trimmedOrderByClause : trimmedOrderByClause.Remove(indexOfFirstSpace);
                if(!mappingDictionary.ContainsKey(propertyName))
                {
                    throw new ArgumentException($"Key mapping for {propertyName} is missing");
                }

                var propertyMappingValue = mappingDictionary[propertyName];
                if(propertyMappingValue == null)
                {
                    throw new ArgumentException($"propertyMappingValue");

                }
                foreach( var destinationProperty in propertyMappingValue.DestinationProperties.Reverse())
                {
                    if(propertyMappingValue.Revert)
                    {
                        orderDescending = !orderDescending;
                    }

                    source = source.AsQueryable().OrderBy(destinationProperty + (orderDescending ? " descending" : " ascending")).ToList();
                }
            }
            return source;
        }
    }
}
