using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Models.Dtos
{
    public class ResponseDto<T>
    {
        public ResponseDto(EStatusCode statusCode,T data)
        {
            StatusCode = statusCode;
            Data = data;
        }
        public T Data { get; set; }
        public EStatusCode StatusCode { get; set; }

        public Dictionary<string, List<string>> Errors = new();   

        public Task<ObjectResult> ResultAsync()
        {
            var response = new ObjectResult(Data)
            {
                StatusCode = (int)StatusCode
            };

            if (Errors.Any())
            {
                response.Value = Errors;
                return Task.FromResult(response);
            }

            return Task.FromResult(response);            
        }

        public void AddException(Exception ex, EStatusCode statusCode)
        {
            List<string> exception = new();
            StatusCode = statusCode;

            if (ex.InnerException != null)
                exception.Add(ex.InnerException.Message);
            else           
                exception.Add(ex.Message);            
            
            Errors.Add("Exception", exception);
        }

        public void AddError(string Key, string Message)
        {            
            if (!Errors.ContainsKey(Key))
            {
                Errors.Add(Key, new List<string>());
            }

            Errors[Key].Add(Message);

        }
        
    }
}
