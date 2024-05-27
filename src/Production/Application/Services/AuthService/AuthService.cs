using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly TokenOptions _tokenOptions;

        public AuthService(IUserOperationClaimRepository userOperationClaimRepository, IRefreshTokenRepository refreshTokenRepository,
            ITokenHelper tokenHelper, IConfiguration configuration)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _tokenHelper = tokenHelper;
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>()!;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            return await _refreshTokenRepository.AddAsync(refreshToken);
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            var operationClaims = await _userOperationClaimRepository.Query()
                .AsNoTracking().Where(p => p.UserId == user.Id)
                .Select(x => new OperationClaim
                {
                    Id = x.OperationClaimId,
                    Name = x.OperationClaim.Name
                }).ToListAsync();

            return _tokenHelper.CreateToken(user, operationClaims);
        }

        public RefreshToken CreateRefreshToken(User user, string ipAddress)
        {
            return _tokenHelper.CreateRefreshToken(user, ipAddress);
        }

        public async Task DeleteOldRefreshTokens(int userId)
        {
            var refreshTokens = (await _refreshTokenRepository.GetListAsync(r =>
                                                    r.UserId == userId &&
                                                    r.Revoked == null && r.Expires >= DateTime.UtcNow &&
                                                    r.Created.AddDays(_tokenOptions.RefreshTokenTTL) <= DateTime.UtcNow)).Items.ToList();
        }

        public async Task<RefreshToken?> GetRefreshTokenByToken(string token)
        {
            RefreshToken? refreshToken = await _refreshTokenRepository.GetAsync(r => r.Token == token);
            return refreshToken;
        }

        public async Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason)
        {
            RefreshToken? childToken = await _refreshTokenRepository.GetAsync(r => r.Token == refreshToken.ReplacedByToken);

            if (childToken == null)
            {
                throw new BusinessException("Lütfen tekrardan giriş yapınız!");
            }

            if (childToken != null && childToken.Revoked != null && childToken.Expires <= DateTime.UtcNow)
            {
                await RevokeRefreshToken(childToken, ipAddress, reason);
            }
        }

        public async Task RevokeRefreshToken(RefreshToken token, string ipAddress, string? reason = null, string? replacedByToken = null)
        {
            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = ipAddress;
            token.ReasonRevoked = reason;
            token.ReplacedByToken = replacedByToken;
            await _refreshTokenRepository.UpdateAsync(token);
        }

        public async Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress)
        {
            RefreshToken newRefreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            await RevokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);

            return newRefreshToken;
        }
    }
}