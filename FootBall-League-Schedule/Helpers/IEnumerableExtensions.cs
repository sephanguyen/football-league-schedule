using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Text;

namespace FootBallLeagueSchedule.Helpers
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<ExpandoObject> ShapeData<TSource>(
            this IEnumerable<TSource> source, string fields)
        {
            if(source == null)
            {
                throw new ArgumentException("source");
            }

            var expandoObjectList = new List<ExpandoObject>();

            //create a list with PropertyInfo object on TSource. Reflection is 
            //expensive, so rather than doing it for each object in the list, we do
            //it once and reuse the results. After all, part of the reflection is on the
            //type of the object (TSource), not on the instance
            var propertyInfoList = new List<PropertyInfo>();
            if(string.IsNullOrEmpty(fields))
            {
                //all public properties should be in the ExpandoObject
                var propertyInfos = typeof(TSource)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance);

                propertyInfoList.AddRange(propertyInfos);
            }
            else
            {
                var fieldsAfterSplit = fields.Split(',');

                foreach(var field in fieldsAfterSplit)
                {
                    var propertyName = field.Trim();

                    //use reflection to get property on the source object
                    //we need to include and instance, b/c specifying a binding flag overwrites the
                    //already-existing binding flags
                    var propertyInfo = typeof(TSource)
                        .GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                    if (propertyInfo == null)
                    {
                        throw new Exception($"Property {propertyName} wasn't found on {typeof(TSource)}");
                    }
                    propertyInfoList.Add(propertyInfo);
                }
            }

            //run through the source object
            foreach (TSource sourceObject in source)
            {
                //create an ExpandoObject that will hold the
                //selected properties & value
                var dataShapedObject = new ExpandoObject();
                foreach(var propertyInfo in propertyInfoList)
                {
                    var propertyValue = propertyInfo.GetValue(sourceObject);

                    //add the field to the ExpandoObject
                    ((IDictionary<string, object>)dataShapedObject).Add(propertyInfo.Name, propertyValue);
                }
                expandoObjectList.Add(dataShapedObject);
            }

            return expandoObjectList;
        }
    }
}
