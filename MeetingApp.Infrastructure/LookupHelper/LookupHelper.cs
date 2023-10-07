using System.Collections;
using System.Reflection;
using MeetingApp.Application.Interfaces.LookupHelper;
using MeetingApp.Domain.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using MeetingApp.Application.Interfaces.CacheService;
using MeetingApp.Application.Extensions;
using MeetingApp.Domain.Base;
using MeetingApp.Domain.Common.Lookup;

namespace MeetingApp.Infrastructure.LookupHelper
{
    public class LookupHelper : ILookupHelper
    {
        private readonly ICacheService _cacheService;

        public LookupHelper(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public List<LookupValueResult> FillLookupValue(GetLookupValueModel lookupValueModel)
        {
            if (lookupValueModel.IsNull()) return null;

            List<LookupValueResult> lookupValueList = FillLookupValue(lookupValueModel.LookupClassNameList);

            if (lookupValueList.IsNotNullOrEmpty() && lookupValueModel.LookupValueOrdinalList.IsNotNullOrEmpty())
                lookupValueList = lookupValueList.Where(x => lookupValueModel.LookupValueOrdinalList.Contains(x.ordinal)).ToList();

            return lookupValueList;
        }

        public List<LookupValueResult> FillLookupValue(List<string> ClassNameList)
        {
            if (ClassNameList.IsNotNullOrEmpty()) return null;

            List<LookupValueResult> lookupValueList = new List<LookupValueResult>();
            foreach (var cName in ClassNameList)
            {
                string Key = CommonConstants.LOOKUP_KEY_NAME + "." + cName.ToUpper() + ".0";

                string resultArray = _cacheService.GetByKey(Key);

                if (resultArray != null && resultArray.Length != 0)
                {
                    JArray jArray = JArray.Parse(resultArray);
                    bool isOk = true;
                    List<LookupValueResult> lookupValueTempList = new List<LookupValueResult>();

                    for (int i = 0; i < jArray.Count; i++)
                    {
                        LookupValueResult lookupValue = new LookupValueResult();
                        lookupValue.id = int.Parse(jArray[i]["id"].ToString());
                        lookupValue.code = jArray[i]["code"].ToString();
                        lookupValue.ordinal = int.Parse(jArray[i]["ordinal"].ToString());
                        lookupValue.name = jArray[i]["name"].ToString();
                        lookupValue.lookupClassId = Convert.ToInt32(jArray[i]["lookupClassId"].ToString());
                        lookupValue.lookupClass = jArray[i]["lookupClass"].ToObject<LookupClassResult>();

                        if (lookupValue.lookupClass.Name != cName)
                        {
                            isOk = false;
                            break;
                        }

                        lookupValueTempList.Add(lookupValue);
                    }
                    if (isOk)
                    {
                        lookupValueList.AddRange(lookupValueTempList);
                        continue;
                    }
                }

                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile(
                        $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                        optional: true)
                    .Build();

                var lookupServicePath = configuration["MeetingAppSettings:LacalPath"] + "Lookups/InnerServiceRequest?lookupClassNames=";

                var client = new RestClient(lookupServicePath + cName);
                var request = new RestRequest("", Method.Get);
                request.Timeout = 120000;

                var response = client.Execute(request);

                var resultLookup = JsonConvert.DeserializeObject<LookupValueResponseModel>(response.Content);

                if (resultLookup.IsNotNull() && resultLookup.successful)
                {
                    lookupValueList.AddRange(resultLookup.result);

                    DeleteKeyAndAddLookupsFromDb(resultLookup.result);
                }

            }

            return lookupValueList;
        }

        private void DeleteKeyAndAddLookupsFromDb(List<LookupValueResult> AddedLookupValue)
        {
            JArray jArray = new JArray();
            string Key = "";
            if (AddedLookupValue != null)
            {
                foreach (LookupValueResult lookupValue1 in AddedLookupValue)
                {
                    Key = CommonConstants.LOOKUP_KEY_NAME + "." + lookupValue1.lookupClass.Name.ToUpper() + "." + (int)lookupValue1.lookupClass.Type;
                    JObject jObject = new JObject();
                    jObject["id"] = lookupValue1.id;
                    jObject["code"] = lookupValue1.code;
                    jObject["name"] = lookupValue1.name;
                    jObject["ordinal"] = lookupValue1.ordinal;
                    jObject["lookupClass"] = JToken.FromObject(lookupValue1.lookupClass);
                    jObject["lookupClassId"] = lookupValue1.lookupClassId;
                    jArray.Add(jObject);
                }
            }
            _cacheService.Delete(Key);
            if (jArray.Count != 0)
            {
                _cacheService.InsertValue(Key, jArray.ToString());
            }
        }

        private static class CommonConstants
        {
            public const string API_CODE = "ApiCode";

            public const string LOOKUP_KEY_NAME = "MeetingApp.LOOKUP";

            public const string ERROR_KEY_NAME = "MeetingApp.ERROR";
        }

        protected List<LookupValueResult> GetLookupValueResultFromProperty(object model)
        {
            List<string> LookupClassNameList = new List<string>();
            List<LookupValueResult> lookupValueResults = new List<LookupValueResult>();
            foreach (PropertyInfo Prop in model.GetType().GetProperties().Where(x => x.PropertyType.BaseType.BaseType == typeof(BaseResultModel) || x.PropertyType.BaseType == typeof(BaseResultModel) || (x.IsLookupAttribute())))
            {
                if ((Prop.PropertyType.BaseType.BaseType == typeof(BaseResultModel) || Prop.PropertyType.BaseType == typeof(BaseResultModel)))
                {
                    object childObject = (object)Prop.GetValue(model);

                    if (childObject != null)
                    {
                        List<LookupValueResult> baselookupValueResults = GetLookupValueResultFromProperty(childObject);

                        if (baselookupValueResults.IsNotNullOrEmpty())
                            lookupValueResults.AddRange(baselookupValueResults);
                    }
                }

                if (Prop.IsLookupAttribute())
                {

                    LookupObjectModel LookupObjectFromProp = (LookupObjectModel)Prop.GetValue(model);

                    string LookupClassName = Prop.GetLookupAttributeEnumTypeValue()
                                                 .GetLookupEnumAttributeClassNameValue();

                    if (LookupClassName == null || LookupClassName.IsNullOrEmpty()) continue;

                    LookupClassNameList.Add(LookupClassName);
                }
            }

            if (LookupClassNameList.IsNotNullOrEmpty())
                lookupValueResults.AddRange(FillLookupValue(new GetLookupValueModel { LookupClassNameList = LookupClassNameList }));

            return lookupValueResults;
        }
        protected void SettingLookupDataFromProperty(object model, List<LookupValueResult> lookupValueResults)
        {
            foreach (PropertyInfo Prop in model.GetType().GetProperties().Where(x => x.PropertyType.BaseType.BaseType == typeof(BaseResultModel) || x.PropertyType.BaseType == typeof(BaseResultModel) || (x.IsLookupAttribute())))
            {
                if ((Prop.PropertyType.BaseType.BaseType == typeof(BaseResultModel) || Prop.PropertyType.BaseType == typeof(BaseResultModel)))
                {
                    object childObject = (object)Prop.GetValue(model);

                    if (childObject != null)
                        SettingLookupDataFromProperty(childObject);
                }
                else if (Prop.IsLookupAttribute())
                {

                    LookupObjectModel LookupObjectFromProp = (LookupObjectModel)Prop.GetValue(model);
                    if (LookupObjectFromProp == null || LookupObjectFromProp.IsNull() || LookupObjectFromProp.Ordinal.IsNull()) continue;

                    string LookupClassName = Prop.GetLookupAttributeEnumTypeValue()
                                                 .GetLookupEnumAttributeClassNameValue();

                    if (LookupClassName == null || LookupClassName.IsNullOrEmpty()) continue;

                    LookupValueResult getLookupItem = lookupValueResults.Find(x => x.lookupClass.Name == LookupClassName && x.ordinal == (int)LookupObjectFromProp.Ordinal);

                    if (getLookupItem != null)
                    {
                        Prop.SetValue(model, new LookupObjectModel
                        {
                            ClassId = getLookupItem.lookupClassId,
                            Code = getLookupItem.code,
                            Ordinal = getLookupItem.ordinal,
                            Text = getLookupItem.name,
                            ClassName = getLookupItem.lookupClass.Name
                        });
                    }
                }

            }
        }

        protected void SettingLookupDataFromProperty(object model)
        {
            foreach (PropertyInfo Prop in model.GetType().GetProperties())
            {

                if ((Prop.PropertyType.BaseType.BaseType == typeof(BaseResultModel) || Prop.PropertyType.BaseType == typeof(BaseResultModel)))
                {
                    var aa = model.GetType();
                    object childObject = (object)Prop.GetValue(model);

                    if (childObject != null)
                        SettingLookupDataFromProperty(childObject);
                }

                if (Prop.IsLookupAttribute())
                {

                    LookupObjectModel LookupObjectFromProp = (LookupObjectModel)Prop.GetValue(model);
                    if (LookupObjectFromProp == null || LookupObjectFromProp.IsNull() || LookupObjectFromProp.Ordinal.IsNull()) continue;

                    string LookupClassName = Prop.GetLookupAttributeEnumTypeValue()
                                                 .GetLookupEnumAttributeClassNameValue();

                    if (LookupClassName == null || LookupClassName.IsNullOrEmpty()) continue;

                    LookupValueResult getLookupItem = FillLookupValue(new GetLookupValueModel { LookupClassNameList = new List<string> { LookupClassName } }).FirstOrDefault(x => x.ordinal == (int)LookupObjectFromProp.Ordinal);

                    if (getLookupItem != null)
                    {
                        Prop.SetValue(model, new LookupObjectModel
                        {
                            ClassId = getLookupItem.lookupClassId,
                            Code = getLookupItem.code,
                            Ordinal = getLookupItem.ordinal,
                            Text = getLookupItem.name,
                            ClassName = getLookupItem.lookupClass.Name
                        });
                    }
                }

            }
        }
    }

