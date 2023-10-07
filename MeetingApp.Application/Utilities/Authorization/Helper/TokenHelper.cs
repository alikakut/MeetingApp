using JWT.Algorithms;
using JWT.Serializers;
using JWT;
using System.Net;
using MeetingApp.Application.Utilities.AppSettings;
using MeetingApp.Application.Utilities.Authorization.Constant;
using MeetingApp.Application.Utilities.Exception;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using MeetingApp.Application.Utilities.Authorization.Model;
using Newtonsoft.Json;
using MeetingApp.Application.Extensions;

namespace MeetingApp.Application.Utilities.Authorization.Helper
{
    public class TokenHelper
    {
        private readonly IOptions<MeetingAppSettings> _settings;

        public TokenHelper(IOptions<MeetingAppSettings> settings)
        {
            _settings = settings;
        }

        public string CreateToken(TokenModel tokenModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Value.JwtSetting.Key));

            var credentials = new SigningCredentials(key: securityKey, algorithm: SecurityAlgorithms.HmacSha256Signature);
            var jwtToken = new JwtSecurityToken(
                issuer: _settings.Value.JwtSetting.Issuer,
                audience: _settings.Value.JwtSetting.Audience,
                claims: GetClaims(tokenModel),
                expires: DateTime.Now.AddHours(8),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        public TokenModel ValidateToken(string token)
        {
            try
            {
                var serialazer = new JsonSerializer();

                serialazer.DateFormatString = "dd.MM.yyyy HH:mm:ss";

                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJsonSerializer serializer = new JsonNetSerializer(serialazer);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();

                UtcDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);



                var personnel = decoder.DecodeToObject<TokenModel>(token, _settings.Value.JwtSetting.Key, verify: true);

                if (personnel.IsNull() || (personnel.ValidTo.IsNull() && personnel.RefreshTokenEndDate.IsNull()) || (personnel.ValidTo.IsNotNull() ? personnel.ValidTo : personnel.RefreshTokenEndDate) < DateTime.Now)
                {
                    throw new CustomException(TokenConstant.EXPIRED_TOKEN, HttpStatusCode.Unauthorized);
                }

                return personnel;
            }
            catch
            {
                throw new CustomException(TokenConstant.INVALID_TOKEN, HttpStatusCode.Unauthorized);
            }
        }

        public Claim[] GetClaims(TokenModel tokenModel)
        {
            var claims = new List<Claim>
            {
                new Claim("PersonnelId",tokenModel.PersonnelId.ToString()),
                new Claim("SaleChannelId",tokenModel.SaleChannelId.IsNotNull() ? tokenModel.SaleChannelId.ToString() : "0"),
                new Claim("UserName", tokenModel.Username),
                new Claim("SaleChannelName", tokenModel.SaleChannelName.IsNotNullOrEmpty() ? tokenModel.SaleChannelName : "0"),
                new Claim("RefreshToken", tokenModel.RefreshToken),
                new Claim("RefreshTokenEndDate", tokenModel.RefreshTokenEndDate.ToString()),
                new Claim("ValidTo", tokenModel.ValidTo.ToString()),
                new Claim("PersonnelType", tokenModel.PersonnelType.ToString()),
            };

            return claims.ToArray();
        }
    }
}
