namespace Scrubs.DAL.Interfaces;

using Domain.Entity;

public interface ISpecializationRepository : IBaseRepository<Specialization> {

    Task<Specialization> GetSpecializationByName(string name);

}
