namespace Scrubs.Tests.Specialization;

using DAL.Interfaces;
using Domain.ViewModels.Specialization;
using Service.Implementations;

public class SpecializationTests {

    private readonly SpecializationService _specializationService;

    public SpecializationTests() {
        var specializationRepositoryMock = new Mock<ISpecializationRepository>();
        _specializationService = new SpecializationService(specializationRepositoryMock.Object);
    }
    
    [Fact] 
    public void GetSpecializationOrNo_ShouldFail() {

        var res = _specializationService.Get(0);

        Assert.True(res.IsFaulted);
        Assert.Equal("Specialization not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetSpecializationsOrNo_ShouldWork() {

        var res = _specializationService.GetSpecializations();

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetSpecializationByNameOrNo_ShouldFail() {

        var res = _specializationService.GetByName("Pediatrician");

        Assert.True(res.IsFaulted);
        Assert.Equal("Specialization not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void DeleteSpecializationOrNo_ShouldWork() {

        var res = _specializationService.DeleteSpecialization(0);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void CreateSpecializationOrNo_ShouldWork() {

        var specialization = new SpecializationViewModel {
            Id = 0,
            Name = "Pediatrician"
        };

        var res = _specializationService.CreateSpecialization(specialization);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void EditSpecializationOrNo_ShouldWork() {

        var specialization = new SpecializationViewModel {
            Id = 0,
            Name = "Pediatrician"
        };

        var res = _specializationService.Edit(0, specialization);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
}
