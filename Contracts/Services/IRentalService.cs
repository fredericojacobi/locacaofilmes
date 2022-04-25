using Entities.DataTransferObjects;
using Entities.Models.Generics;

namespace Contracts.Services;

public interface IRentalService
{
    Task<Return<RentalDto>> GetAsync();
    
    Task<Return<RentalDto>> GetAsync(Guid id);
    
    Task<Return<NewRentalDto>> GetNewPageAsync();
    
    Task<Return<RentalDto>> PostAsync(PostRentalDto postRentalDto);
    
    Task<Return<RentalDto>> PutAsync(PostRentalDto rentalDto);
    
    Task<Return<RentalDto>> DeleteAsync(Guid id);
}