using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InteliSystem.VejaBem.Api.Util
{
    public static class ValidationControllers
    {
        public static ActionResult ValidationMessages(int? statusCode = StatusCodes.Status200OK, string title = null, [ActionResultObjectValue] ModelStateDictionary modelStateDictionary = null, [ActionResultObjectValue] Exception exception = null)
		{
			var lerros = new List<object>();
			if (modelStateDictionary != null) {
				foreach (var key in modelStateDictionary.Keys) {
					var erro = modelStateDictionary[key];
					var mensagens = new List<string>();
					foreach (var msg in erro.Errors) {
						mensagens.Add(msg.ErrorMessage);
					}
					if (mensagens.Count <= 0) {
						continue;
					}
					dynamic objerro = new {
						key,
						mensagens
					};
					lerros.Add(objerro);
				}
			}

			if (exception != null) {
				lerros.Add(new {
					key = "Error",
					mensagens = exception.Message 
				});
			}


			dynamic retorno = new {
				status = statusCode,
				titulo = title,
				erros = lerros
			};
			var objeresult = new ObjectResult(retorno);
			objeresult.StatusCode = statusCode;
			return objeresult;
		}
    }
}