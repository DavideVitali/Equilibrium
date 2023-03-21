using Equilibrium.Components.Communication;
using Equilibrium.Identity.Entities;
using Equilibrium.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equilibrium.Identity.Store
{
    public class UserStore : UserStore<User>
    {
        public UserStore(IdentityContext ctx) : base(ctx)
        {
        }
    }

    // TODO: Implement default CRUD methods
    public class UserStore<TUser> :
        StoreBase<DbContext>,
        IIdentityStore<TUser> where TUser : User
    {
        public UserStore(DbContext ctx) : base(ctx)
        {
        }

        public bool HasRecords => throw new NotImplementedException();

        public Task<OperationResult> CreateAsync(TUser resource, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> DeleteAsync(TUser resource, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TUser> FindByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TUser> FindByNameAsync(string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TUser> GetCollection(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> UpdateAsync(TUser resource, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public interface IIdentityStore : IIdentityStore<User> { }

    public interface IIdentityStore<TUser> : IResourceStore<TUser> where TUser : User 
    {

    }
}
