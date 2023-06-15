using System;
using Bewize.Models;
using System.Threading.Tasks;

namespace Bewize.HelperResource
{
	public interface IAppleSignInService
	{
        bool IsAvailable { get; }
        Task<AppleSignInCredentialState> GetCredentialStateAsync(string userId);
        Task<AppleAccount> SignInAsync();
    }
}

