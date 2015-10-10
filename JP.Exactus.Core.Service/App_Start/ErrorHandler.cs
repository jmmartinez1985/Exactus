using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace JP.Exactus.Core.Service.App_Start
{
    public class ErrorHandler:DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await base.SendAsync(request,
                                                    cancellationToken);
                return response;
            }
            catch (Exception ex)
            {
                var responseMessage =
                    request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                        ex);
                return await Task<HttpResponseMessage>.Factory.StartNew(() =>
                        responseMessage);
            }
        }
    }
}