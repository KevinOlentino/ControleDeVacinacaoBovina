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

        public Dictionary<string, string> Errors = new();   

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
            StatusCode = statusCode;

            if (ex.InnerException.Message != null)
                Errors.Add("error", ex.InnerException.Message);
            else
                Errors.Add("error", ex.Message);
        }
        
    }
}
