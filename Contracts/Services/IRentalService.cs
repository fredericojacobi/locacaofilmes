using Entities.DataTransferObjects;
using Entities.Models.Generics;

namespace Contracts.Services;

public interface IRentalService
{
    Task<Return<RentalDto>> Get();
    
    Task<Return<RentalDto>> Get(Guid id);
    
    Task<Return<RentalDto>> Post(PostRentalDto postRentalDto);
    
    Task<Return<RentalDto>> Put(PostRentalDto rentalDto);
    
    Task<Return<RentalDto>> Delete(Guid id);
}