namespace BelinAI.Services;

using BelinAI.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

public class UserService
{
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(AuthenticationStateProvider authStateProvider, UserManager<ApplicationUser> userManager)
    {
        _authStateProvider = authStateProvider;
        _userManager = userManager;
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        var authState = await _authStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        return user.Identity.IsAuthenticated;
    }

    public async Task<string?> GetUserIdAsync()
    {
        var authState = await _authStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }

    public async Task<string?> GetUserNameAsync()
    {
        var authState = await _authStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        return user.FindFirst(ClaimTypes.Name)?.Value;
    }

    public async Task<(string? UserId, string? UserName)> GetUserNameAndIdAsync()
    {
        return (await GetUserIdAsync(), await GetUserNameAsync());
    }

    public async Task<ApplicationUser?> GetCurrentUserAsync()
    {
        var userId = await GetUserIdAsync();
        if (userId == null) return null;

        return await _userManager.FindByIdAsync(userId);
    }
}
