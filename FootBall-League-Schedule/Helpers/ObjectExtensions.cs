using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Text;

namespace FootBallLeagueSchedule.Helpers
{
    public static class ObjectExtensions
    {
        public static ExpandoObject ShapData<TSource>(this TSource source,
            string fields)
        {
            if(source == null)
            {
                throw new ArgumentException("source");
            }

            var dataShapeObject = new ExpandoObject();

            var propertyInfoList = new List<PropertyInfo>();
            if (string.IsNullOrEmpty(fields))
            {
                //all public properties should be in the ExpandoObject
                var propertyInfos = typeof(TSource)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance);

                propertyInfoList.AddRange(propertyInfos);
            }
            else
            {
                var fieldsAfterSplit = fields.Split(',');

                foreach (var field in fieldsAfterSplit)
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
            foreach (var propertyInfo in propertyInfoList)
            {
                var propertyValue = propertyInfo.GetValue(source);

                //add the field to the ExpandoObject
                ((IDictionary<string, object>)dataShapeObject).Add(propertyInfo.Name, propertyValue);
            }
            return dataShapeObject;
        }
    }
}
