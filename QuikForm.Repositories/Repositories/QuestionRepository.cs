﻿using Microsoft.EntityFrameworkCore;
using QuikForm.Entities;
using QuikForm.Repositories.Contexts;
using QuikForm.Repository.Contracts.Contracts;
using QuikForm.Repository.Contracts.Exceptions.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repositories.Repositories;
public class QuestionRepository : IQuestionRepository
{
    private readonly ApplicationDbContext _context;

    public QuestionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Question> CreateAsync(Question question)
    {
        await _context.Questions.AddAsync(question);
        await _context.SaveChangesAsync();
        return await _context.Questions.Include(q => q.InputType).FirstOrDefaultAsync(q => q.Id == question.Id) ?? throw new QuestionNotFoundException();
    }

    public async Task DeleteAsync(int id)
    {
        Question question = await _context.Questions.FirstOrDefaultAsync(q => q.Id == id) ?? throw new QuestionNotFoundException();
        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFieldsAsync(int id)
    {
        Question question = await _context.Questions.Include(q => q.Fields)
                                                    .FirstOrDefaultAsync(q => q.Id == id) ?? throw new QuestionNotFoundException();
        question.Fields.ForEach(f => _context.Fields.Remove(f));
        await _context.SaveChangesAsync();
    }

    public async Task<List<Question>> GetAllAsync()
    {
        return await _context.Questions.ToListAsync();
    }

    public async Task<Question> GetByIdAsync(int id)
    {
        Question question = await _context.Questions.Include(q => q.Fields)
                                                    .Include(q => q.InputType)
                                                    .FirstOrDefaultAsync(q => q.Id == id) ?? throw new QuestionNotFoundException();
        return question;
    }

    public async Task<Question> UpdateAsync(Question question)
    {
        Question questionToUpdate = await _context.Questions.FirstOrDefaultAsync(q => q.Id == question.Id) ?? throw new QuestionNotFoundException();

        questionToUpdate.Label = question.Label;
        questionToUpdate.IsMandatory = question.IsMandatory;

        await _context.SaveChangesAsync();
        return questionToUpdate;
    }
}
