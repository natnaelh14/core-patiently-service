﻿using PatientlyService.Core.Models.Tenant;
using  PatientlyService.Core.Models.User;
using PatientlyService.Core.Requests;
using PatientlyService.Core.Responses;

namespace PatientlyService.API.Mapping;

public static class ContractMapping
{
    public static Tenant MapToTenant(this CreateTenantRequest request)
    {
        return new Tenant
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            StreetAddress = request.StreetAddress,
            City = request.City,
            State = request.State,
            Country = request.Country,
            ZipCode = request.ZipCode,
            PictureUrl = request.PictureUrl
        };
    }
    
    public static Tenant MapToTenant(this UpdateTenantRequest request, Guid id)
    {
        return new Tenant
        {
            Id = id,
            Name = request.Name,
            StreetAddress = request.StreetAddress,
            City = request.City,
            State = request.State,
            Country = request.Country,
            ZipCode = request.ZipCode,
            PictureUrl = request.PictureUrl
        };
    }
    
    public static UserInvite MapToUserInvite(this UserInviteRequest request)
    {
        return new UserInvite
        {
            Id = Guid.NewGuid(),
            TenantId =request.tenantId,
            UserType = request.userType,
            RoleId = request.roleId,
            Prefix = request.prefix,
            FirstName = request.firstName,
            Email = request.email,
        };
    }
    
    public static UserInviteResponse MapToResponse(this UserInvite userInvite)
    {
        return new UserInviteResponse
        {
            Id = Guid.NewGuid(),
            TenantId =userInvite.TenantId,
            UserType = userInvite.UserType,
            RoleId = userInvite.RoleId,
            Prefix = userInvite.Prefix,
            FirstName = userInvite.FirstName,
            Email = userInvite.Email,
        };
    }
    
    public static TenantResponse MapToResponse(this Tenant tenant)
    {
        return new TenantResponse
        {
            Id = tenant.Id,
            Name = tenant.Name,
            StreetAddress = tenant.StreetAddress,
            City = tenant.City,
            State = tenant.State,
            Country = tenant.Country,
            ZipCode = tenant.ZipCode,
            PictureUrl = tenant.PictureUrl
        };
    }
    public static TenantsResponse MapToResponse(this IEnumerable<Tenant> tenants)
    {
        return new TenantsResponse
        {
            TenantsResponses = tenants.Select(MapToResponse).ToList()

        };
    }
    public static GetAllTenantsOptions MapToOptions(this GetAllTenantsRequest request)
    {
        return new GetAllTenantsOptions
        {
            SortField = request.SortBy?.Trim('+', '-'),
            SortOrder = request.SortBy is null ? SortOrder.Unsorted :
                request.SortBy.StartsWith('-') ? SortOrder.Descending : SortOrder.Ascending,
        };
    }
}



