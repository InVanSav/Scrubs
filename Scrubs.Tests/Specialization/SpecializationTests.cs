namespace Scrubs.Tests.Specialization;

using Domain.ViewModels.Specialization;
using Service.Implementations;

public class SpecializationTests {

    private readonly SpecializationService _specializationService;

    public SpecializationTests(SpecializationService specializationService) {
        _specializationService = specializationService;
    }
    
    [Fact] 
    public void GetSpecializationOrNo_ShouldFail() {

        var res = _specializationService.Get(0);

        Assert.True(res.IsFaulted);
        Assert.Equal("Specialization not found:(", res.Result.Result);
        Assert.Equal(4, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetSpecializationsOrNo_ShouldFail() {

        var res = _specializationService.GetSpecializations();

        Assert.True(res.IsFaulted);
        Assert.Equal("Specializations not found:(", res.Result.Result);
        Assert.Equal(4, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetSpecializationByNameOrNo_ShouldFail() {

        var res = _specializationService.GetByName("Pediatrician");

        Assert.True(res.IsFaulted);
        Assert.Equal("Specialization not found:(", res.Result.Result);
        Assert.Equal(4, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void DeleteSpecializationOrNo_ShouldFail() {

        var res = _specializationService.DeleteSpecialization(0);

        Assert.True(res.IsFaulted);
        Assert.Equal("Specialization not found:(", res.Result.Result);
        Assert.Equal(4, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void CreateSpecializationOrNo_ShouldFail() {

        var specialization = new SpecializationViewModel {
            Id = 0,
            Name = "Pediatrician"
        };

        var res = _specializationService.CreateSpecialization(specialization);

        Assert.True(res.IsFaulted);
        Assert.Equal("Specialization wasn't create:(", res.Result.Result);
        Assert.Equal(5, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void EditSpecializationOrNo_ShouldFail() {

        var specialization = new SpecializationViewModel {
            Id = 0,
            Name = "Pediatrician"
        };

        var res = _specializationService.Edit(0, specialization);

        Assert.True(res.IsFaulted);
        Assert.Equal("Specialization not found:(", res.Result.Result);
        Assert.Equal(4, (int)res.Result.StatusCode);

    }
    
}
