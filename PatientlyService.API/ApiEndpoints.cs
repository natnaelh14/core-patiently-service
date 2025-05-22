namespace PatientlyService.API;

public static class ApiEndpoints
{
    private const string ApiBase = "api";
    
    public static class Tenant
    {
        private const string Base = $"{ApiBase}/tenants";

        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }
    public static class Patient
    {
        private const string Base = $"{ApiBase}/patient";
        public const string StartRegistration = $"{Base}/startRegistration";
        public const string CompleteRegistration = $"{Base}/completeRegistration/{{id:guid}}";
    }
    
    public static class User
    {
        private const string Base = $"{ApiBase}/user";
        public const string Signup = $"{Base}/signup";
        public const string Invite = $"{Base}/invite";
    }

    public static class Permission
    {
        private const string Base = $"{ApiBase}/permission";
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string Create = Base;
    }
}