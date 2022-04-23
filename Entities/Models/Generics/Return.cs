using System.Net;

namespace Entities.Models.Generics;

public class Return<T> where T : class
{
    public bool Ok { get; set; }
    
    public int Code { get; set; }
    
    public string Message { get; set; }

    public int Quantity => Records.Count;
    
    public List<T> Records { get; set; }

    public Return()
    {
        Records = new List<T>();
    }

    public void SetMessage()
    {
        if (Ok)
            SetMessage(HttpStatusCode.OK);
        
        if (!Records.Any())
        {
            SetMessage(HttpStatusCode.NotFound);
        }
        
        SetMessage(HttpStatusCode.OK);
    }

    public void SetMessage(string message, bool ok, HttpStatusCode statusCode)
    {
        Message = message;
        Code = (int)statusCode;
        Ok = ok;
    }
    
    public void SetMessage(HttpStatusCode statusCode)
    {
        switch (statusCode)
        {
            case HttpStatusCode.NotFound:
                Code = (int)HttpStatusCode.NotFound;
                Message = "Registro não encontrado.";
                break;
            case HttpStatusCode.OK:
                Code = (int)HttpStatusCode.OK;
                Message = "Sucesso.";
                Ok = true;
                break;
            case HttpStatusCode.InternalServerError:
                Code = (int)HttpStatusCode.InternalServerError;
                Message = "Algo deu errado, favor tente novamente mais tarde.";
                break;
            case HttpStatusCode.UnprocessableEntity:
                Code = (int)HttpStatusCode.UnprocessableEntity;
                Message = "O corpo da requisição está incorreto.";
                break;
            default:
                Code = (int)HttpStatusCode.InternalServerError;
                Message = "Algo deu errado, favor tente novamente mais tarde.";
                break;
        }
    }
}