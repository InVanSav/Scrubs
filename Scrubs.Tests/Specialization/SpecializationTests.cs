namespace Scrubs.Tests.Specialization;

using DAL.Interfaces;
using Domain.Entity;
using Domain.ViewModels.Specialization;
using Service.Implementations;

public class SpecializationTests {

    private readonly SpecializationService _specializationService;
    private readonly Mock<ISpecializationRepository> _specializationRepositoryMock;

    public SpecializationTests() {
        _specializationRepositoryMock = new Mock<ISpecializationRepository>();
        _specializationService = new SpecializationService(_specializationRepositoryMock.Object);
    }
    
    [Fact] 
    public void GetSpecializationOrNo_ShouldFail() {
        
        _specializationRepositoryMock.Setup(repository => repository.Get(It.IsAny<int>()))
            .Returns(() => null);

        var res = _specializationService.Get(0);

        Assert.True(res.IsFaulted);
        Assert.Equal("Specialization not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetSpecializationsOrNo_ShouldWork() {
        
        var specialization = new SpecializationViewModel {
            Id = 0,
            Name = "Pediatrician"
        };
        
        _specializationRepositoryMock.Setup(repository => repository.Select())
            .Returns(() => specialization);

        var res = _specializationService.GetSpecializations();

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetSpecializationByNameOrNo_ShouldFail() {
        
        _specializationRepositoryMock.Setup(
            repository => repository.GetSpecializationByName(It.IsAny<string>()))
            .Returns(() => null);

        var res = _specializationService.GetByName("Pediatrician");

        Assert.True(res.IsFaulted);
        Assert.Equal("Specialization not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void DeleteSpecializationOrNo_ShouldWork() {
        
        var specialization = new Specialization {
            Id = 0,
            Name = "Pediatrician"
        };
        
        _specializationRepositoryMock.Setup(repository => repository.Delete(specialization))
            .Returns(() => true);

        var res = _specializationService.DeleteSpecialization(0);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void CreateSpecializationOrNo_ShouldWork() {

        var specialization = new Specialization {
            Id = 0,
            Name = "Pediatrician"
        };
        
        _specializationRepositoryMock.Setup(repository => repository.Create(specialization))
            .Returns(() => true);

        var res = _specializationService.CreateSpecialization(specialization);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void EditSpecializationOrNo_ShouldWork() {

        var specialization = new Specialization {
            Id = 0,
            Name = "Pediatrician"
        };
        
        _specializationRepositoryMock.Setup(repository => repository.Update(specialization))
            .Returns(() => true);

        var res = _specializationService.Edit(0, specialization);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
}
