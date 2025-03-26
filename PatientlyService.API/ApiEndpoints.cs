namespace PatientlyService.API;

public static class ApiEndpoints
{
    private const string ApiBase = "api";
    
    public static class TenantService
    {
        private const string Base = $"{ApiBase}/tenants";

        public const string Create = Base;
        public const string Get = $"{Base}/{{idOrSlug}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }
}