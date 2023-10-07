namespace MeetingApp.Application.Utilities.Authorization.Attribute
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class HasPermissionAttribute : System.Attribute
    {
        public HasPermissionAttribute()
        {

        }
    }
}
