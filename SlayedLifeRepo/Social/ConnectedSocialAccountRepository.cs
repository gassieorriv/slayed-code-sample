using Microsoft.EntityFrameworkCore;
using SlayedLifeCore.Social;
using SlayedLifeRepo.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeRepo.Social
{
    public class ConnectedSocialAccountRepository : IConnectedSocialAccountRepository
    {
        private readonly SlayedAPIContext context;
        public ConnectedSocialAccountRepository(SlayedAPIContext context)
        {
            this.context = context;
        }

        public async Task<ConnectedSocialAccount> Add(ConnectedSocialAccount connectedSocialAccount)
        {
            await context.AddAsync(connectedSocialAccount);
            return connectedSocialAccount;
        }

        public async Task<ConnectedSocialAccount> Create(ConnectedSocialAccount connectedSocialAccount)
        {
            connectedSocialAccount.CreatedDate = DateTime.Now;
            await context.AddAsync(connectedSocialAccount);
            context.SaveChanges();
            return connectedSocialAccount;
        }

        public IQueryable<ConnectedSocialAccount> Get()
        {
            return context.ConnectedSocialAccount.AsNoTracking();
        }

        public async Task<ConnectedSocialAccount> Update(ConnectedSocialAccount connectedSocialAccount)
        {
            var existingSocialAccount = Get().Include(x => x.SocialAccount).Where(x => x.Id == connectedSocialAccount.Id).FirstOrDefault();
            existingSocialAccount.Token = connectedSocialAccount.Token == null ? existingSocialAccount.Token : connectedSocialAccount.Token;
            existingSocialAccount.RefreshToken = connectedSocialAccount.RefreshToken == null ? existingSocialAccount.RefreshToken : connectedSocialAccount.RefreshToken;
            existingSocialAccount.Active = connectedSocialAccount.Active;
            existingSocialAccount.Followers = connectedSocialAccount.Followers;
            connectedSocialAccount.Following = connectedSocialAccount.Following;
            connectedSocialAccount.Picture = connectedSocialAccount.Picture;
            connectedSocialAccount.Name = connectedSocialAccount.Name;
            existingSocialAccount.Secret = connectedSocialAccount.Secret == null ? existingSocialAccount.Secret : connectedSocialAccount.Secret;
            existingSocialAccount.ModifiedDate = DateTime.Now;
            context.Update(existingSocialAccount);
            await context.SaveChangesAsync();
            return existingSocialAccount;
        }

        public async Task<int> SaveChanges()
        {
           return await context.SaveChangesAsync();
        }

    }
}