    public class ResolverHelper : LookupHelper, ILookupHelper
    {
        public ResolverHelper(ICacheService cacheService) : base(cacheService)
        {
        }

        public void ResolveMapping(object sourceListOrObject)
        {
            if (sourceListOrObject.IsNull()) return;

            if (sourceListOrObject.TryConvertTo<IList>())
            {
                foreach (var source in (IList)sourceListOrObject)
                {
                    SettingLookupDataFromProperty(source);
                }
            }
            else
            {
                SettingLookupDataFromProperty(sourceListOrObject);
            }
        }

        #region Private Methods

        private void FillLookupDataFromList(List<object> source)
        {
            if (source.IsNotNullOrEmpty())
                return;

            List<LookupValueResult> lookupValueResults = GetLookupValueResultFromProperty(source[0]);
            foreach (object modelItem in source)
            {
                SettingLookupDataFromProperty(modelItem, lookupValueResults);
            }
        }

        private void MappinResolveRecursive(object model, List<string> LookupClasses)
        {
            foreach (PropertyInfo Prop in model.GetType().GetProperties())
            {
                if ((Prop.PropertyType.BaseType.BaseType == typeof(BaseResultModel) || Prop.PropertyType.BaseType == typeof(BaseResultModel)))
                {
                    object childObject = (object)Prop.GetValue(model);

                    if (childObject != null)
                        MappinResolveRecursive(childObject, LookupClasses);
                }

                if (Prop.IsLookupAttribute())
                {
                    if (Prop.IsNull()) continue;

                    var LookupValue = Prop.GetValue(model);
                    if (LookupValue == null || LookupValue.ToString().IsNullOrEmpty()) continue;

                    string LookupClassName = Prop.GetLookupAttributeEnumTypeValue()
                                               .GetLookupEnumAttributeClassNameValue();

                    int LookupClassId = Prop.GetLookupAttributeEnumTypeValue()
                                          .GetLookupEnumAttributeClassIdValue();

                    if (LookupClassName == null || LookupClassName.ToString().IsNullOrEmpty()) continue;

                    if (!LookupClasses.Contains(LookupClassName))
                        LookupClasses.Add(LookupClassName);
                }
            }

        }

        #endregion
    }
}
