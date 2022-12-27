using Microsoft.AspNetCore.Authorization;
using MinimalApi.Contracts;
using MinimalApi.Model;
using MinimalApi.Repository;
using MinimalApi.SecretSauce;

namespace MinimalApi.EndpointDefinitions
{
    public class AuthorEndpointDefinition : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/GetAuthor", GetAuthorsAsync);
        }
   
        internal async  Task<List<Author>> GetAuthorsAsync(IAuthorRepository authRepo)
        {
            Console.WriteLine("Called Author method from the Auth service");
            return await authRepo.GetAuthorsAsync();
        }
        public void DefineServices(IServiceCollection services)
        {
            services.AddSingleton<IAuthorRepository, AuthorRepository>();
        }
    }
}
