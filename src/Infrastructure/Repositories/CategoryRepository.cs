﻿using API.Application.Repositories;
using API.Domain.Entities;
using API.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(Category entity)
    {
        await _context.Categories.AddAsync(entity);
        //_context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Category entity)
    {
        _context.Categories.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        category.IsDeleted = true;
        await _context.SaveChangesAsync();
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }
}
