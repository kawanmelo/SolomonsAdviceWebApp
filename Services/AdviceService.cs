using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using SolomonsAdviceWebApp.Data;
using SolomonsAdviceWebApp.Models.Entities;
using System.Linq;

namespace SolomonsAdviceWebApp.Services
{
    public class AdviceService
    {
        protected readonly  ApplicationDbContext _context;

        public AdviceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Advice> GetByIdAsync(int id)
        {
            return await _context.Advices.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<List<Advice>> GetByTextAsync(string text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                return await _context.Advices.Where(a => EF.Functions.Like(a.Content, $"%{text}%")).ToListAsync();
            }
            return null;
        }

        public async Task<Advice> GetRandomAsync()
        {
            var adviceList = await _context.Advices.ToListAsync();
            if (!adviceList.IsNullOrEmpty())
            {
                Random random = new Random();
                int randomNumber = random.Next(0, adviceList.Count);
                var randomAdvice = adviceList[randomNumber];
                return randomAdvice;
            }
            return null;
        }

        public async Task<List<Advice>> GetFavoritesAsync(string id)
        {
            var favoriteAdvicesReferences = await _context.FavoriteAdvices.Where(x => x.UserId == id).ToListAsync();

            if (!favoriteAdvicesReferences.IsNullOrEmpty())
            {
                List<Advice> advicesFound = new List<Advice>();
                foreach (var fav in favoriteAdvicesReferences)
                {
                    var advice = _context.Advices.FirstOrDefault(x => x.Id == fav.AdviceId);
                    if (advice != null)
                    {
                        advicesFound.Add(advice);
                    }
                }
                return advicesFound;
            }
            return null;
        }
    }
}
