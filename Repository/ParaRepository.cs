using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Contexts;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public interface IParaRepository
    {
        void UpdateParaLeft();
        void AddParaRight(int paraId);
      
        Task<IEnumerable<Para>> GetAllPara();
        Task<IEnumerable<ParaLeft>> GetAllParaLeft();
        Task<IEnumerable<ParaRight>> GetAllParaRight();
        void RemoveAllParaRight();
    }
    public class ParaRepository : IParaRepository
    {
        ParaContext _context;
        public ParaRepository(ParaContext context)
        {
            _context = context;
        }

        public void UpdateParaLeft()
        {
             _context.Database.ExecuteSqlCommand("sp_UpdateParaLeft");
        }
        public void AddParaRight(int paraId)
        {
             _context.Database.ExecuteSqlCommand("sp_InsertParaRight @p0", paraId);          
        }

        public void RemoveAllParaRight()
        {            
           _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [ParaRight]");           
        }

        public async Task<IEnumerable<Para>> GetAllPara()
        {
            return await _context.Para.FromSql("sp_GetAllPara").ToListAsync();
        }

        public async Task<IEnumerable<ParaLeft>> GetAllParaLeft()
        {
            return await _context.ParaLeft.ToListAsync();
        }
        public async Task<IEnumerable<ParaRight>> GetAllParaRight()
        {
            return await _context.ParaRight.ToListAsync();
        }

    }
}
