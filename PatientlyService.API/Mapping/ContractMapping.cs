using PatientlyService.Core.Models.Tenant;
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

    public static User MapToUser(this UserRequest request)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            Email = request.email,
            Password = request.password,
            PictureUrl = request.pictureUrl,
            RoleId = request.roleId,
            Status = request.status,
            UserType = request.userType,
            FirstName = request.firstName,
            MiddleName = request.middleName,
            LastName = request.lastName,
            PhoneNumber = request.phoneNumber,
            DOB = request.dob,
            Gender = request.gender,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };
    }
    
    public static Permission MapToPermission(this CreatePermissionRequest request)
    {
        return new Permission
        {
            Id = Guid.NewGuid(),
            PermissionCode = request.PermissionCode,
            Description = request.Description,
            Category = request.Category,
            IsEnabled = request.IsEnabled
        };
    }
    
    public static Role MapToRole(this CreateRoleRequest request)
    {
        return new Role()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            PermissionIds = request.PermissionIds
        };
    }
    
    public static UserInviteResponse MapToResponse(this UserInvite userInvite)
    {
        return new UserInviteResponse
        {
            Id = userInvite.Id,
            TenantId =userInvite.TenantId,
            UserType = userInvite.UserType,
            RoleId = userInvite.RoleId,
            Prefix = userInvite.Prefix,
            FirstName = userInvite.FirstName,
            Email = userInvite.Email,
        };
    }

    public static UserResponse MapToResponse(this User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            Email = user.Email,
            PictureUrl = user.PictureUrl,
            RoleId = user.RoleId,
            Status = user.Status,
            UserType = user.UserType,
            FirstName = user.FirstName,
            MiddleName = user.MiddleName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            DOB = user.DOB,
            Gender = user.Gender,
            CreatedAt = user.CreatedAt,
            ModifiedAt = user.ModifiedAt
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
    
    public static PermissionResponse MapToResponse(this Permission permission)
    {
        return new PermissionResponse
        {
            Id = permission.Id,
            PermissionCode = permission.PermissionCode,
            Description = permission.Description,   
            Category = permission.Category,
            IsEnabled = permission.IsEnabled
        };
    }
    public static PermissionsResponse MapToResponse(this IEnumerable<Permission> permissions)
    {
        return new PermissionsResponse
        {
            PermissionsResponses = permissions.Select(MapToResponse).ToList()
        };
    }
    
    public static RoleResponse MapToResponse(this Role role)
    {
        return new RoleResponse
        {
            Id = role.Id,
            Name = role.Name,
            PermissionIds = role.PermissionIds.ToList()
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



