using Company.Storage.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Company.Storage.Services;

public class CompanyService
{
    private CompanyDbContext _companyDbContext;

    public CompanyService(CompanyDbContext companyDbContext)
    {
        _companyDbContext = companyDbContext;
    }

    public async Task<CompanyDto> GetById(Guid id)
    {
        var company = await _companyDbContext
            .Set<Company.Storage.Entities.Company>()
            .AsNoTracking()
            .Where(e => e.Id!.Equals(id))
            .SingleOrDefaultAsync();

        return new CompanyDto(company.Id, company.Name, company.PhoneDirectional, company.PhoneNumber, company.NIP,
            company.REGON);
    }

    public async Task<IEnumerable<CompanyDto>> Get()
    {
        var entities = await _companyDbContext
            .Set<Entities.Company>()
            .AsNoTracking()
            .ToListAsync();

        return entities.Select(x => new CompanyDto(x.Id, x.Name, x.PhoneDirectional, x.PhoneNumber, x.NIP, x.REGON));
    }

    public async Task<CompanyDto> Delete(Guid id)
    {
        var entity = await _companyDbContext
            .Set<Entities.Company>()
            .SingleOrDefaultAsync(e => e.Id!.Equals(id));

        _companyDbContext.Set<Entities.Company>().Remove(entity);

        await _companyDbContext.SaveChangesAsync();

        return new CompanyDto(entity.Id, entity.Name, entity.PhoneDirectional, entity.PhoneNumber, entity.NIP,
            entity.REGON);
    }

    public async Task<Guid> Create(CompanyDto dto)
    {
        var entity = new Entities.Company(dto.Name, dto.PhoneDirectional, dto.PhoneNumber, dto.NIP, dto.REGON);

        _companyDbContext.Set<Entities.Company>().Add(entity);

        await _companyDbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<CompanyDto> Update(CompanyDto dto)
    {
        // var entityBeforeUpdate = await GetById(dto.Id);
        // if (entityBeforeUpdate == null)
        // {
        //     return null;
        // }

        var newEntity = new Entities.Company(dto.Name, dto.PhoneDirectional, dto.PhoneNumber, dto.NIP, dto.REGON);
        newEntity.Id = dto.Id;

        _companyDbContext.Entry(newEntity).State = EntityState.Modified;

        await _companyDbContext.SaveChangesAsync();

        return dto;
    }
}