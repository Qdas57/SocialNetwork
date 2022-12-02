using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.Data;
using SocialNetwork.Data.Entities;
using SocialNetwork.Models.Output;

namespace SocialNetwork.Services.Repositories
{


    public class RefreshTokenRepository
    {
        private UserContext _db;
        
        private ILogger<RefreshTokenRepository> _logger;

        public RefreshTokenRepository(ILogger<RefreshTokenRepository> logger, UserContext db)
        {
            _logger = logger;
            logger.LogInformation("RefreshTokenRepository создался");
            _db = db;
        }


        /// <summary>
        /// Метод удалит все рефреш токены пользователя по идентификатору пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Статус оперцаии.</returns>
        public async Task<bool> DeleteAllAsync(Guid userId)
        {
            
            try
            {
                List<RefreshTokenEntity> refreshTokens = await _db.RefreshTokens.Where(x => x.UserId == userId).ToListAsync();

                foreach (var item in refreshTokens)
                {
                    _db.RefreshTokens.Remove(item);
                }

                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Метод создаст новую запись в таблице рефреш токенов.
        /// </summary>
        /// <param name="refreshToken">Рефреш токен.</param>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Выходная модель рефреш токена.</returns>
        public async Task<RefreshTokenOutput> CreateAsync(string refreshToken, Guid userId)
        {
            try
            {
                RefreshTokenEntity newRefreshToken = new RefreshTokenEntity
                {
                    RefreshToken = refreshToken,
                    UserId = userId
                };

                await _db.RefreshTokens.AddAsync(newRefreshToken);

                await _db.SaveChangesAsync();

                RefreshTokenOutput result = new()
                {
                    RefreshToken = refreshToken,
                    UserId = userId
                };

                return result;
            }
            catch (Exception ex)
            {
                string createText = ex + Environment.NewLine;
                File.WriteAllText("ErrInCreateAsync.txt", createText);
                return null;
            }
        }

        /// <summary>
        /// Метод найдёт запись в таблице рефреш токенов по значению токена.
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns>Выходная модель рефреш токена.</returns>
        public async Task<RefreshTokenOutput> GetByTokenAsync(string refreshToken)
        {
            try
            {
                var result = await _db.RefreshTokens.FirstOrDefaultAsync(r => r.RefreshToken == refreshToken);

                if (result is null)
                {
                    return null;
                }

                return new RefreshTokenOutput
                {
                    RefreshTokenId = result.RefreshTokenId,
                    RefreshToken = result.RefreshToken,
                    UserId = result.UserId
                };
            }
            catch (Exception ex)
            {
                string createText = ex + Environment.NewLine;
                File.WriteAllText("ErrInGetByTokenAsync.txt", createText);
                return null;
            }
           
        }

        /// <summary>
        /// Метод удалит токен по идентификатору токена.
        /// </summary>
        /// <param name="refreshTokenId">Идентификатор токена.</param>
        /// <returns>Статус операции.</returns>
        public async Task<bool> DeleteAsync(long refreshTokenId)
        {

            try
            {
                var deletedToken = await _db.RefreshTokens.FirstOrDefaultAsync(t=>t.RefreshTokenId == refreshTokenId);

                if (deletedToken is null)
                {
                    return false;
                }

                _db.RefreshTokens.Remove(deletedToken);

                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                string createText = ex + Environment.NewLine;
                File.WriteAllText("ErrInDeleteAsync.txt", createText);
                return false;
            }
        }
    }
}
