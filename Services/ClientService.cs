using System.Net;
using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.Models.Generics;

namespace Services;

public class ClientService : IClientService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public ClientService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Return<ClientDto>> GetAsync()
    {
        var returnObj = new Return<ClientDto>();

        try
        {
            var result = await _repository.Client.ReadAllClientsAsync();
            returnObj.Records = _mapper.Map<List<ClientDto>>(result);
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }
        
        returnObj.SetMessage();
        return returnObj;
    }

    public async Task<Return<ClientDto>> GetAsync(Guid id)
    {
        var returnObj = new Return<ClientDto>();

        try
        {
            var result = await _repository.Client.ReadClientAsync(id);
            returnObj.Records.Add(_mapper.Map<ClientDto>(result));
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }

        returnObj.SetMessage();
        return returnObj;
    }

    public async Task<Return<ClientDto>> PostAsync(PostClientDto postClientDto)
    {
        var returnObj = new Return<ClientDto>();
        
        try
        {
            var client = _mapper.Map<Client>(postClientDto);
            var result = await _repository.Client.CreateClientAsync(client);
            returnObj.Records.Add(_mapper.Map<ClientDto>(result));
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }

        returnObj.SetMessage();
        return returnObj;
    }

    public async Task<Return<ClientDto>> PutAsync(ClientDto clientDto)
    {
        var returnObj = new Return<ClientDto>();

        try
        {
            var client = _mapper.Map<Client>(clientDto);
            var result = await _repository.Client.UpdateClientAsync(client);
            returnObj.Records.Add(_mapper.Map<ClientDto>(result));
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }

        returnObj.SetMessage();
        return returnObj;
    }

    public async Task<Return<ClientDto>> DeleteAsync(Guid id)
    {
        var returnObj = new Return<ClientDto>();
        
        try
        {
            returnObj.Ok = await _repository.Client.DeleteClientAsync(id);
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }

        returnObj.SetMessage();
        return returnObj;
    }
}