using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(x => x.Departament).FirstOrDefault(x => x.Id == id);
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.FindAsync(id);
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public async Task InsertAsync(Seller seller)
        {
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }

        public void Remove(int id)
        {
            var seller = _context.Seller.Find(id);
            if (seller == null)
            {
                return;
            }
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var seller = await _context.Seller.FindAsync(id);
                if (seller == null)
                {
                    return;
                }
                _context.Seller.Remove(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Can´t delete seller because he/she has sales");
            }
        }

        public void Update(Seller seller)
        {
            bool hasAny = _context.Seller.Any(x => x.Id == seller.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Seller not found.");
            }

            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

        public async Task UpdateAsync(Seller seller)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == seller.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Seller not found.");
            }

            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
