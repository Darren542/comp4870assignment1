using ClassLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary.Data;

public class MemberService
{
    private readonly ApplicationDbContext _context;

    public MemberService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Member>> GetMembersAsync()
    {
        return await _context.Members.ToListAsync();
    }

    public async Task<Member> GetMemberAsync(string id)
    {
        return await _context.Members.FindAsync(id);
    }

    public async Task<Member> AddMemberAsync(Member member)
    {
        _context.Members.Add(member);
        await _context.SaveChangesAsync();
        return member;
    }

    public async Task<Member> UpdateMemberAsync(string id, Member member)
    {
        var existingMember = await _context.Members.FindAsync(id);
        if (existingMember == null)
        {
            return null;
        }

        existingMember.Email = member.Email; // Assuming Email as a unique identifier
        existingMember.FirstName = member.FirstName;
        existingMember.LastName = member.LastName;
        existingMember.Mobile = member.Mobile;
        existingMember.Street = member.Street;
        existingMember.City = member.City;
        existingMember.PostalCode = member.PostalCode;
        existingMember.Country = member.Country;
        existingMember.Created = member.Created;
        existingMember.Modified = member.Modified;
        existingMember.CreatedBy = member.CreatedBy;
        existingMember.ModifiedBy = member.ModifiedBy;

        _context.Members.Update(existingMember);
        await _context.SaveChangesAsync();
        return existingMember;
    }

    public async Task<Member> DeleteMemberAsync(string id)
    {
        var member = await _context.Members.FindAsync(id);
        if (member != null)
        {
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
        }
        return member;
    }
}
