using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using MeetingApp.Domain.Base;
using MeetingApp.Application.Attribute;

namespace MeetingApp.Application.Extensions
{
    public static class AttributeExtension
    {
        public static int GetLookupEnumAttributeClassIdValue(this Type type)
        {
            return (type.GetCustomAttributes()
                     .FirstOrDefault(a => a.GetType() == typeof(LookupEnumAttribute))
                     as LookupEnumAttribute).ClassID;
        }

        public static string GetLookupEnumAttributeClassNameValue(this Type type)
        {
            return (type.GetCustomAttributes()
                     .FirstOrDefault(a => a.GetType() == typeof(LookupEnumAttribute))
                     as LookupEnumAttribute).ClassName;
        }

        public static bool IsLookupAttribute(this PropertyInfo property)
        {
            return (property.GetCustomAttributes().Any(a => a.GetType() == typeof(LookupAttribute)));
        }

        public static bool IsRequiredLookupAttribute(this PropertyInfo property)
        {
            return (property.GetCustomAttributes()
                     .FirstOrDefault(a => a.GetType() == typeof(LookupAttribute))
                     as LookupAttribute).IsRequired;
        }

        public static Type GetLookupAttributeEnumTypeValue(this PropertyInfo property)
        {
            return (property.GetCustomAttributes()
                        .FirstOrDefault(a => a.GetType() == typeof(LookupAttribute))
                        as LookupAttribute).EnumType;
        }

        public static string GetColumnAttrNameValue(this PropertyInfo property)
        {
            return (property.GetCustomAttributes()
                        .FirstOrDefault(a => a.GetType() == typeof(ColumnAttribute))
                        as ColumnAttribute) != null ? (property.GetCustomAttributes(false)
                        .FirstOrDefault(a => a.GetType() == typeof(ColumnAttribute))
                        as ColumnAttribute).Name : "";
        }

        public static string GetTableAttrNameValue(this BaseEntity entity)
        {
            return (entity.GetType().GetCustomAttributes()
                        .FirstOrDefault(a => a.GetType() == typeof(TableAttribute))
                        as TableAttribute).Name;
        }

        public static long? GetPkIdFromKeyAttribute(this BaseEntity entity)
        {
            object idStr = entity.GetType()
                                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                    .FirstOrDefault(x => x.GetCustomAttribute<KeyAttribute>() != null || x.GetCustomAttribute<RequiredAttribute>() != null)
                                    .GetValue(entity);
            return idStr == null ? null : (long?)Convert.ToInt64(idStr);
        }
    }
}
